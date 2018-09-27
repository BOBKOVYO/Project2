using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.ViewModel
{
    public class SushiViewModel
    {
        public int ID { get; set; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
        public List<ElementRequirementsViewModel> ElementRequirements { get; set; }
    }
}
