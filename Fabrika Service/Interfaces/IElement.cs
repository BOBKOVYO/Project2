using BarService.BindingModels;
using BarService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService.Interfaces
{
    public interface IElement
    {
        List<ElementViewModel> GetList();

        ElementViewModel GetElement(int id);

        void AddElement(ElementBindModel model);

        void UpdElement(ElementBindModel model);

        void DelElement(int id);
    }
}
