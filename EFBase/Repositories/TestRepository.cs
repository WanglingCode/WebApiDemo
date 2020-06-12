using EFBase.IRepositorie;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFBase.Repositories
{
    public class TestRepository: ITestRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
