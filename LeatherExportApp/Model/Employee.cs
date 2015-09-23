using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact_No { get; set; }
        public string NIC_No { get; set; }
        public int Category { get; set; }
        public byte[] Picture { get; set; }
        public Nullable < float > RatePer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
