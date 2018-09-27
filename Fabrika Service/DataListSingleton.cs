using BarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Element> Elements { get; set; }

        public List<Executor> Executors { get; set; }

        public List<Order> Orders { get; set; }

        public List<Sushi> Sushis { get; set; }

        public List<ElementRequirement> ElementRequirements { get; set; }

        public List<Storage> Storages { get; set; }

        public List<ElementStorage> ElementStorages { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            Executors = new List<Executor>();
            Orders = new List<Order>();
            Sushis = new List<Sushi>();
            ElementRequirements = new List<ElementRequirement>();
            Storages = new List<Storage>();
            ElementStorages = new List<ElementStorage>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}