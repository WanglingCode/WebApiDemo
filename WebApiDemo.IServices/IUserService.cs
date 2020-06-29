using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.IServices.Base;
using WebApiDemo.Model.Model;

namespace WebApiDemo.IServices
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();
        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> QueryByID(int id);
    }
}
