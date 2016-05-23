using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class AssignTeacherToSubjectViewModel
    {

        [key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Staff Number is required"), Display(Name = "StaffNumber")]
        public string StaffNumber { get; set; }
        public virtual Staff staffT { get; set; }
        [Required(ErrorMessage = "Class is Required "), Display(Name = "Class")]
        public string GradeGroupId { get; set; }
        public virtual ClassGroupe GradeGroup { get; set; }
        [Required(ErrorMessage = "Subject Code is required"), Display(Name = "Subject Code")]
        public string SubjectCode { get; set; }
        public virtual Subjects SubjectT { get; set; }
    }
}