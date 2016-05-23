using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public string Student_Number { get; set; }
     
        public string Student_IDNumber { get; set; }
      
        public string Student_Name { get; set; }
     
        public string Student_Surname { get; set; }
     
        public DateTime Student_Date_Of_Birth { get; set; }
      
        public DateTime Enrolment_Date { get; set; }
      
        public string Student_Gender { get; set; }
    
        public string Student_Religion { get; set; }
       
        public string Student_Adress { get; set; }
      
        public string Grade_id { get; set; }
        public virtual Grade Grades { get; set; }
      
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }
      
        public string Stream_Code { get; set; }
        public virtual StreamTable StreamTable { get; set; }
       
        public string Role { get; set; }
     
        public string status { get; set; }



      
        public string Parent_Identity { get; set; }
        public virtual Parent Parent { get; set; }
      
        public string Title { get; set; }
     
        public string Parent_Name { get; set; }
       
        public string Parent_Surname { get; set; }
     
        public string Parent_Number { get; set; }
      
        public string Parent_Adress { get; set; }
      
        public string Parent_Email { get; set; }
    }
}