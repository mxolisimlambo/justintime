using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class ClassGroupViewModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Grade is required"), Display(Name = "Grade")]
        public string ClassGroupe_id { get; set;}
        [Required(ErrorMessage = "GroupeName is required"),
       StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "Please Grade e.g 10B"),
            Display(Name = "GroupeName")]
        public string GroupeName { get; set; }
        [Required(ErrorMessage = "Grade is required Assigning to is required"),
            StringLength(maximumLength: 2, MinimumLength = 2, ErrorMessage = "Please Grade e.g 10"),
            Display(Name = "Grade")]
        public string Grade_id { get; set; }
        public virtual Grade Grades { get; set; }
        
    }
}