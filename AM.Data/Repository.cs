using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    public class Repository<T> : IRepository<T> where T : class
    
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;

        AMContext aMContext;
        public Repository(AMContext aMContext)
        {
            _context = aMContext;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            aMContext.Add(entity);
        }

        public void Delete(T t)
        {
            aMContext.Remove(t);
        }

        public T Get(object id)
        {
            return aMContext.Find<T>(id);
        }

        public IList<T> GetAll()
        {
            return aMContext.Set<T>().ToList(); 
        }

        /*  public void Save()
          {
             aMContext.SaveChanges();
          }
        */
        public void Update(T entity)
        {
            aMContext.Update(entity);
        }
        
        public T GetById(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
    }
}