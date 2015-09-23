using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Delivery_Location
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Code { get; set; }
        public string Address { get; set; }
        public string ZP { get; set; }
        public string SP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public string ForEdit { get; set; }
        public string ForDelete { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
