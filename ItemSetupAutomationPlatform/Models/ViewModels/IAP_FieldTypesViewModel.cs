using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemSetupAutomationPlatform.Models.ViewModels
{
    public class IAP_FieldTypesViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool UseDataSource { get; set; }

        public bool UseOptions { get; set; }
    }
}