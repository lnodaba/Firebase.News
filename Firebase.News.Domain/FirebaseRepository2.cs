using Firebase.Database;
using Firebase.News.Domain.Model;
using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace Firebase.News.Domain
{
    public class FirebaseRepository2
    {
        private string storageAccountUrl = "sapi-news.appspot.com";
        private string realtimeDatabaseAccountUrl = "https://sapi-news.firebaseio.com/";

        public async Task<string> UploadImage(Stream inputStream, string fileName)
        {
            return await new FirebaseStorage(storageAccountUrl)
                .Child("News")
                .Child(fileName)
                .PutAsync(inputStream);
        }

        public async Task<FirebaseObject<NewsItem>> SaveNewsItem(NewsItem item)
        {
            return await new FirebaseClient(realtimeDatabaseAccountUrl)
                .Child("News")
                .PostAsync(item);
        }
    }
}
