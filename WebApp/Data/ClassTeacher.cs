using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data
{
    public class ClassTeacher
    {
        [Key]
        public int ClassTeacher_id { get; set; }
        public virtual Subjects Subject { get; set; }
        public string ClassGroupe_id { get; set; }
        public virtual ClassGroupe ClassGroupe { get; set; }
        public string IdentityNumber { get; set; }
        public virtual Staff Staff { get; set; }
    }

    public class GetAllStudent
    {



    }
}