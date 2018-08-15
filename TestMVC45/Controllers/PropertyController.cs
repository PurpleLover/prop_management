using eAMS.BusinessNew.DbInteract;
using eAMS.BusinessNew.Helper;
using eAMS.Models.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

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

        public JsonResult GetPropertyList(int pageNumber = 1, int pageSize = 5)
        {
            var list = new RegisterInteractor().ListProperty();
            var pagedData = Pagination.PageResult(list, pageNumber, pageSize);
            return Json(pagedData, JsonRequestBehavior.AllowGet);
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
        
        public JsonResult SavePropertyToDb(int propertyId, string propertyCode, string propertyName, string propertyBrand, string propertyYear, bool propertyIsMaintained, int? propertyMCost)
        {
            PropRegi property = new PropRegi
            {
                ID = propertyId,
                Code = propertyCode,
                Name = propertyName,
                Brand = propertyBrand,
                Year = propertyYear,
                IsMaitained = propertyIsMaintained,
                MCost = propertyMCost
            };
            string checkString = new RegisterInteractor().SaveProperty(property);
            return Json(checkString, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchPropety(string searchString, string searchBy)
        {
            var searchResult = new RegisterInteractor().SearchProperty(searchString, searchBy);
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }

        /*
         * @Mixin means Property and Maintain
         * Only show which has IsMaintained
         * @params: propertyNeed is only for safety checked
         */
        public ContentResult GetMixin(int propertyId, bool propertyNeed = true)
        {
            if (propertyNeed)
            {

                var list = new RegisterInteractor().ListMixin(propertyId);
                var lol = JsonConvert.SerializeObject(list,
                    Formatting.None,
                    new JsonSerializerSettings() {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                return Content(lol, "application/json");
            }
            string checkString = ERROR;
            return Content(checkString);
        }
    }
}
