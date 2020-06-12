using EFBase.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiDemo.IRepository.Base
{
    /// <summary>
    /// 基类接口，其他接口继承该接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 查询List
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetList();
    }
}
