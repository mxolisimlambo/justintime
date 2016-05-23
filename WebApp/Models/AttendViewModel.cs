using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace   WebApp.Models
{
    public class AttendViewModel
    {
        [Key]
        public int AttendID { get; set; }
        [Required(ErrorMessage = "Please enter StudentNo")]
        [StringLength(13)]
        public string StudentNo { get; set; }
        [Required(ErrorMessage = "Please enter StudentName")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please select Day")]
        public string Day { get; set; }
        [Required(ErrorMessage = "Please enter GradeGroupID ")]
        public string GradeGroupID { get; set; }
        [Required(ErrorMessage = "Please enter Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
       
        public string Attends { get; set; }
        public string Absent { get; set; }
        public string Await { get; set; }
        [Required(ErrorMessage = "Please enter Remark")]
        public string Remark { get; set; }
    }
}