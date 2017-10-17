using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Domain.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        void Dispose();
    }
}
