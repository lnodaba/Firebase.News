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
        private FirebaseRepository _repo;

        public NewsController()
        {
            _repo = new FirebaseRepository();
        }

        // GET: News
        public async Task<ActionResult> Index()
        {
            var result = await _repo.GetNews();
            return View(result);
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
            foreach (var file in files.Where(x => x != null))
            {
                var imagePath = await _repo.UploadImage(file.InputStream, file.FileName);
                item.ImagePaths.Add(imagePath);
            }
            var result = await _repo.SaveNewsItem(item);
            return RedirectToAction("Index");
        }

        // GET: News/Details/5
        public async Task<ActionResult> Details(string id) => await GetCreatorBy(id);

        // GET: News/Edit/5
        public async Task<ActionResult> Edit(string id) => await GetCreatorBy(id);

        private async Task<ActionResult> GetCreatorBy(string id)
        {
            var resultCollection = await _repo.GetNews();
            var result = resultCollection.Where(x => x.Id == id).FirstOrDefault();
            return View(result);
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
