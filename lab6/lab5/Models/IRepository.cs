using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models
{
    interface IRepository<T>
    {
        List<T> GetAll();
    }
}
