using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labxml
{
    class WorkerList
    {
        public List<Worker> list;
        public WorkerList()
        {
            list = new List<Worker>();
        }
        public void AddWorker(Worker worker)
        {
            list.Add(worker);
        }
        public List<Worker> GetList()
        {
            return list;
        }
    }
}
