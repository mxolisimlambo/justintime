using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ApplicationViewModel
    {
        [Key]

        [Required(ErrorMessage = "Student's ID_Number is required"), StringLength(13, ErrorMessage = "Please make sure you enter the correct SA ID_Number")]
        public string Applicant_IDNumber { get; set; }

        [Required(ErrorMessage = "Student's Name is required"), Display(Name = "Student's name")]
        public string Applicant_Name { get; set; }

        [Required(ErrorMessage = "Student's Last Name is required"), Display(Name = "Student's Last Name")]
        public string Applicant_Surname { get; set; }

        [Required(ErrorMessage = "Student's date of birth is required"), Display(Name = "Student's Date of Date")]
        [DataType(DataType.Date)]
        public DateTime Applicant_Date_Of_Birth { get; set; }

        [Required(ErrorMessage = "Student's Gender is required"), Display(Name = "Student's Gender")]
        public string Applicant_Gender { get; set; }

        [Required(ErrorMessage = "Student's Religion is required"), Display(Name = "Student's Religion")]
        public string Applicant_Religion { get; set; }

        [Required(ErrorMessage = "Please Enter Student Address"), Display(Name = "Address")]
        public string Applicant_Adress { get; set; }

        [Required(ErrorMessage = "Please select the grade student is applying for"), Display(Name = "Grade")]
        public string Application_Grade { get; set; }

        [Required(ErrorMessage = "Please enter mark"), Display(Name = "Mathematics Mark")]
        public int Maths_Mark { get; set; }

        [Required(ErrorMessage = "Please enter mark"), Display(Name = "English Mark")]
        public int English_Mark { get; set; }

        [Required(ErrorMessage = "Please enter mark"), Display(Name = "Zulu (HL) Mark")]
        public int ZuluHomeLanguage_Mark { get; set; }
        public string status { get; set; }

        [Required(ErrorMessage = "Parent's Title is required"), Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Parent's first name is required"), Display(Name = "First Name")]
        public string Parent_Name { get; set; }

        [Required(ErrorMessage = "Parent's last name is required"), Display(Name = "Last Name")]
        public string Parent_Surname { get; set; }

        [Required(ErrorMessage = "Parent's cell number is required"), Display(Name = "Cell Phone Number")]
        public string Parent_Number { get; set; }

        [Required(ErrorMessage = "Parent's Home address is required"), Display(Name = "Home Address"), DataType(DataType.MultilineText)]
        public string Parent_Adress { get; set; }

        [Required(ErrorMessage = "Parent's email address is required"), Display(Name = "Email Address"), DataType(DataType.EmailAddress)]
        public string Parent_Email { get; set; }
    }
}