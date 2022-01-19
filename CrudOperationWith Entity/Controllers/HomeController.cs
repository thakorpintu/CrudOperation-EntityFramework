using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudOperationWith_Entity.Models;

using System.Web.Mvc;

namespace CrudOperationWith_Entity.Controllers
{
    public class HomeController : Controller
    {

        EmployeeDataEntities db = new EmployeeDataEntities();


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EmployeeDataList(int id = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeDataList()
        {
            return Json(db.UserMasters.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeDataCreate(int id)
        {

            var data = db.UserMasters.Where(m => m.Id == id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult EmployeeDeleteData(int Id)
        {
            var delete = db.UserMasters.Where(m => m.Id == Id).FirstOrDefault();

            db.Entry(delete).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();

            return Json(1,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EmployeeDataCreate(UserMaster model)
        {

           
                if (model.Id > 0)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.msg = "Succefully Data....";
                    }
                    else
                    {
                        ViewBag.msg = "Succefully Data....";

                    }

                }
                else
                {

                    db.UserMasters.Add(model);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.msg = "Succefully Data....";
                    }
                    else
                    {
                        ViewBag.msg = "Succefully Data....";

                    }
                }


            


            return View();
        }


    }
}