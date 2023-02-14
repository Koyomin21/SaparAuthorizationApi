using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext Context { get; set; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Create(T entity) => Context.Set<T>().Add(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
            Context.Set<T>().Where(expression).AsNoTracking();

        public void Update(T entity) => Context.Set<T>().Update(entity);
    }
}
