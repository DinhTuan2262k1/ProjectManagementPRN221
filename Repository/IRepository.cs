using Microsoft.EntityFrameworkCore;
using ProjectManagementPRN221.Models;

namespace ProjectManagementPRN221.Repository
{
    public class IRepository<T> where T : class
    {
        protected ProjectManagementContext _context;
        private DbSet<T> _dbSet;

        public IRepository(ProjectManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T getOne(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return _dbSet.ToList();
        }

        public void edit(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public T create(T entity)
        {
            var e = _dbSet.Add(entity);
            _context.SaveChanges();
            return e.Entity;
        }
    }
}
