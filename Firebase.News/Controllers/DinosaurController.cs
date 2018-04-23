using Firebase.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firebase.News.Controllers
{
    public class DinosaurController : Controller
    {
        private DinosaurDto dino => new DinosaurDto(Guid.NewGuid().ToString(),"T-Rex", "Male", 2);
        // GET: Dinosaur
        public ActionResult Index()
        {
            return View(new List<DinosaurDto>
            {
                new DinosaurDto(Guid.NewGuid().ToString(), "T-Rex", "Male", 2),
                new DinosaurDto(Guid.NewGuid().ToString(), "Velociraptor", "Female", 21),
                new DinosaurDto(Guid.NewGuid().ToString(), "Spinosaurus", "Male", 28)
            });
        }

        // GET: Dinosaur/Details/5
        public ActionResult Details(string id)
        {
            return View(dino);
        }

        // GET: Dinosaur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dinosaur/Create
        [HttpPost]
        public ActionResult Create(DinosaurDto Dino)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dinosaur/Edit/5
        public ActionResult Edit(string id)
        {
            return View(dino);
        }

        // POST: Dinosaur/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, DinosaurDto dino)
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

        // GET: Dinosaur/Delete/5
        public ActionResult Delete(string id)
        {
            return View(dino);
        }

        // POST: Dinosaur/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, DinosaurDto dino)
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
