using System;
using System.Web.Mvc;
using CS.Models;

namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            if(Session["TypedListModel"] == null)
                Session["TypedListModel"] = InMemoryModel.GetTypedListModel();
            
            return View(Session["TypedListModel"]);
        }

        public ActionResult TypedListDataBindingPartial() {
            return PartialView(Session["TypedListModel"]);
        }
    }
}