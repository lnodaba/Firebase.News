using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.News.Domain.Model
{
    public class NewsItem
    {
        public NewsItem()
        {
        }

        public NewsItem(string id, DateTime date, string description, string title, List<string> imagePaths, string creatorId)
        {
            Id = id;
            Date = date;
            Description = description;
            Title = title;
            ImagePaths = imagePaths;
            CreatorId = creatorId;
        }

        public string Id { get; set; }
        

        private DateTime _date;

        public long DateStamp
        {
            get => _date.Ticks;
        }

        [JsonIgnore]
        public DateTime Date
        {
            get => _date;
            set =>_date = value;
        }

        public string Description { get; set; }
        public string Title { get; set; }
        public List<string> ImagePaths { get; set; }
        public string CreatorId { get; set; }
    }
}
