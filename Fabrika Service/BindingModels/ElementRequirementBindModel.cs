using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.BindingModels
{
    public class ElementRequirementsBindModel
    {
        public int ID { get; set; }
        public int SushiID { get; set; }
        public int ElementID { get; set; }
        public int Count { get; set; }
    }
}
