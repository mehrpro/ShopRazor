using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Netyar.DTO.CompaniesDTO
{
    public class CompanyCreateDTO
    {
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "عنوان شرکت")]
        [MinLength(5, ErrorMessage = "{0} نباید کمتر از 5 حرف باشد")]
        [MaxLength(100, ErrorMessage = "{0}  نباید بیشتر از 100 حرف باشد")]
        public string CompanyTitle { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(150, ErrorMessage = "{0}  نباید بیشتر از 150 حرف باشد")]
        public string Description { get; set; }
    }
}
