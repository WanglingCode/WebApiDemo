﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFBase.IService
{
    public interface ITestService
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        int Sum(int i, int j);
    }
}
