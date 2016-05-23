using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CustomDropdownLists
{
    public class AppStatus
    {
        public string Status { get; set; }

        public List<AppStatus> GetStatuses()
        {
            List<AppStatus> list = new List<AppStatus>();
            list.Add(new AppStatus { Status = "Accepted" });
            list.Add(new AppStatus { Status = "Declined" });
            return list;
        }
    }
}