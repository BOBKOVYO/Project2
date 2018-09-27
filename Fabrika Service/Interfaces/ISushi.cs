using BarService.BindingModels;
using BarService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.Interfaces
{
    public interface ISushi
    {
        List<SushiViewModel> GetList();

        SushiViewModel GetElement(int id);

        void AddElement(SushiBindModel model);

        void UpdElement(SushiBindModel model);

        void DelElement(int id);
    }
}
