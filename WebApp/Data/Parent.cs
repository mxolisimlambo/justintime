using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public string Parent_Identity { get; set; }
        public string Title { get; set; }
        public string Parent_Name { get; set; }
        public string Parent_Surname { get; set; }
        public string Parent_Number { get; set; }
        public string Parent_Adress { get; set; }
        public string Parent_Email { get; set; }
        public ICollection<StudentTable> StudentTable { get; set; }
    }
}