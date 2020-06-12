using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiDemo.IServices.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetList();
    }
}
