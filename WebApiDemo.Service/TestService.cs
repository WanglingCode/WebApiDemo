using System;
using WebApiDemo.IRepository;
using WebApiDemo.IServices;
using WebApiDemo.Repository;

namespace WebApiDemo.Service
{
    public class TestService: ITestService
    {
        /// <summary>
        /// 仓储接口实例化
        /// </summary>
        ITestRepository testRepository = new TestRepository();
        public int Sum(int i, int j)
        {
            return testRepository.Sum(i, j);
        }
    }
}
