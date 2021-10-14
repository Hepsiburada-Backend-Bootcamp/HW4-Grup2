using Dapper;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public DapperRepository(DbContext context)
        {
            this.Context = context;
        }

        public TEntity GetByIdAsync(string query)
        {
            throw new NotImplementedException();
        }

        //public Task AddAsync(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}


        //public void Remove(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public TEntity Update(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
