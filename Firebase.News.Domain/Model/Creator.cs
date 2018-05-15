using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.News.Domain.Model
{
    public class Creator
    {
        [JsonIgnore]
        public readonly static Creator Me = new Creator()
        {
            Name = "Lorand Noda",
            ContactInfo = "LynxSolutions S.R.L - .NET Department"
        };

        public Creator()
        {
            
        }

        public Creator(string id, string name, string contactInfo)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

    }
}
