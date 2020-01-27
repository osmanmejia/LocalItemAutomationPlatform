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
                             select new IAP_FieldsViewModel
                             {
                                 Id = d.Id,
                                 FieldName = d.FieldName,
                                 FieldType = d.FieldType,
                                 FieldLabel = d.FieldLabel,
                                 FieldLenght = d.FieldLenght,
                                 FieldDataSource = d.FieldDataSource,
                                 FieldOptions = d.FieldOptions
                             }).ToList();
            }

            return View(fieldsIAP);
        }

        public ActionResult NewField()
        {
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

            using (ItemAutomationPlatformEntities db = new ItemAutomationPlatformEntities())
            {
                var oField = db.IAP_Fields.Find(fieldName);
                model.Id = oField.Id;
                model.FieldName = oField.FieldName;
                model.FieldLabel = oField.FieldLabel;
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
    }
}