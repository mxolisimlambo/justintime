using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Data;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class StudentMarkViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Student_Number { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public string Student_Name { get; set; }
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }
        public string GroupeName { get; set; }
        public string Subject_Code { get; set; }
        public virtual Subjects Subjects { get; set; }
        public int? mark { get; set; }
        public string result { get; set; }
    }
}