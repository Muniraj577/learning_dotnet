using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers.Admin
{
    [RoutePrefix("category")]
    public class CategoryController : Controller
    {
        private BlogContext db = new BlogContext();

        private string page = "~/Views/Admin/Category/";
        // GET: Category
        [Route("~/categories", Name = "category")]
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(this.page + "Index.cshtml", categories);
        }

        [Route("create", Name = "createCategory")]
        public ActionResult Create()
        {
            return View(this.page + "Create.cshtml");
        }

        //public ActionResult store(Category cat)

        [Route("store", Name = "store")]
        [HttpPost]
        public ActionResult store(Category cat)
        {
            if (ModelState.IsValid)
            {
                //Category cat = new Category(); // Working code.. Remove Category cat in parameter
                //cat.Name = Request["Name"];
                db.Categories.Add(cat);
                db.SaveChanges();
                TempData["SuccessMsg"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(this.page + "Create.cshtml");
        }
        [Route("edit/{id:int}", Name = "editCategory")]
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Where(m => m.Id == id).FirstOrDefault();
            return View(this.page + "Edit.cshtml", category);
        }

        //[Route("update", Name = "updateCategory")] // Working Code
        //[HttpPost]
        //public ActionResult update(Category cat)
        //{
        //    var name = cat.Name;
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cat).State = EntityState.Modified;
        //        db.SaveChanges();
        //        TempData["SuccessMsg"] = "Category " + name + " updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(this.page + "Edit.cshtml", cat);

        //}

        [Route("update", Name = "updateCategory")] //Tested successfully
        [HttpPost]
        public ActionResult update(int id)
        {
            var cat = db.Categories.Where(m => m.Id == id).FirstOrDefault();
            var name = cat.Name;
            if (ModelState.IsValid)
            {
                cat.Name = Request["Name"];
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMsg"] = "Category " + name + " updated to " + cat.Name + " successfully";
                return RedirectToAction("Index");
            }
            return View(this.page + "Edit.cshtml", cat);

        }

        [Route("detail/{id:int}")]
        public ActionResult Detail(Category cat)
        {
            var category = db.Categories.Where(m => m.Id == cat.Id).FirstOrDefault();
            return View(this.page + "Detail.cshtml", category);
        }

        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var cat = db.Categories.Where(m => m.Id == id).FirstOrDefault();
                if (cat != null)
                {
                    db.Entry(cat).State = EntityState.Deleted;
                    db.SaveChanges();
                    TempData["SuccessMsg"] = "Category " + cat.Name + " deleted successfully";
                }
            }

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