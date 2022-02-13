using System;
using System.Collections.Generic;

namespace Entities
{
    public class Company
    {

        public Company()
        {
            Departments = new HashSet<Department>();
        }

        public int CompanyID { get; set; }
        public string CompanyTitle { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime ModifidDatetime { get; set; }
        public DateTime DeleteDatetime { get; set; }



        public virtual ICollection<Department> Departments { get; set; }

    }
}
