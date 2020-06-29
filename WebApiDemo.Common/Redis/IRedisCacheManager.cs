using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Common.Redis
{
    /// <summary>
    /// Redis缓存接口
    /// </summary>
    public interface IRedisCacheManager
    {
        /// <summary>
        /// 获取 Redis 缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// 获取值并序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get<TEntity>(string key);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        void Set(string key, Object value, TimeSpan cacheTime);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Get(string key);

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetValue(string key, byte[] value);

        /// <summary>
        /// 移除某个缓存值
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 全部清除
        /// </summary>
        void Clear();
    }
}
