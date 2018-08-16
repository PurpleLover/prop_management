using eAMS.BusinessNew.DbInteract;
using eAMS.BusinessNew.Helper;
using eAMS.Models.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using TestMVC45.Controllers.Helper;

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
            bool SafetyCheck = new DataValidation().CheckPropertyId(propertyId);
            if (SafetyCheck)
            {
                var res = new RegisterInteractor().ListPropertyById(propertyId);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            return Json(ERROR, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProperty(int propertyId)
        {
            bool SafetyCheck = new DataValidation().CheckPropertyId(propertyId);
            if (SafetyCheck)
            {
                string checkString = new RegisterInteractor().RemoveProperty(propertyId);
                return Json(checkString, JsonRequestBehavior.AllowGet);
            }
            return Json(ERROR, JsonRequestBehavior.AllowGet);
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
            bool SafetyCheck = new DataValidation().Check(property);

            if (SafetyCheck)
            {
                string checkString = new RegisterInteractor().SaveProperty(property);
                return Json(checkString, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(ERROR, JsonRequestBehavior.AllowGet);
            }
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
            bool SafetyCheck = new DataValidation().CheckPropertyId(propertyId);
            if (propertyNeed && SafetyCheck)
            {
                var list = new RegisterInteractor().ListMixin(propertyId);
                var lol = JsonConvert.SerializeObject(list,
                    Formatting.None,
                    new JsonSerializerSettings() {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                return Content(lol, "application/json");
            }
            return Content(ERROR);
        }

        public JsonResult GetPropertyByCode(string propertyCode)
        {
            bool SafetyCheck = new DataValidation().CheckRequired(propertyCode);
            if (SafetyCheck)
            {
                var list = new RegisterInteractor().FindPropertyByCode(propertyCode);
                if (list != null)
                {
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                return Json(ERROR, JsonRequestBehavior.AllowGet);
            }
            return Json(ERROR, JsonRequestBehavior.AllowGet);
        }
    }
}
