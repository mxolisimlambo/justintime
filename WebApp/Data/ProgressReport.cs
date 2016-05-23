using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class ProgressReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarkID { get; set; }

        public string ClassGroupID { get; set; }
        public string Subject_Code { get; set; }
        public int? Term1 { get; set; }
        public int? Term2 { get; set; }
        public int? Term3 { get; set; }
        public int? Term4 { get; set; }

        public string StudentID { get; set; }
        //public virtual StudentTable Student { get; set; }
    }


}
