using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ClassTeacherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClassTeacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllClass(string Group ,string stud)
        {

            var classList =new List<string>();

            var classquery = from y in db.Marks
                             orderby y.ClassGroupID
                             select y.ClassGroupID;

            classList.AddRange(classquery.Distinct());
            ViewBag.Group = new SelectList(classList);

            List<Mark> emt = new List<Mark>();
            var tt = from t in db.Marks
                     select t;

            if(!String.IsNullOrEmpty(Group))
            {
                tt = tt.Where(re => re.ClassGroupID == Group);
            }

            if (!String.IsNullOrEmpty(stud))
            {
                tt = tt.Where(re => re.StudentID.Contains(stud));
            }

            var myEmpList = tt.ToList();

            foreach (var empData in myEmpList)
            {
                emt.Add(new Mark()
                {
                    Markid = empData.Markid,
                    StudentID = empData.StudentID,
                    ClassGroupID = empData.ClassGroupID,
                    Subject_Code = empData.Subject_Code,
                    Term1 = empData.Term1,
                    Term2 = empData.Term2,
                    Term3 = empData.Term3,
                    Term4 = empData.Term4
                });
            }
                return View(myEmpList);
        }

    }
}