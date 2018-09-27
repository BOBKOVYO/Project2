using BarService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarService.BindingModels;
using BarService.ViewModel;
using BarModel;

namespace BarService.ServicesList
{
    public class SushiList : ISushi
    {
        private DataListSingleton source;

        public SushiList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(SushiBindModel model)
        {
            int maxID = 0;
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                if (source.Sushis[i].ID > maxID)
                {
                    maxID = source.Sushis[i].ID;
                }
                if (source.Sushis[i].SushiName == model.SushiName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Sushis.Add(new Sushi
            {
                ID = maxID + 1,
                SushiName = model.SushiName,
                Price = model.Price
            });
            int maxPCID = 0;
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].ID > maxPCID)
                {
                    maxPCID = source.ElementRequirements[i].ID;
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                for (int j = 1; j < model.ElementRequirements.Count; ++j)
                {
                    if (model.ElementRequirements[i].ElementID ==
                        model.ElementRequirements[j].ElementID)
                    {
                        model.ElementRequirements[i].Count +=
                            model.ElementRequirements[j].Count;
                        model.ElementRequirements.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                source.ElementRequirements.Add(new ElementRequirement
                {
                    ID = ++maxPCID,
                    SushiID = maxID + 1,
                    ElementID = model.ElementRequirements[i].ElementID,
                    Count = model.ElementRequirements[i].Count
                });
            }
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].SushiID == id)
                {
                    source.ElementRequirements.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                if (source.Sushis[i].ID == id)
                {
                    source.Sushis.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public SushiViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                List<ElementRequirementsViewModel> ElementRequirements = new List<ElementRequirementsViewModel>();
                for (int j = 0; j < source.ElementRequirements.Count; ++j)
                {
                    if (source.ElementRequirements[j].SushiID == source.Sushis[i].ID)
                    {
                        string ElementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementRequirements[j].ElementID == source.Elements[k].ID)
                            {
                                ElementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementRequirements.Add(new ElementRequirementsViewModel
                        {
                            ID = source.ElementRequirements[j].ID,
                            SushiID = source.ElementRequirements[j].SushiID,
                            ElementID = source.ElementRequirements[j].ElementID,
                            ElementName = ElementName,
                            Count = source.ElementRequirements[j].Count
                        });
                    }
                }
                if (source.Sushis[i].ID == id)
                {
                    return new SushiViewModel
                    {
                        ID = source.Sushis[i].ID,
                        SushiName = source.Sushis[i].SushiName,
                        Price = source.Sushis[i].Price,
                        ElementRequirements = ElementRequirements
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public List<SushiViewModel> GetList()
        {
            List<SushiViewModel> result = new List<SushiViewModel>();
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                List<ElementRequirementsViewModel> ElementRequirements = new List<ElementRequirementsViewModel>();
                for (int j = 0; j < source.ElementRequirements.Count; ++j)
                {
                    if (source.ElementRequirements[j].SushiID == source.Sushis[i].ID)
                    {
                        string ElementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementRequirements[j].ElementID == source.Elements[k].ID)
                            {
                                ElementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementRequirements.Add(new ElementRequirementsViewModel
                        {
                            ID = source.ElementRequirements[j].ID,
                            SushiID = source.ElementRequirements[j].SushiID,
                            ElementID = source.ElementRequirements[j].ElementID,
                            ElementName = ElementName,
                            Count = source.ElementRequirements[j].Count
                        });
                    }
                }
                result.Add(new SushiViewModel
                {
                    ID = source.Sushis[i].ID,
                    SushiName = source.Sushis[i].SushiName,
                    Price = source.Sushis[i].Price,
                    ElementRequirements = ElementRequirements
                });
            }
            return result;
        }

        public void UpdElement(SushiBindModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                if (source.Sushis[i].ID == model.ID)
                {
                    index = i;
                }
                if (source.Sushis[i].SushiName == model.SushiName &&
                    source.Sushis[i].ID != model.ID)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Sushis[index].SushiName = model.SushiName;
            source.Sushis[index].Price = model.Price;
            int maxPCID = 0;
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].ID > maxPCID)
                {
                    maxPCID = source.ElementRequirements[i].ID;
                }
            }
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].SushiID == model.ID)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ElementRequirements.Count; ++j)
                    {
                        if (source.ElementRequirements[i].ID == model.ElementRequirements[j].ID)
                        {
                            source.ElementRequirements[i].Count = model.ElementRequirements[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        source.ElementRequirements.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                if (model.ElementRequirements[i].ID == 0)
                {
                    for (int j = 0; j < source.ElementRequirements.Count; ++j)
                    {
                        if (source.ElementRequirements[j].SushiID == model.ID &&
                            source.ElementRequirements[j].ElementID == model.ElementRequirements[i].ElementID)
                        {
                            source.ElementRequirements[j].Count += model.ElementRequirements[i].Count;
                            model.ElementRequirements[i].ID = source.ElementRequirements[j].ID;
                            break;
                        }
                    }
                    if (model.ElementRequirements[i].ID == 0)
                    {
                        source.ElementRequirements.Add(new ElementRequirement
                        {
                            ID = ++maxPCID,
                            SushiID = model.ID,
                            ElementID = model.ElementRequirements[i].ElementID,
                            Count = model.ElementRequirements[i].Count
                        });
                    }
                }
            }
        }
    }
}