using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySalesApp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected EmployeeContext context { get; set; }
        private DbSet<T> dbset { get; set; }
        public Repository(EmployeeContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }
        private int? count;
        public int Count => count ?? dbset.Count();

        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        public virtual T Get(int id) => dbset.Find(id);
        public virtual T Get(string id) => dbset.Find(id);
        public virtual T Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }
        IEnumerable<T> IRepository<T>.List(QueryOptions<T> options)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.Get(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Insert(T entity) => dbset.Add(entity);

        void IRepository<T>.Update(T entity) => dbset.Update(entity);

        void IRepository<T>.Delete(T entity) => dbset.Remove(entity);

        void IRepository<T>.Save() => context.SaveChanges();

        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }
                count = query.Count(); // get filtered count
            }
            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }
            }
            if (options.HasPaging)
            {
                query = query.PageBy(options.PageNumber, options.PageSize);
            }
            return query;
        }
    }
}
