using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApiDemo.IRepository.Base;
using WebApiDemo.Model.Model;

namespace WebApiDemo.IRepository
{
    public interface ITodoRepository : IBaseRepository<TodoItem>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        int Add(TodoItem todoItem);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        int Delete(TodoItem todoItem);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        int Update(TodoItem todoItem);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>> where);
    }
}
