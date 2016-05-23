using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class AssignTeacherToClassViewmodel
    {
        [key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Staff Number is required"), Display(Name = "StaffNumber")]
        public string StaffNumber { get; set; }
        public virtual Staff staffT { get; set; }
        [Required(ErrorMessage = "GroupeName is required"), Display(Name = "Classs")]
        public string GradeGroupId { get; set; }
        public virtual ClassGroupe GradeGroup { get; set; }
    }
}