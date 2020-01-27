using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ItemSetupAutomationPlatform.Models.ViewModels
{
    public class IAP_FieldsViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(40)]
        public string FieldName { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string FieldType { get; set; }

        [Required]
        [Display(Name = "Label")]
        public string FieldLabel { get; set; }

        public int? FieldLenght { get; set; }

        public string FieldDataSource { get; set; }

        public string FieldOptions { get; set; }
    }
}