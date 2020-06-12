using EFBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiDemo.IRepository.Base;

namespace WebApiDemo.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private DataContext dbContext;
        private DbSet<TEntity> dbSet;
        
        public BaseRepository(DataContext _dataContext)
        {
            dbContext = _dataContext;
            dbSet = dbContext.Set<TEntity>();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList()
        {
            return dbSet;
        }
    }
}
