using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Netyar.DTO.CompaniesDTO
{
    public class CompanyDeleteDTO
    {
        [Display(AutoGenerateField = false)]
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "عنوان شرکت")]
        [MinLength(5, ErrorMessage = "{0} نباید کمتر از 5 حرف باشد")]
        [MaxLength(100, ErrorMessage = "{0}  نباید بیشتر از 100 حرف باشد")]
        public string CompanyTitle { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(150, ErrorMessage = "{0}  نباید بیشتر از 150 حرف باشد")]
        public string Description { get; set; }
        [Display(AutoGenerateField = false)]
        public bool IsActive { get; set; }
        [Display(AutoGenerateField = false)]
        public bool IsDelete { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime CreateDatetime { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime ModifidDatetime { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime DeleteDatetime { get; set; }
        [Display(Name = "دپارتمان های شرکت")]
        public IEnumerable<Department> Departments { get; set; }
    }
}