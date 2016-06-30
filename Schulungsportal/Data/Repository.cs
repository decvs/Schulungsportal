using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data
{
    public class Repository<TEntity>
        where TEntity : class, IIdentifyableEntity
    {
        private readonly TpContext _database;
        public Repository()
        {
            _database = new TpContext();
        }

         public IQueryable<TEntity> Query
         {
             get
             {
                 return _database.Set<TEntity>();
             }
         }

        public void Insert(TEntity entity)
        {
            try
            {
                _database.Set<TEntity>().Add(entity);
                _database.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public TEntity GetById(int id)
        {
            var entity = _database.Set<TEntity>().Find(id);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _database.Set<TEntity>().Remove(entity);
            _database.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _database.Entry(entity).State = EntityState.Modified;

            _database.SaveChanges();
        }
    }
}