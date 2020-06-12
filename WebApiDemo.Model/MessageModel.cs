﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Model
{
    /// <summary>
    /// 通用返回消息类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; } = "服务器异常";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }
        
    }
}
