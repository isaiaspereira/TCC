
using GarageSmille.Domain.Interface.Infrastructure;
using GarageSmille.Infrastructure.Configuration;
using GarageSmille.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CommonServiceLocator;
using GarageSmille.Domain.Interface.Repositories;

namespace GarageSmille.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> :IDisposable,IRepositoryBase<TEntity> where TEntity : class
    {
        protected  GarageContext _garageContext=new GarageContext();
        //public RepositoryBase()
        //{
        //    var gerenciador = (GerenciadorDeRepositorio)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
        //    _garageContext = gerenciador.Contexto;
        //}
        public void Add(TEntity obj)
        {
            _garageContext.Set<TEntity>().Add(obj);
            _garageContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _garageContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return _garageContext.Set<TEntity>().Find(Id);
        }

        public void Remove(TEntity obj)
        {
            _garageContext.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _garageContext.Entry(obj).State=EntityState.Modified;
        }
    }
}
