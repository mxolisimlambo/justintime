using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApp.Data;
using System.Web;

namespace WebApp.Models
{
    public class MarkViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Markid { get; set; }
        [Required(ErrorMessage = "Class For Mark Capture is Required"),
            StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "Please Grade e.g 11C"),
            Display(Name = "ClassGrade")]
        public string ClassGroupID { get; set; }
        [Required(ErrorMessage = "Subject Code For Mark Capture is Required"),
           StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "Please Grade e.g Physices = PHY"),
           Display(Name = "Subject Code")]
        public string Subject_Code { get; set; }
         [ Display(Name = "Term One")]
        public int? Term1 { get; set; }
         [ Display(Name = "Term Two")]
        public int? Term2 { get; set; }
        [Display(Name = "Term Three")]
        public int? Term3 { get; set; }
        [Display(Name = "Term Four")]
        public int? Term4 { get; set; }
        [Required(ErrorMessage = "Student Number  is Required"),
          StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "Please enter Correct Student Number"),
          Display(Name = "Student Number")]
        public string StudentID { get; set; }
        public virtual StudentTable Student { get; set; }
    }
}