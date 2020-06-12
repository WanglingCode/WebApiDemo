using EFBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.IRepository;
using WebApiDemo.Model.Model;
using WebApiDemo.Repository.Base;

namespace WebApiDemo.Repository
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext db) : base(db)
        {

        }
    }
}
