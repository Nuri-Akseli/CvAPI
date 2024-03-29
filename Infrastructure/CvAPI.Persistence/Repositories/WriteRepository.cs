﻿using CvAPI.Application.Repositories;
using CvAPI.Domain.Entities.Common;
using CvAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T>
        where T : BaseEntity
    {
        private readonly CvAPIDbContext _context;
        public WriteRepository(CvAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry =await Table.AddAsync(entity);
            return entityEntry.State==EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry=Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public async Task<bool> RemoveAsync(int id)
        {
           T model= await Table.FirstOrDefaultAsync(entity => entity.Id == id);
           return Remove(model);
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry= Table.Update(entity);
            return entityEntry.State == EntityState.Modified;

        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

       
    }
}
