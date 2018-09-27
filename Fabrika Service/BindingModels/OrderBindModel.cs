using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.BindingModels
{
    public class OrderBindModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int SushiID { get; set; }
        public int? ExecutorID { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
