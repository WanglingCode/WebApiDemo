using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.IRepository.Base;
using WebApiDemo.Model.Model;

namespace WebApiDemo.IRepository
{
    
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
