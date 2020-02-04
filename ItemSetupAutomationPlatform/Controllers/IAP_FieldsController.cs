using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItemSetupAutomationPlatform.Models;
using ItemSetupAutomationPlatform.Models.ViewModels;
namespace ItemSetupAutomationPlatform.Controllers
{
    public class IAP_FieldsController : Controller
    {
        // GET: IAP_Fields
        public ActionResult Index()
        {
            List<IAP_FieldsViewModel> fieldsIAP;
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                fieldsIAP = (from d in db.IAP_Fields
                             join c in db.IAP_FieldTypes on d.FieldType equals c.Id
                             select new IAP_FieldsViewModel
                             {
                                 Id = d.Id,
                                 FieldName = d.FieldName,
                                 FieldType = d.FieldType,
                                 FieldTypeDescription = c.Description,
                                 FieldLabel = d.FieldLabel,
                                 FieldDescription = d.FieldDescription,
                                 FieldLenght = d.FieldLenght,
                                 FieldDataSource = d.FieldDataSource,
                                 FieldOptions = d.FieldOptions
                             }).ToList();
            }

            return View(fieldsIAP);
        }

        public ActionResult NewField()
        {
            List<IAP_FieldTypesViewModel> fieldTypes = new List<IAP_FieldTypesViewModel>();
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                fieldTypes =
                (
                    from d in db.IAP_FieldTypes
                    select new IAP_FieldTypesViewModel
                    {
                        Id = d.Id,
                        Description = d.Description
                    }).ToList();

            }

            List<SelectListItem> items = fieldTypes.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Description.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public ActionResult NewField(IAP_FieldsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
                    {
                        var IAP_field = new Models.IAP_Fields();
                        IAP_field.Id = model.Id;
                        IAP_field.FieldName = model.FieldName;
                        IAP_field.FieldType = model.FieldType;
                        IAP_field.FieldLabel = model.FieldLabel;
                        IAP_field.FieldDescription = model.FieldDescription;
                        IAP_field.FieldLenght = model.FieldLenght;
                        IAP_field.FieldDataSource = model.FieldDataSource;
                        IAP_field.FieldOptions = model.FieldOptions;
                        db.IAP_Fields.Add(IAP_field);
                        db.SaveChanges();
                    }

                    return Redirect("~/IAP_Fields/");
                }

                return View(model);

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public ActionResult EditField(string fieldName)
        {
            IAP_FieldsViewModel model = new IAP_FieldsViewModel();
            List<IAP_FieldTypesViewModel> fieldTypes = new List<IAP_FieldTypesViewModel>();
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                fieldTypes =
                (
                    from d in db.IAP_FieldTypes
                    select new IAP_FieldTypesViewModel
                    {
                        Id = d.Id,
                        Description = d.Description
                    }).ToList();

            }

            List<SelectListItem> items = fieldTypes.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Description.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                var oField = db.IAP_Fields.Find(fieldName);
                model.Id = oField.Id;
                model.FieldName = oField.FieldName;
                model.FieldLabel = oField.FieldLabel;
                model.FieldDescription = oField.FieldDescription;
                model.FieldType = oField.FieldType;
                model.FieldLenght = oField.FieldLenght;
                model.FieldDataSource = oField.FieldDataSource;
                model.FieldOptions = oField.FieldOptions;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditField(IAP_FieldsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
                    {
                        var IAP_field = db.IAP_Fields.Find(model.FieldName);
                        //IAP_field.Id = model.Id;
                        IAP_field.FieldName = model.FieldName;
                        IAP_field.FieldType = model.FieldType;
                        IAP_field.FieldLabel = model.FieldLabel;
                        IAP_field.FieldDescription = model.FieldDescription;
                        IAP_field.FieldLenght = model.FieldLenght;
                        IAP_field.FieldDataSource = model.FieldDataSource;
                        IAP_field.FieldOptions = model.FieldOptions;

                        db.Entry(IAP_field).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/IAP_Fields/");
                }

                return View(model);

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        
        [HttpGet]
        public ActionResult DeleteField(string fieldName)
        {
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                var oField = db.IAP_Fields.Find(fieldName);
                db.IAP_Fields.Remove(oField);
                db.SaveChanges();
            }
            return Redirect("~/IAP_FIelds/");
        }

        public ActionResult ValidateDataSourceRequired(int fieldType)
        {
            bool? dataSourceRequired = false;
            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                dataSourceRequired = db.IAP_FieldTypes.Find(fieldType).UseDataSource;
            }

            return View(dataSourceRequired);
        }
    }
}