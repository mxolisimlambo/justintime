using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class GradesViewModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Grade is required"), Display(Name = "Grade")]
        public string Grade_id { get; set; }
        [Required(ErrorMessage = "Grade Description is required"), Display(Name = "Grade Name")]
        public string GradeName { get; set; }
        
    }
}