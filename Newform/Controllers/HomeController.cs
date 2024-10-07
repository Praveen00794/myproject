using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newform.Models;
using Newform.DAL;
namespace Newform.Controllers
{
    public class HomeController : Controller
    {
        MyprojectDAL ObjDAL = new MyprojectDAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult EmpHome()
        {
            IList<Employeeinfo> lst = new List<Employeeinfo>();
            lst = ObjDAL.GetEmployeeinfos();
            ViewBag.Grd = lst;
            return View();
        }
        public ActionResult Insertpage()
        {

            Employeeinfo obj =new Employeeinfo();
            if (TempData["EmployeeInfo"]!=null)
            {
                obj = (Employeeinfo)TempData["EmployeeInfo"];
            }
            obj.Departmentmaster = ObjDAL.GetDepartmentcombo(); 
            return View(obj);
        }
        [HttpPost]
        public ActionResult Insertpage(Employeeinfo model )
        {
            if (ModelState.IsValid)
            {
                
                    ObjDAL.Insertemployee(model);
                
                
            }
            else
            {
                Employeeinfo obj = new Employeeinfo();
                obj.Departmentmaster = ObjDAL.GetDepartmentcombo();
                return View(obj);
            }
            return RedirectToAction("EmpHome");
        }
        public ActionResult Editemployee(int id)
        {
            Employeeinfo obj = new Employeeinfo();
            obj = ObjDAL.editemp(id);
            TempData["EmployeeInfo"] = obj;
            return RedirectToAction("Insertpage");
        }
        public ActionResult Deleteemployee(int id)
        {
            ObjDAL.DeleteEmp(id);
            return RedirectToAction("emphome");
        }
    }
}