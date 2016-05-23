using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class ClassGroupe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public string ClassGroupe_id { get; set; }
        public string GroupeName { get; set; }
        public string Grade_id { get; set; }
        public virtual Grade Grade { get; set; }
        public ICollection <StudentTable> StudentTable { get; set; }


    }
}