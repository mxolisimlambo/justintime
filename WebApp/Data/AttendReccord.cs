using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class AttendReccord
    {
        [Key]
       
        public int AttendReccordID { get; set; }
        [Required(ErrorMessage = "Please enter StudentNo")]
        public string StudentNo { get; set; }
        [Required(ErrorMessage = "Please Enter StudentName ")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please enter GradeGroupID ")]
        public string GradeGroupID { get; set; }
        [Required(ErrorMessage = "Please Select a Day")]
        public string Day { get; set; }
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