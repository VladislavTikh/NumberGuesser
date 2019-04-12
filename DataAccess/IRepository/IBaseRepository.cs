using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
            void Save(T model);

            T Get(long id);
    }
}
