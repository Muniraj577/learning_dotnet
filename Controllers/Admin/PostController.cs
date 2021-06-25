using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers.Admin
{
    [RoutePrefix("post")]
    public class PostController : Controller
    {
        // GET: Post
        [Route("~/posts", Name = "post.index")]
        public ActionResult Index()
        {
            var posts = _db.Posts.Include(p => p.Category).ToList(); 
            return View(this.page + "Index.cshtml", posts);
        }

        [Route("create", Name = "post.create")]
        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            //Post model = new Post();
            return View(this.page + "Create.cshtml");
        }

        [Route("store", Name = "post.store")]
        [HttpPost]
        public ActionResult store(Post p)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
                var ext = Path.GetExtension(p.ImageFile.FileName);
                filename = filename + ext;
                p.Image = filename;
                filename = Path.Combine(Server.MapPath(this.destination), filename);
                var path = Path.Combine(Server.MapPath(this.destination));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                p.ImageFile.SaveAs(filename);
                _db.Posts.Add(p);
                _db.SaveChanges();
                
                TempData["SuccessMsg"] = "Post created successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _db.Categories.ToList();
            return View(this.page + "Create.cshtml");
        }

        [Route("edit/{id:int}", Name = "post.edit")]
        public ActionResult Edit(int id)
        {
            var post = _db.Posts.Where(m => m.Id == id).FirstOrDefault();
            ViewBag.Categories = _db.Categories.ToList();
            return View(this.page + "Edit.cshtml", post);
        }

        [Route("update/{id:int}", Name = "post.udpate")]
        [HttpPost]
        public ActionResult update(Post p)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(p).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["SuccessMsg"] = "Post updated successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _db.Categories.ToList();
            return View(this.page + "Edit.cshtml");
        }

        private string page = "~/Views/Admin/Post/";
        private BlogContext _db = new BlogContext();
        private string destination = "~/Content/Images/Posts/";
    }
}