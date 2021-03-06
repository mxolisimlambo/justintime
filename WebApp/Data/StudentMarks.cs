﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class StudentMarks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Student_Number { get; set; }
       
        public string Student_Name { get; set; }
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }
        public string GroupeName { get; set; }
        public string Subject_Code { get; set; }
        public virtual Subjects Subjects { get; set; }
        public int? mark { get; set; }
        public string  result { get; set; }
    }
}
