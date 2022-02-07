using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Repository
{
   public interface IGenericRepository<T>
    {
        List<T> GetList();
        bool Create(T model);
        T GetById(int? id);
        bool Edit(T model);
        bool Delete(T model);

    }
}
