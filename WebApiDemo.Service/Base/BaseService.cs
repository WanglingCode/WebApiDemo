using EFBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiDemo.IRepository.Base;
using WebApiDemo.IServices.Base;
using WebApiDemo.Repository.Base;

namespace WebApiDemo.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {

        private IBaseRepository<TEntity> _dal;

        public BaseService(IBaseRepository<TEntity> dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList()
        {
            return _dal.GetList();
        }
        
        
    }
}
