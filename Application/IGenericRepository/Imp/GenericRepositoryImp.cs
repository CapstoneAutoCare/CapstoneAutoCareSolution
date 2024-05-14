using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IGenericRepository.Imp
{
    public class GenericRepositoryImp<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDBContext _context;

        private readonly DbSet<T> _entitiySet;

        public GenericRepositoryImp(AppDBContext context)
        {
            _context = context;
            _entitiySet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var add = await _context.Set<T>().AddAsync(entity);
            return add.Entity;
        }

        public void Remove(T entity)
              => _context.Remove(entity);

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
