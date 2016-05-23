using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MakeApplicationViewModel
    {
        [Required(ErrorMessage = "Student's ID number is required"), 
            StringLength(13, ErrorMessage = "Please make sure you enter a correct SA ID Number"), 
            Display(Name = "ID number (South African")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "Student's name is required"), 
            MinLength(3, ErrorMessage = "Please enter at least 3 characters"), 
            Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Student's last name is required"), 
            MinLength(3, ErrorMessage = "Please enter at least 3 characters"), 
            Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Student's date of birth is required"), 
            Display(Name = "Date of Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Student's Gender is required"), 
            Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Student Address"), 
            Display(Name = "Residential address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "A phone numner is required"),
              StringLength(maximumLength:10,MinimumLength =10, ErrorMessage = "Please make sure you enter a correct SA ID Number"),
            Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please upload a copy of the potential learner's report (Supported formats: doc, docx, jpeg, png, pdf. Maximum size: 5MB)"), 
            Display(Name = "Copy of Grade 7 report"), 
            DataType(DataType.Upload)]
        public HttpPostedFileBase ReportCopy { get; set; }
    }

    public class AllApplicationsViewModel
    {
        [Display(Name = "ID number (South African)")]
        public string IdNumber { get; set; }

        [Display(Name = "Student's name")]
        public string FirstName { get; set; }

        [Display(Name = "Student's Last Name")]
        public string Surname { get; set; }

        [Display(Name = "Student's Date of Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Residential address")]
        public string Address { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Copy of Grade 7 report")]
        public byte[] ReportCopy { get; set; }
    }

    public class ViewApplicationViewModel
    {
        public string IdNumber { get; set; }

        public string Status { get; set; }

        public string Phone { get; set; }

        public byte[] ReportCopy { get; set; }
    }
}