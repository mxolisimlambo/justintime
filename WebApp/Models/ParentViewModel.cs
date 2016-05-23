using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class ParentViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Parent ID_Number is required"), StringLength(13)]
        public string Parent_Identity { get; set; }
        public string Title { get; set; }
        public string Parent_Name { get; set; }
        public string Parent_Surname { get; set; }
        public string Parent_Number { get; set; }
        public string Parent_Adress { get; set; }
        public string Parent_Email { get; set; }
        public virtual ICollection<StudentTable> Student { get; set; }

    }
}