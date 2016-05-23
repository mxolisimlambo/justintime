using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class RegistrationViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Student_Number")]
        public string Student_Number { get; set; }
        [Required(ErrorMessage = "Student Id Number is Required"),
        StringLength(maximumLength:13, MinimumLength = 13, ErrorMessage = "Please Enter SA Id Number")]
        [Display(Name = "Student_IDNumber")]
        public string Student_IDNumber { get; set; }
        [Required(ErrorMessage = "Student Name is Required")]
        [Display(Name = "Student_Name")]
        public string Student_Name { get; set; }
        [Required]
        [Display(Name = "Student_Surname")]
        public string Student_Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Student_Date_Of_Birth")]
        public DateTime Student_Date_Of_Birth { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Enrolment_Date")]
        public DateTime Enrolment_Date { get; set; }
        [Required]
        [Display(Name = "Student_Gender")]
        public string Student_Gender { get; set; }
        [Required]
        [Display(Name = "Student_Religion")]
        public string Student_Religion { get; set; }
        [Required]
        [Display(Name = "Student_Address")]
        public string Student_Adress { get; set; }
        [Required]
        [Display(Name = "Grade Allocation")]
        public string Grade_id { get; set; }
        public virtual Grade Grades { get; set; }
        [Required]
        [Display(Name = "ClassGroupe")]
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }
        [Required]
        [Display(Name = "Stream_Code")]
        public string Stream_Code { get; set; }
        public virtual StreamTable StreamTable { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
        //[Required]
        //[Display(Name = "AddPhoto")]
        public byte[] AddPhoto { get; set; }
        [Required]
        [Display(Name = "status")]
        public string status { get; set; }



        [Required]
        [Display(Name = "Parent_Identity ")]
        [StringLength(13)]
        public string Parent_Identity { get; set; }
        public virtual Parent Parent { get; set; }
        [Required]
        [Display(Name = "Parent_Title ")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Parent_Name")]
        public string Parent_Name { get; set; }
        [Required]
        [Display(Name = "Parent_Surname ")]
        public string Parent_Surname { get; set; }
        [Required]
        [StringLength(13,ErrorMessage =" Phone Number Must be 10 Numbers")]
        [Display(Name = "Parent_Number")]
        public string Parent_Number { get; set; }
        [Required]
        [Display(Name = "Parent_Adress ")]
        public string Parent_Adress { get; set; }
        [Required]
        [Display(Name = "Parent_Email ")]
        [EmailAddress]
        public string Parent_Email { get; set; }
    }
}