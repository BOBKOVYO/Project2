using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.BindingModels
{
    public class ElementStorageBindModel
    {
        public int ID { get; set; }
        public int StorageID { get; set; }
        public int ElementID { get; set; }
        public int Count { get; set; }
    }
}
