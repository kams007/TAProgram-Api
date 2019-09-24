using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BigCalculation.DBContext;
using BigCalculation.Models;
using BigCalculation.Repositories.Interfaces;

namespace BigCalculation.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CalculationDbContext _dbContext;
        public Repository() :
            this(new CalculationDbContext())
        {

        }

        private Repository(CalculationDbContext context)
        {
            _dbContext = context;
        }

        public void Insert(T model)
        {
            if (model != null)
            {
                var createdTime = DateTime.Now;
                model.CreateTime = createdTime;
                model.LastModifiedTime = createdTime;
                model.CreatedBy = "";
                model.LastModifiedBy = "";
            }
            _dbContext.Entry(model).State = EntityState.Added;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T Find(string id)
        {
            return GetAll().FirstOrDefault(_ => _.Id == id);
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                entity.LastModifiedTime = DateTime.Now;
                entity.LastModifiedBy = "";
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void AddOrUpdate(T entity)
        {
            var model = Find(entity.Id);
            if (model==null) Insert(entity);
            else Update(entity);
        }

        public void RemoveAll(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }
        
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Delete(Find(id));
        }

        public void Insert(List<T> models)
        {
            foreach (var model in models)
            {
                Insert(model);
            }
        }

        public void ExecuteQuery(string query)
        {
            _dbContext.Database.ExecuteSqlCommand(query);
        }
    }
}