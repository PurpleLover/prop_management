using System.Web.Mvc;
using eAMS.BusinessNew.DbInteract;
using eAMS.Models.Models;

namespace TestMVC45.Controllers
{
    public class MaintainController : Controller
    {
        public ViewResult Index()
        {
            var list = new MaintainancesInteractor().ListMaintainActions();

            return View(list);
        }

        public JsonResult GetListMaintainance()
        {
            var list = new MaintainancesInteractor().ListMaintainActions();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveAction(PropMaint propMaint)
        {
            var checkString = new MaintainancesInteractor().SaveChanges(propMaint);
            return Json(checkString, JsonRequestBehavior.AllowGet);
        }
    }
}
