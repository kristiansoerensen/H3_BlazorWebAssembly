using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Utils
{
    public abstract class GenericRepositoty<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> _dbContext;
        protected ILogger _logger;

        public GenericRepositoty(
            AppDbContext context, ILogger logger)
        {
            _context = context;
            _dbContext = _context.Set<T>();
            _logger = logger;   
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            _dbContext.Remove(entity);
            return true;
        }
        public virtual bool DeleteRange(IEnumerable<T> entites)
        {
            _dbContext.RemoveRange(entites);
            return true;
        }

        public string DumpJson(Object? entity = null)
        {
            return JsonConvert.SerializeObject(entity != null ? entity : this);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext;
        }

        public virtual async Task<T?> GetById(int? Id)
        {
            return await _dbContext.FindAsync(Id);
        }

        public virtual bool Update(T entity)
        {
            _dbContext.Update(entity);
            return true;
        }
        public IEnumerable<T> Pagination(IEnumerable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
