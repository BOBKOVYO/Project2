using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarService.BindingModels;
using BarService.Interfaces;
using BarService.ViewModel;
using BarModel;

namespace BarService.ServicesList
{
    public class ElementList : IElement
    {
        private DataListSingleton source;

        public ElementList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(ElementBindModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].ID > maxId)
                {
                    maxId = source.Elements[i].ID;
                }
                if (source.Elements[i].ElementName == model.ElementName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            source.Elements.Add(new Element
            {
                ID = maxId + 1,
                ElementName = model.ElementName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].ID == id)
                {
                    source.Elements.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public ElementViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].ID == id)
                {
                    return new ElementViewModel
                    {
                        ID = source.Elements[i].ID,
                        ElementName = source.Elements[i].ElementName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ElementViewModel> GetList()
        {
            List<ElementViewModel> result = new List<ElementViewModel>();
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                result.Add(new ElementViewModel
                {
                    ID = source.Elements[i].ID,
                    ElementName = source.Elements[i].ElementName
                });
            }
            return result;
        }

        public void UpdElement(ElementBindModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Elements.Count; ++i)
            {
                if (source.Elements[i].ID == model.ID)
                {
                    index = i;
                }
                if (source.Elements[i].ElementName == model.ElementName &&
                    source.Elements[i].ID != model.ID)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Elements[index].ElementName = model.ElementName;
        }
    }
}
