using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.News.Domain
{
    public class FirebaseRepository
    {
        private readonly string _firebaseAccountURL = "sapi-news.appspot.com";

        public async Task<string> Upload(Stream stream, string fileName)
        {
            return await new FirebaseStorage(_firebaseAccountURL)
               .Child("News")
               .Child("Images")
               .Child(fileName)
               .PutAsync(stream);
        }
    }
}
