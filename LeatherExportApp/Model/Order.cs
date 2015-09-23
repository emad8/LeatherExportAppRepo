using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Order_No { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Vendor_ID { get; set; }
        public string DateString { get; set; }
        public DateTime Date_Of_shipping { get; set; }
        public bool IsDeleted { get; set; }
        public int ForEdit { get; set; }
        public int ForDelete { get; set; }
    }
}
