using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ReportViewModel
    {
        [Key]
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string StreamCode { get; set; }
        public string Subject { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
    }
}