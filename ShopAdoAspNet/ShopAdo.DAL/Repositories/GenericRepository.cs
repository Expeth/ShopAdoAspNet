using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void AddOrUpdate(T obj)
        {
            _dbSet.AddOrUpdate(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(Get(id));
            _context.SaveChanges();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        ~GenericRepository()
        {
            _context.Dispose();
        }
    }
}
