using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.BindingModels
{
    public class SushiBindModel
    {
        public int ID { set; get; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
        public List<ElementRequirementsBindModel> ElementRequirements { get; set; }
    }
}
