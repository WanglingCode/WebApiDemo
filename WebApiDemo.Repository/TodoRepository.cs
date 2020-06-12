using EFBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApiDemo.IRepository;
using WebApiDemo.IRepository.Base;
using WebApiDemo.Model.Model;
using WebApiDemo.Repository.Base;


namespace WebApiDemo.Repository
{
    public class TodoRepository : BaseRepository<TodoItem>, ITodoRepository
    {
        private DataContext dbContext;
        private DbSet<TodoItem> dbSet;
        /// <summary>
        /// 添加上下文依赖
        /// </summary>
        /// <param name="dataContext"></param>
        public TodoRepository(DataContext dataContext): base(dataContext)
        {
            dbContext = dataContext;
            dbSet = dbContext.Set<TodoItem>();
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Add(TodoItem todoItem)
        {
            dbSet.Add(todoItem);
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Delete(TodoItem todoItem)
        {
            dbSet.Attach(todoItem);
            dbSet.Remove(todoItem);
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Update(TodoItem todoItem)
        {
            //将给定实体以 System.Data.EntityState.Unchanged 状态附加到上下文中
            //从解释可以看出Attach方法主要目的就是把一个没有被dbContext跟踪的对象附加到dbCotext中使其被dbContext跟踪
            dbSet.Attach(todoItem);
            //dbSet.Update(todoItem);
            dbContext.Entry(todoItem).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>> where)
        {
            return dbSet.Where(where);
        }
    }
}
