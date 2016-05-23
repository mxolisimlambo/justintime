using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp.Data;
using System.Web;

namespace WebApp.Models
{
    public class ClassMarkViewModel
    {
        [Key]
        [Required]
        [Display(Name = "Student_Number")]
        public string Student_No { get; set; }
        [Required]
        [Display(Name = "Student_Name")]
        public string Student_name { get; set; }
        [Required]
        [Display(Name = "Class ")]
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject1 { get; set; }
        [Display(Name = "Mark of Subject")]
        public int? mark { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject2 { get; set; }
        [Display(Name = "Mark of Subject")]
        public int? mark21 { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject3 { get; set; }
        [Display(Name = "Mark of Subject")]
        public int? mark12 { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject4 { get; set; }
        [Display(Name = "Mark of Subject")]
        public int? mark23 { get; set; }

        [Required]
        [Display(Name = "Subject ")]
        public string Subject5 { get; set; }
        [Display(Name = "Mark of Subject")]
        public int? mark32 { get; set; }
    }
}