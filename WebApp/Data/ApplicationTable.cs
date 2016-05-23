using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class ApplicationTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Applicant_IDNumber { get; set; }
        public string Applicant_Name { get; set; }
        public string Applicant_Surname { get; set; }
        public DateTime Applicant_Date_Of_Birth { get; set; }
        public string Applicant_Gender { get; set; }
        public string Applicant_Religion { get; set; }
        public string Applicant_Adress { get; set; }
        public string Application_Grade { get; set; }
        public int Maths_Mark { get; set; }
        public int English_Mark { get; set; }
        public int ZuluHomeLanguage_Mark { get; set; }
        public string status { get; set; }
        public string Title { get; set; }
        public string Parent_Name { get; set; }
        public string Parent_Surname { get; set; }
        public string Parent_Number { get; set; }
        public string Parent_Adress { get; set; }
        public string Parent_Email { get; set; }
    }
}