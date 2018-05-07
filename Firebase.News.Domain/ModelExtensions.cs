using Firebase.Database;
using Firebase.News.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.News.Domain
{
    public static class ModelExtensions
    {
        public static IEnumerable<NewsItem> mapToBase(this IReadOnlyCollection<FirebaseObject<NewsItem>> collection,IEnumerable<Creator> creators)
        {
            foreach (var newsItem in collection.ToList())
            {
                newsItem.Object.Id = newsItem.Key;
                newsItem.Object.Creator = creators.Where(y => y.Id == newsItem.Object.CreatorId).FirstOrDefault();
                yield return newsItem.Object;
            }
        }

        public static IEnumerable<Creator> mapToBase(this IReadOnlyCollection<FirebaseObject<Creator>> creators)
        {
            foreach (var creator in creators)
            {
                creator.Object.Id = creator.Key;
            }

            return creators.Select(x => x.Object);
        }
    }
}
