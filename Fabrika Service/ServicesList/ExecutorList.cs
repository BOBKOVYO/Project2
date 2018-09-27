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
    public class ExecutorList : IExecutor
    {
        private DataListSingleton source;

        public ExecutorList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(ExecutorBindModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Executors.Count; ++i)
            {
                if (source.Executors[i].ID > maxId)
                {
                    maxId = source.Executors[i].ID;
                }
                if (source.Executors[i].ExecutorFIO == model.ExecutorFIO)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            source.Executors.Add(new Executor
            {
                ID = maxId + 1,
                ExecutorFIO = model.ExecutorFIO
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Executors.Count; ++i)
            {
                if (source.Executors[i].ID == id)
                {
                    source.Executors.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public ExecutorViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Executors.Count; ++i)
            {
                if (source.Executors[i].ID == id)
                {
                    return new ExecutorViewModel
                    {
                        ID = source.Executors[i].ID,
                        ExecutorFIO = source.Executors[i].ExecutorFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ExecutorViewModel> GetList()
        {
            List<ExecutorViewModel> result = new List<ExecutorViewModel>();
            for (int i = 0; i < source.Executors.Count; ++i)
            {
                result.Add(new ExecutorViewModel
                {
                    ID = source.Executors[i].ID,
                    ExecutorFIO = source.Executors[i].ExecutorFIO
                });
            }
            return result;
        }

        public void UpdElement(ExecutorBindModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Executors.Count; ++i)
            {
                if (source.Executors[i].ID == model.ID)
                {
                    index = i;
                }
                if (source.Executors[i].ExecutorFIO == model.ExecutorFIO &&
                    source.Executors[i].ID != model.ID)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Executors[index].ExecutorFIO = model.ExecutorFIO;
        }
    }
}
