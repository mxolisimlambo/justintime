using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string Grade_id { get; set; }    
        public string GradeName { get; set; }
        public ICollection<ClassGroupe> ClassGroups { get; set; }
        public ICollection<StudentTable> StudentTables { get; set; }
    }
}