using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class AssignTeacherToSubject
    {
        [key]
        public int Id { get; set; }
        public string StaffNumber { get; set; }
        public virtual Staff staffT { get; set; }
        public string GradeGroupId { get; set; }
        public virtual ClassGroupe GradeGroup { get; set; }
        public string SubjectCode { get; set; }
        public virtual Subjects SubjectT { get; set; }

    }
}