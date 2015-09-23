using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Delivery

    {
        public int Id { get; set; }
        public int LotID { get; set; }
        public string Name { get; set; }
        public int Pcs { get; set; }
        public float Sqft { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public int ForEdit { get; set; }
        public int ForDelete { get; set; }

        
    }
}
