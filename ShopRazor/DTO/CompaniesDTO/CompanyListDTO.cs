using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Netyar.DTO.CompaniesDTO
{
    public class CompanyListDTO
    {
        [Display(Name = "شناسه")]
        public int CompanyID { get; set; }
        [Display(Name = "نام شرکت")]
        public string CompanyTitle { get; set; }
        [Display(Name = "دپارتمان های فعال")]
        public int CountDepartment { get; set; }
    }
}
