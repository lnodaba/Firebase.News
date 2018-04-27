using Firebase.News.Domain;
using Firebase.News.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Firebase.News.Controllers
{
    public class NewsController : AsyncController
    {
        public NewsItem AnItem = new NewsItem()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Test",
            Date = DateTime.Now,
            Description = "No description",
            CreatorId = "PistikeID",
            ImagePaths = new List<string>()
            {
                "Path1",
                "Path2"
            }
        };

        // GET: News
        public ActionResult Index()
        {
            return View(new List<NewsItem>()
            {
                AnItem,
                AnItem,
                AnItem,
                AnItem
            });
        }

        // GET: News/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public async Task<ActionResult> Create(NewsItem item, IEnumerable<HttpPostedFileBase> files)
        {
            // TODO: Add insert logic here
            var file = files.FirstOrDefault();
            var downloadUrl = await new FirebaseRepository().Upload(file.InputStream, file.FileName);
            if (!string.IsNullOrWhiteSpace(downloadUrl))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: News/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
