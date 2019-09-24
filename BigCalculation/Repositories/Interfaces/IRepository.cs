using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BigCalculation.Models;

namespace BigCalculation.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        IEnumerable<T> GetAll();
        T Find(string id);
        void Update(T entity);
        void AddOrUpdate(T entity);
        void RemoveAll(List<T> entities);
        void Delete(T entity);
        void Delete(List<T> entities);
        void SaveChanges();
        void Delete(string id);
        void Insert(List<T> models);
        void ExecuteQuery(string query);
    }
}