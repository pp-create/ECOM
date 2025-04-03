using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.interfaces
{
 public   interface IGenericRepositry<T> where T :class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task Addasync(T entity);
        Task<T> GetIdAsync(int id);  // Fixed return type
        Task<T> GetIdAsync(int id, params Expression<Func<T, object>>[] includes);  // Fixed return type

        Task<int> count();
        Task Updateasync(T entity);
        Task Deleteasync(int id);
    }
}

