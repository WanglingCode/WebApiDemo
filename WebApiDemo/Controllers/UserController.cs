using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Auth;
using WebApiDemo.Common.Redis;
using WebApiDemo.IServices;
using WebApiDemo.Model.Model;

namespace WebApiDemo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// Hello 请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }

        /// <summary>
        /// 获取User实体
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UserInfo(User user)
        {
            return Ok(user);
        }

        /// <summary>
        /// 获取Token令牌
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if(role != null)
            {
                TokenModel tokenModel = new TokenModel { Uid = "abcde", Role = role };
                jwtStr = JwtHelper.IssueJwt(tokenModel);
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new { success = suc, token = jwtStr });
        }

        /// <summary>
        /// 需要admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("Hello admin");
        }

        /// <summary>
        /// 需要System权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "System")]
        public IActionResult System()
        {
            return Ok("Hello admin");
        }

        private readonly ITodoService _todo;

        private readonly IUserService _userService;

        private readonly IRedisCacheManager _redis;
        /// <summary>
        /// 控制器注入service依赖
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="userService"></param>
        /// <param name="redisCacheManager"></param>
        public UserController(ITodoService todo, IUserService userService, IRedisCacheManager redisCacheManager)
        {
            _todo = todo;
            _userService = userService;
            _redis = redisCacheManager;
        }

        /// <summary>
        /// 接口测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTodoList()
        {
            var todoItem = _todo.GetList();
            return Ok(todoItem);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddTodo(TodoItem todoItem)
        {
            int count = _todo.Add(todoItem);
            return Ok(count);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(TodoItem todoItem)
        {
            int count = _todo.Delete(todoItem);
            return Ok(count);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(TodoItem todoItem)
        {
            int count = _todo.Update(todoItem);
            return Ok(count);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int ID)
        {
            var todoItem = _todo.Get(t => t.Id == ID);
            return Ok(todoItem);
        }

        /// <summary>
        /// 测试autoface
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var count = await _userService.GetCount();
            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> Redis(int id)
        {
            var key = $"Redis{id}";
            User user = new User();
            if(_redis.Get<object>(key) != null)
            {
                user = _redis.Get<User>(key);
            }
            else
            {
                user = await _userService.QueryByID(id);
                _redis.Set(key, user, TimeSpan.FromHours(2));//缓存两小时
            }

            return Ok(user);
        }
    }
}