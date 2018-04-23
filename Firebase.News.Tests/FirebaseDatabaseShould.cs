using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Firebase.News.Models;

namespace Firebase.News.Tests
{
    [TestClass]
    public class FirebaseDatabaseShould
    {
        private readonly string firebaseAccountURL = "https://sapi-news.firebaseio.com/";

        [TestMethod]
        public async Task SaveTRexToTheCloud()
        {
            //Arrange
            var firebase = new FirebaseClient(firebaseAccountURL);
            string testContext = "dinosaurs-save-tests";
            await firebase.Child(testContext).DeleteAsync();

            //Act
            var dino = await saveDino(firebase, testContext, Dinosaur.TRex);  

            //Assert
            Assert.IsNotNull(dino);
        }

        [TestMethod]
        public async Task ContainAtLeastOneTRex()
        {
            //Arrange
            var firebase = new FirebaseClient(firebaseAccountURL);
            string testContext = "dinosaurs-query-tests";
            await firebase.Child(testContext).DeleteAsync();

            //Act
            await saveDino(firebase, testContext, Dinosaur.TRex);
            await saveDino(firebase, testContext, Dinosaur.Spinosaurus);
            await saveDino(firebase, testContext, Dinosaur.Velociraptor);

            var dinos = await firebase
               .Child(testContext)
               .OrderByKey()
               .OnceAsync<Dinosaur>();
            var resultCount = dinos.Where(x => x.Object.Name == Dinosaur.TRex.Name)?.Count();

            //Assert
            Assert.AreEqual(resultCount, 1);
        }

        [TestMethod]
        public async Task DeleteTRexFromTheCloud()
        {
            //Arrange
            var firebase = new FirebaseClient(firebaseAccountURL);
            string testContext = "dinosaurs-delete-tests";
            await firebase.Child(testContext).DeleteAsync();

            //Act
            var dino = await saveDino(firebase, testContext, Dinosaur.TRex);

            await firebase
                .Child(testContext)
                .DeleteAsync();

            var dinos = await firebase
             .Child(testContext)
             .OrderByKey()
             .OnceAsync<Dinosaur>();

            //Assert
            Assert.AreEqual(dinos.Count,0);
        }

        [TestMethod]
        public void SyncronizeIfNewDinoArrives()
        {
            //https://github.com/step-up-labs/firebase-database-dotnet#realtime-streaming
            Assert.Fail("Not implemented yet.");
        }

        private async Task<FirebaseObject<T>> saveDino<T>(FirebaseClient firebase, string testContext, T dino)
        {
            return await firebase
                 .Child(testContext)
                 .PostAsync(dino);
        }
    }
}
