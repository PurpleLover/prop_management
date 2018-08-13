using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using eAMS.BusinessNew.DbInteract;
using eAMS.Models.Models;

namespace TestMVC45.Controllers
{
    public class PropertyController : Controller
    {
        const string SUCCESSFUL = "Successful";
        const string ERROR = "Error";

        public ViewResult Index()
        {
            return View();
        }

        public JsonResult GetPropertyList()
        {
            var list = new RegisterInteractor().ListProperty();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPropertyById(int propertyId)
        {
            var res = new RegisterInteractor().ListPropertyById(propertyId);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProperty(int propertyId)
        {
            string checkString = new RegisterInteractor().RemoveProperty(propertyId);
            return Json(checkString, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult SavePropertyToDb(PropRegi property)
        {
            string checkString = new RegisterInteractor().SaveProperty(property);
            return Json(checkString, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchPropetyByName(string propertyName)
        {
            var searchResult = new RegisterInteractor().SearchProperty(propertyName);
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }
    }
}
