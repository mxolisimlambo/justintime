using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class SubjectsViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Subject Code is required"), Display(Name = "Subject Code")]
        public string Subject_Code { get; set; }
        [Required(ErrorMessage = "Subject DescriptiveTitle is required"), Display(Name = "Subject DescriptiveTitle")]
        public string DescriptiveTitle { get; set; }
        [Required(ErrorMessage = "Stream Code is required"), Display(Name = "Stream Code")]
        public string Stream_Code { get; set; }
        public virtual StreamTable StreamTable { get; set; }
    }
}