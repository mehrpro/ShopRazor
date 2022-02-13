using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentTitle { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime ModifidDatetime { get; set; }
        public DateTime DeleteDatetime { get; set; }

        public int CompanyID_FK { get; set; }
        public Company Company { get; set; }

    }
}
