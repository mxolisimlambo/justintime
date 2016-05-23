using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Subjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Subject_Code { get; set; }  
        public string DescriptiveTitle { get; set; }  
        public string Stream_Code { get; set; }
        public StreamTable StreamTable { get; set; }
    }
}