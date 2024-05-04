using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<bool> Exist(int id);
        //int SaveAll();
    }
}
