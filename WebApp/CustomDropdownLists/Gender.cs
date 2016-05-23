using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CustomDropdownLists
{
    public class Gender
    {
        public string GenderTitle { get; set; }

        public List<Gender> GetGenders()
        {
            List<Gender> list = new List<Gender>();
            list.Add(new Gender { GenderTitle = "Male" });
            list.Add(new Gender { GenderTitle = "Female" });
            return list;
        }
    }
}