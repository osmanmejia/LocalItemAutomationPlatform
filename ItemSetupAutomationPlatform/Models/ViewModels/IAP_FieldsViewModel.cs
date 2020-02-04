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
        public int FieldType { get; set; }

        
        [Display(Name = "Type")]
        public string FieldTypeDescription { get; set; }

        [Required]
        [Display(Name = "Label")]
        public string FieldLabel { get; set; }

        [Display(Name = "Lenght")]
        public int? FieldLenght { get; set; }

        [Display(Name = "Use Data Source")]
        public bool UseDataSource { get; set; }

        [Display(Name = "Data Source")]
        public string FieldDataSource { get; set; }

        public string FieldOptions { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string FieldDescription { get; set; }
    }
}