using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Packing
    {
        public int Id { get; set; }

        //public int Employee_ID { get; set; }

        public Nullable<int> Order_ID { get; set; }
        public Nullable<int> Style_ID { get; set; }
        public Nullable<int> Size_ID { get; set; }

        public int Pairs_Packed { get; set; }
        public DateTime Date { get; set; }
        
        public string Description { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
