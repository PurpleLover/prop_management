using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using eAMS.BusinessNew.DbInteract;
using eAMS.Models.Models;

namespace TestMVC45.Controllers
{
    public class MaintainanceController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public JsonResult GetListMaintainance()
        {
            var list = new MaintainancesInteractor().ListMaintained();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
