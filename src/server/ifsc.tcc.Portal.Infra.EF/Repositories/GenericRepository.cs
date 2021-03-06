﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ifsc.tcc.Portal.Infra.Data.EF.Repositories
{
    public abstract class GenericRepository<T> :
        IGetRepository<T>,
        IAddRepository<T>,
        IRemoveRepository<T>,
        IUpdateRepository<T>
        where T : class
    {
        protected readonly DbSet<T> _entities;

        public GenericRepository(IFSCContext context)
        {
            _entities = context.Set<T>();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
