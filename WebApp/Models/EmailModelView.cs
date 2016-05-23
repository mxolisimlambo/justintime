using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmailModelView
    {
        //[Required(ErrorMessage = "Enter your Email")]
        //[DataType(DataType.EmailAddress)]
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}