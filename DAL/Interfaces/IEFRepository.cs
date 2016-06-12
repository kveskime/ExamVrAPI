using System;
using System.Collections.Generic;


namespace DAL.Interfaces
{
    // this is the base repository interface for all EF repositories
    public interface IEFRepository<T> : IDisposable where T : class
    {
        List<T> All { get; }
        T GetById(params object[] id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(params object[] id);
        void SaveChanges();

    }
}