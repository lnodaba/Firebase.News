using Firebase.Database;
using Firebase.Database.Query;
using Firebase.News.Domain.Model;
using Firebase.Storage;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Firebase.News.Domain
{
    public class FirebaseRepository
    {
        private string _firebaseStorageAccounURL = "sapi-news.appspot.com";
        private string _firebaseDatabaseAccounURL = "https://sapi-news.firebaseio.com/";

        public async Task<string> UploadImage(Stream inputStream, string fileName)
        {
            return await new FirebaseStorage(_firebaseStorageAccounURL)
                .Child("News")
                .Child(fileName)
                .PutAsync(inputStream);
        }

        public async Task<FirebaseObject<NewsItem>> SaveNewsItem(NewsItem item)
        {
            var creator = await this.GetCreatorBy(Creator.Me.Name);
            item.CreatorId = creator.Id;

            return await new FirebaseClient(_firebaseDatabaseAccounURL)
                .Child("News")
                .PostAsync(item);
        }

        public async Task<IEnumerable<NewsItem>> GetNews()
        {
            var creators = await this.GetCreators();
            var newsCollection = await new FirebaseClient(_firebaseDatabaseAccounURL)
                .Child("News")
                .OnceAsync<NewsItem>();

            return newsCollection.mapToBase(creators);
        }

        private async Task<IEnumerable<Creator>> GetCreators()
        {
            var creators = await new FirebaseClient(_firebaseDatabaseAccounURL)
              .Child("Creators")
              .OnceAsync<Creator>();

            return creators.mapToBase();
        }

        /// <summary>
        /// need to have using System.Linq;
        /// </summary>
        public async Task<Creator> GetCreatorBy(string name)
        {
            if (!TryGetCreatorBy(name, out Creator creator))
                creator = await SaveCreator(Creator.Me);

            return creator;
        }

        private bool TryGetCreatorBy(string name, out Creator creator)
        {
            var result = new FirebaseClient(_firebaseDatabaseAccounURL)
              .Child("Creators")
              .OrderBy("Name")
              .StartAt(name)
              .LimitToFirst(1)
              .OnceAsync<Creator>().Result
              .FirstOrDefault();

            if (result == null)
            {
                creator = new Creator();
                return false;
            }
            else
            {
                creator = result.Object;
                creator.Id = result.Key;
                return true;
            }
        }

        private async Task<Creator> SaveCreator(Creator creator)
        {
            var result = await new FirebaseClient(_firebaseDatabaseAccounURL)
                .Child("Creators")
                .PostAsync(creator);
            result.Object.Id = result.Key;

            return result.Object;
        }

    }
}
