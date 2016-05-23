using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class StreamTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public string Stream_Code { get; set; }
       
        public string Description { get; set; }
        public ICollection<Subjects> Subject { get; set; }
        public ICollection<StudentTable> StudentTables { get; set; }
    }
}