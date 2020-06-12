using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.IRepository;

namespace WebApiDemo.Repository
{
    public class TestRepository : ITestRepository
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
