using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Contact
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Code { get; set; }
        public string Name { get; set; }
        public string Tel_No { get; set; }
        public string Mob_No { get; set; }
        public string Designation { get; set; }
        public string Extention_No { get; set; }
        public string Email { get; set; } 
        public string Remarks { get; set; }
        public string ForEdit { get; set; }
        public string ForDelete { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

    }
}
