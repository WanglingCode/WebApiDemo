using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApiDemo.IRepository;
using WebApiDemo.IRepository.Base;
using WebApiDemo.IServices;
using WebApiDemo.Model.Model;
using WebApiDemo.Service.Base;

namespace WebApiDemo.Service
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _dal;

        public TodoService(ITodoRepository dal)
        {
            _dal = dal;
        }

        public IEnumerable<TodoItem> GetList()
        {
            return _dal.GetList();
        }

        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Add(TodoItem todoItem)
        {
            return _dal.Add(todoItem);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Delete(TodoItem todoItem)
        {
            return _dal.Delete(todoItem);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public int Update(TodoItem todoItem)
        {
            return _dal.Update(todoItem);
        }

        public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>> where)
        {
            return _dal.Get(where);
        }
    }
}
