using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;
using BookStoreApp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IRepo<Author> repo;

        public AuthorController(IRepo<Author> repo) //injection par constructeur
        {
            this.repo = repo;
        }

        // GET: Author
        public ActionResult Index()
        {
            var list = repo.GetAll();
            return View(list);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author a)
        {
            try
            {
                // TODO: Add insert logic here
                repo.Add(a);
                repo.Commit();// Ef Core
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author a)
        {
            try
            {
                // TODO: Add update logic here
                repo.Update(a);
                repo.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTwo(int id)
        {
            try
            {
                // TODO: Add delete logic here
                repo.Delete(id);
                repo.Commit();// Ef Core

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {
            var resu = repo.GetAll().Where(a => a.Name.ToLower().Contains(term.ToLower())); //on a ajouté ToLower pour eviter les problems MAJ
            return View("Index",resu);
        }
    }
}