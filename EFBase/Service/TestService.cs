using EFBase.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFBase.Service
{
    public class TestService : ITestService
    {
        public int  Sum(int i, int j)
        {
            return i + j;
        }
    }
}
