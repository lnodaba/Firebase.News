using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;

namespace Firebase.News.Tests
{
    [TestClass]
    public class FirebaseStorageShould
    {
        private readonly string firebaseAccountURL = "sapi-news.appspot.com";

        [TestMethod]
        public async Task SaveADinoPictureToTheCloud()
        {
            //Arrange
            var firebase = new FirebaseStorage(firebaseAccountURL);
            string fileName = "Spinosaurus";      
            var stream = File.Open(getPath(fileName), FileMode.Open);

            //Act
            var downloadUrl = await new FirebaseStorage(firebaseAccountURL)
                .Child("Images")
                .Child("Dinosaurs")
                .Child(fileName)
                .PutAsync(stream);

            //Assert
            Assert.IsNotNull(downloadUrl);

            //Clean up
            await firebase
                .Child("Images")
                .Child("Dinosaurs")
                .Child(fileName)
                .DeleteAsync();
        }

        [TestMethod]
        public async Task HaveADownloadURLForTrex()
        {
            //Arrange
            var firebase = new FirebaseStorage(firebaseAccountURL);
            string fileName = "TRex";
            Func<string, FirebaseStorageReference> filter = (x) => firebase
                .Child("Images")
                .Child("Dinosaurs")
                .Child(x);
            var stream = File.Open(getPath(fileName), FileMode.Open);

            //Act

            var resultUrl = await filter(fileName)
                .PutAsync(stream);

            var downloadUrl = await filter(fileName)
                .GetDownloadUrlAsync();

            //Assert
            Assert.AreEqual(resultUrl,downloadUrl);

            //Clean up
            await filter(fileName)
                .DeleteAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(FirebaseStorageException),"If the file doesn't exist it should throw an exception.")]
        public async Task ThrowsErroIfImageDoesntExist()
        {
            //Arrange
            var firebase = new FirebaseStorage(firebaseAccountURL);
            string fileName = "TRex";
            Func<string, FirebaseStorageReference> filter = (x) => firebase
                .Child("Images")
                .Child("Dinosaurs")
                .Child(x);
            var stream = File.Open(getPath(fileName), FileMode.Open);
            
            //Act
            var createdUrl = await filter(fileName)
                .PutAsync(stream);

            filter(fileName)
                .DeleteAsync()
                .Wait();

            var downloadUrl = await filter(fileName)
                .GetDownloadUrlAsync();

        }

        private static string getPath(string fileName)
        {
            return Directory.GetCurrentDirectory() + $"\\Files\\{fileName}.jpg";
        }
    }
}
