using BarService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarService.BindingModels;
using BarService.ViewModel;
using BarModel;
using BarService;

namespace BarService.ServicesList
{
    public class StorageList : IStorage
    {
        private DataListSingleton source;

        public StorageList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(StorageBindModel model)
        {
            int maxID = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].ID > maxID)
                {
                    maxID = source.Storages[i].ID;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                ID = maxID + 1,
                StorageName = model.StorageName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ElementStorages.Count; ++i)
            {
                if (source.ElementStorages[i].StorageID == id)
                {
                    source.ElementStorages.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].ID == id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<ElementStorageViewModel> ElementStorages = new List<ElementStorageViewModel>();
                for (int j = 0; j < source.ElementStorages.Count; ++j)
                {
                    if (source.ElementStorages[j].StorageID == source.Storages[i].ID)
                    {
                        string elementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementStorages[j].ElementID == source.Elements[k].ID)
                            {
                                elementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementStorages.Add(new ElementStorageViewModel
                        {
                            ID = source.ElementStorages[j].ID,
                            StorageID = source.ElementStorages[j].StorageID,
                            ElementID = source.ElementStorages[j].ElementID,
                            ElementName = elementName,
                            Count = source.ElementStorages[j].Count
                        });
                    }
                }
                if (source.Storages[i].ID == id)
                {
                    return new StorageViewModel
                    {
                        ID = source.Storages[i].ID,
                        StorageName = source.Storages[i].StorageName,
                        StorageElements = ElementStorages
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<ElementStorageViewModel> ElementStorages = new List<ElementStorageViewModel>();
                for (int j = 0; j < source.ElementStorages.Count; ++j)
                {
                    if (source.ElementStorages[j].StorageID == source.Storages[i].ID)
                    {
                        string ElementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementStorages[j].ElementID == source.Elements[k].ID)
                            {
                                ElementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementStorages.Add(new ElementStorageViewModel
                        {
                            ID = source.ElementStorages[j].ID,
                            StorageID = source.ElementStorages[j].StorageID,
                            ElementID = source.ElementStorages[j].ElementID,
                            ElementName = ElementName,
                            Count = source.ElementStorages[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    ID = source.Storages[i].ID,
                    StorageName = source.Storages[i].StorageName,
                    StorageElements = ElementStorages
                });
            }
            return result;
        }

        public void UpdElement(StorageBindModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].ID == model.ID)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                    source.Storages[i].ID != model.ID)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;
        }
    }
}

