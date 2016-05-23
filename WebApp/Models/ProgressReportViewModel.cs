using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace WebApp.Models
{
    public class ProgressReportViewModel
    {

        [Key]
    
        public int MarkID { get; set; }
        public string StudentID { get; set; }
        
        public string ClassGroupID { get; set; }
        public string Subject_Code { get; set; }
        
        public int? Term1 { get; set; }
        public int? Term2 { get; set; }
        public int? Term3 { get; set; }
        public int? Term4 { get; set; }

       
      
    }
}