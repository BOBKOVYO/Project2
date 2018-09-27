using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.ViewModel
{
    public class ElementRequirementsViewModel
    {
        public int ID { get; set; }
        public int SushiID { get; set; }
        public int ElementID { get; set; }
        public string ElementName { get; set; }
        public int Count { get; set; }
    }
}
