using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApiDemo.IServices.Base;
using WebApiDemo.Model.Model;

namespace WebApiDemo.IServices
{
    public interface ITodoService : IBaseService<TodoItem>
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

        IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>> where);
    }
}
