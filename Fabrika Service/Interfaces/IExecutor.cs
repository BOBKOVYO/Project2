using BarService.BindingModels;
using BarService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.Interfaces
{
    public interface IExecutor
    {
        List<ExecutorViewModel> GetList();

        ExecutorViewModel GetElement(int id);

        void AddElement(ExecutorBindModel model);

        void UpdElement(ExecutorBindModel model);

        void DelElement(int id);
    }
}
