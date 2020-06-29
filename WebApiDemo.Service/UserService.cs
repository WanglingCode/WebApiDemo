using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.IRepository;
using WebApiDemo.IRepository.Base;
using WebApiDemo.IServices;
using WebApiDemo.IServices.Base;
using WebApiDemo.Model.Model;
using WebApiDemo.Service.Base;

namespace WebApiDemo.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository userDal;

        /// <summary>
        /// 构造函数中直接注入依赖
        /// </summary>
        /// <param name="baseRepository"></param>
        /// <param name="userRepository"></param>
        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository) : base(baseRepository)
        {
            userDal = userRepository;
        }
        public Task<int> GetCount()
        {
            return userDal.GetCount();
        }

        public Task<User> QueryByID(int id) 
        {
            return userDal.QueryByID(id);
        }
    }
}
