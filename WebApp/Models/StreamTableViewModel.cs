using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class StreamTableViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Stream Code is required"), Display(Name = "Stream Code")]
        public string Stream_Code { get; set; }
        [Required(ErrorMessage = "Stream Description is required"), Display(Name = "Stream Description")]
        public string Description { get; set; }
        public ICollection<Subjects> Subject { get; set; }
    }
}