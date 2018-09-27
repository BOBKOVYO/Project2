using BarService.BindingModels;
using BarService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.Interfaces
{
    public interface ICustomer
    {
        List<CustomerViewModel> GetList();

        CustomerViewModel GetElement(int id);

        void AddElement(CustomerBindModel model);

        void UpdElement(CustomerBindModel model);

        void DelElement(int id);
    }
}
