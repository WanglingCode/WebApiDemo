﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFBase.IRepositorie
{
    public interface ITestRepository
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
