﻿using EFBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.IRepository;
using WebApiDemo.Model.Model;
using WebApiDemo.Repository.Base;

namespace WebApiDemo.Repository
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private DataContext dbContext;
        private DbSet<User> dbSet;
        /// <summary>
        /// 添加上下文依赖
        /// </summary>
        /// <param name="dataContext"></param>
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            dbContext = dataContext;
            dbSet = dbContext.Set<User>();
        }
        
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetCount()
        {
            var i = await Task.Run(() => dbSet.CountAsync(x => 1 == 1));
            return i;
        }

        /// <summary>
        /// 获取根据ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> QueryByID(int id)
        {
            User user = await Task.Run(() => dbSet.Where<User>(t => t.Id == id).FirstOrDefault());
            return user;
        }
    }
}
