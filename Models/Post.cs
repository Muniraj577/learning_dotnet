using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Custom_Validation;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Post title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Post description is required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int? CatId { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Upload Image")]
        [ValidateFile]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public Category Category { get; set; }

        //[NotMapped]
        //public List<Category> Categories { get; set; }

        //public SelectList Categories { get; set; }
    }
}