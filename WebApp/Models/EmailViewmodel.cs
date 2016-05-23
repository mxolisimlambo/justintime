using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmailViewmodel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string To { get; set; }
    }
}