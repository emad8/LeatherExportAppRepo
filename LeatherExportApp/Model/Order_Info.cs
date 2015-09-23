using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order_Info
    {
        public int Order { get; set; }
        public int No_Order { get; set; }
        public int No_Order_Rem { get; set; }

        public int Style { get; set; }
        public int Size { get; set; }

        public string Description { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
