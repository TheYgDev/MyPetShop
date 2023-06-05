using App.DAL.DataContext;
using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbPetsContext _context;
        public GenericRepository(DbPetsContext context)
        {
            _context = context;
        }
        public async void AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }
        public async void AddRangeAsync(IEnumerable<T> entities)
        {
           await _context.Set<T>().AddRangeAsync(entities);
        }

		public void EditAsync(T entity)
		{
            _context.Update(entity);
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
		public IEnumerable<T> FindFrom(Expression<Func<T, bool>> expression,IEnumerable<T> values)
		{
			return values.Where(expression.Compile());
		}
		public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
