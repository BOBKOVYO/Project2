using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.ViewModel
{
    public class StorageViewModel
    {
        public int ID { get; set; }
        public string StorageName { get; set; }
        public List<ElementStorageViewModel> StorageElements { get; set; }
    }
}
