using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItemSetupAutomationPlatform.Models.ViewModels;

namespace ItemSetupAutomationPlatform.Controllers
{
    public class IAP_FieldTypesController : Controller
    {
        // GET: IAP_FieldTypes
        public ActionResult Index()
        {
            IAP_FieldTypesViewModel fieldTypes = new IAP_FieldTypesViewModel();
            //fieldTypes.FieldTypes = PopulateFieldTypes();
            return View(fieldTypes);
        }

        private List<SelectListItem> PopulateFieldTypes()
        {
            throw new NotImplementedException();
        }
    }
}