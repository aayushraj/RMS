using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Service
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        T Create(T model);
        T GetById(int? id);
        T Edit(T model);
        T Delete(T model);
    }
}
