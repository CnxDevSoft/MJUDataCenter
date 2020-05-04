﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
            ValueTask<TEntity> GetByIdAsync(int id);
            Task<IEnumerable<TEntity>> GetAllAsync();
            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
            Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
            Task AddAsync(TEntity entity);
            void Add(TEntity entity);
            Task AddRangeAsync(IEnumerable<TEntity> entities);
            void Remove(TEntity entity);
            void RemoveRange(IEnumerable<TEntity> entities);
            IEnumerable<TEntity> GetAll();
            void AddRange(IEnumerable<TEntity> entities);

            IEnumerable<TEntity> GetAllWith(params Expression<Func<TEntity, object>>[] includes);

        }
    }

