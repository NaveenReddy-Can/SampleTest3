using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleTest3.Interfaces;
using SampleTest3.Models;
using SampleTest3.Services;

namespace SampleTest3.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BookService bookService;

        // TEST NOTE: Create a constructor for dependency injection
        public BooksController(BookService bookService, ApplicationDbContext context)
        {
            this.bookService = bookService;
            this.db = context;
        }

        // TEST NOTE: Restrict the Edit and Create actions to require Admin role

        // TEST NOTE: Create an action NoDigits that takes in a string and returns true if the string has no digits, false otherwise
        public JsonResult NoDigits(string title)
        {
            bool result;
            if (title == null)
                result = true;
            else result = title.ToCharArray().All(x => !Char.IsDigit(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(bookService.GetBooks());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBookById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Title,Cost")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBookById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Cost")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBookById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = bookService.GetBookById((int)id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
