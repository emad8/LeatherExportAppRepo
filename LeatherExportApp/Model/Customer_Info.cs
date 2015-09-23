using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer_Info
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public string Zip_Postal { get; set; }
        public string State_Province { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string ForEdit { get; set; }
        public string ForDelete { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

    }
}
