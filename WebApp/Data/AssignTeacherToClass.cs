using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class AssignTeacherToClass
    {
        [key]
        public int Id { get; set; }
        public string StaffNumber { get; set; }
        public virtual Staff staffT { get; set; }
        public string GradeGroupId { get; set; }
        public virtual ClassGroupe GradeGroup {get;set;}

    }
}