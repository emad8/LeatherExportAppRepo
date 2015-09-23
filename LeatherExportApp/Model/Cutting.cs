using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cutting
    {
        public int Id { get; set; }
        public Nullable<int> Lot_1 { get; set; }
        public Nullable<int> Pcs { get; set; }
        public Nullable<float> Sqft { get; set; }
        public Nullable<int> Lot_2 { get; set; }
        public Nullable<int> Pcs2 { get; set; }
        public Nullable<float> Sqft2 { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Gp_No { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> Style { get; set; }
        public Nullable<int> Size { get; set; }
        public int Pairs { get; set; }
        public Nullable<int> Employee { get; set; }
        public Nullable<int> Company  { get; set; }
        public Nullable<int> Market { get; set; }
        public Nullable<bool> Is_Paid { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
