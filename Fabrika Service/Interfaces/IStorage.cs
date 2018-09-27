using BarService.BindingModels;
using BarService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.Interfaces
{
    public interface IStorage
    {
        List<StorageViewModel> GetList();

        StorageViewModel GetElement(int id);

        void AddElement(StorageBindModel model);

        void UpdElement(StorageBindModel model);

        void DelElement(int id);
    }
}
