using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CuttingOutStock
    {
        public int Id { get; set; }
        public int Lot_1 { get; set; }
        public Nullable<int> Lot_2 { get; set; }
        public int Pcs { get; set; }
        public float Sqft { get; set; }
        public Nullable<int> Pcs2 { get; set; }
        public Nullable<float> Sqft2 { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Company { get; set; }
        public bool IsDeleted { get; set; }

        public int ForEdit { get; set; }
        public int ForDelete { get; set; }
        public string CompanyName { get; set; }
        public string Lot_1Name { get; set; }
        public string Lot_2Name { get; set; }
        public string Date2 { get; set; }
    }
}
