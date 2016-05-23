using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Attend
    {
        [Key]
        public int AttendID { get; set; }
        [Required(ErrorMessage = "Please enter StudentNo")]
        [StringLength(13)]
        public string StudentNo { get; set; }
        [Required(ErrorMessage = "Please Enter StudentName ")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please enter GradeGroupID ")]
        public string GradeGroupID { get; set; }
        [Required(ErrorMessage = "Please Select a Day ")]
        public string Day { get; set; }
        [Required(ErrorMessage = "Please enter Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Attends { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Absent { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Await { get; set; }

        [Required(ErrorMessage = "Please enter Remark")]
        public string Remark { get; set; }
    }
}