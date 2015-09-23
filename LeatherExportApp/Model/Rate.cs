using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rate
    {
        public int Id { get; set; }
        public float Standard_Value { get; set; }
        public int Style_ID { get; set; }
        public string Name { get; set; }
        public int Size_ID { get; set; }
        public int No { get; set; }
        public Nullable<float> Cutting_Rate { get; set; }
        public Nullable<float> Elastic_Stitching { get; set; }
        public Nullable<float> OverLock { get; set; }
        public Nullable<float> Contractor_Commission { get; set; }
        public Nullable<float> BindingRate { get; set; }
        public Nullable<float> GloveStitchingRate { get; set; }
        public bool IsDeleted { get; set; }
        public int ForEdit { get; set; }
        public int ForDelete { get; set; }
    }
}
