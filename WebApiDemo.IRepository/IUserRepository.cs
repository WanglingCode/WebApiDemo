﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.IRepository.Base;
using WebApiDemo.Model.Model;

namespace WebApiDemo.IRepository
{
    
    public interface IUserRepository : IBaseRepository<User>
    {

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();
    }
}
