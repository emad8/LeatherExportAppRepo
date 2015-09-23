using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rejection
    {
        public int Id { get; set; }

        public Nullable<int> Cutter_ID { get; set; }
        public Nullable<int> Stitcher_ID { get; set; }

        public Nullable<int> Order_ID { get; set; }
        public Nullable<int> Style_ID { get; set; }
        public Nullable<int> Size_ID { get; set; }

        public Nullable<int> Pairs { get; set; }
        public Nullable<int> Right { get; set; }
        public Nullable<int> Left { get; set; }
        
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
