using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class ClassMark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Student_No { get; set; }
        public virtual StudentTable Student { get; set; }
        public string Student_name { get; set; }

        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }

        public string Subject1 { get; set; }
        public int? mark { get; set; }
        public string Subject2 { get; set; }
        public int? mark21 { get; set; }
        public string Subject3 { get; set; }
        public int? mark12 { get; set; }
        public string Subject4 { get; set; }
        public int? mark23 { get; set; }
        public string Subject5 { get; set; }
        public int? mark32 { get; set; }
    }
}