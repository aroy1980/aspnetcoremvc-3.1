using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Enums;
using WebGentle.BookStore.Helpers;

namespace WebGentle.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Title.")]
        [StringLength(100, MinimumLength =5)]
      //  [MyCustomValidation(Text ="Azure",ErrorMessage ="Need Matching Word")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please Select a Language.")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        //[Required(ErrorMessage = "Please Select a Language.")]
        //public LanguageEnum LanguageEnum { get; set; }
        [Required]
        [Display(Name = "Total Pages of the Book")]
        public int? TotalPages { get; set; }
        [Required]
        [Display(Name ="Please select a cover photo")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImagePath { get; set; }
        [Required]
        [Display(Name = "Choose the gallery Images ")]
        public IFormFileCollection GalleryFile { get; set; }
        public List<GalleryModel> Gallery { get; set; }

        [Required]
        [Display(Name = "Upload Your Book")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
