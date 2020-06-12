using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.IServices;
using WebApiDemo.Model.Model;
using WebApiDemo.Service;

namespace WebApiDemo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        public int Sum(int i , int j)
        {
            //服务端接口实例化
            ITestService testService = new TestService();
            return testService.Sum(i, j);
        }

        
    }
}