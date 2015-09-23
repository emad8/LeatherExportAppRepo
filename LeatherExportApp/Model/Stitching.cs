using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Stitching
    {
        public int Id { get; set; }

        public Nullable<int> Employee_ID { get; set; }
        public Nullable<int> Contractor_ID { get; set; }

        public int Pairs_Issued { get; set; }
        public DateTime Date_Issued { get; set; }
        
        public int Pairs_Rec { get; set; }
        public DateTime Date_Rec { get; set; }
        
        public string Description { get; set; }
        
        public Nullable< int> Order_ID { get; set; }
        public Nullable<int> Style_ID { get; set; }
        public Nullable<int> Size_ID { get; set; }
        
        public bool IsDeleted { get; set; }

        /////////////////////////////////////////////

        public string EmployeeName { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string SizeNo { get; set; }
        public string Date { get; set; }

        public int ForEdit { get; set; }
        public int ForDelete { get; set; }

    }
}
