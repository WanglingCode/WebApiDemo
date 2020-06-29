using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Common.Helper;

namespace WebApiDemo.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly string redisConnenctionString;
        private volatile ConnectionMultiplexer redisConnection;
        private readonly object redisConnectionLock = new object();

        public RedisCacheManager()
        {
            string redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });

            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentNullException("Redis config is empty", nameof(redisConfiguration));
            }

            this.redisConnenctionString = redisConfiguration;
            this.redisConnection = GetReidsConnection();
        }

        /// <summary>
        /// 核心代码，获取连接实例
        /// 通过双if 夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetReidsConnection()
        {
            //如果已经连接到实例，直接返回
            if(this.redisConnection != null && this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }

            //加锁，防止异步编程中，出现单例无效的问题
            lock (redisConnectionLock)
            {
                if(this.redisConnection != null)
                {
                    //释放redis连接
                    this.redisConnection.Dispose();
                }
            }

            try 
            {
                this.redisConnection = ConnectionMultiplexer.Connect(redisConnenctionString);
            }
            catch (Exception)
            {
                throw new Exception("Redis服务未启用,请开启该服务");
            }

            return this.redisConnection;
        }

        /// <summary>
        /// 清除所有数据
        /// </summary>
        public void Clear()
        {
            foreach(var endPoint in this.GetReidsConnection().GetEndPoints())
            {
                var server = this.GetReidsConnection().GetServer(endPoint);
                foreach(var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public TEntity Get<TEntity>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将redis存储的Byte[],进行反序列化
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public bool Get(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public string GetValue(string key)
        {
            return redisConnection.GetDatabase().StringGet(key);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if(value != null)
            {
                redisConnection.GetDatabase().StringSet(key, SerializeHelper.Serialize(value), cacheTime);
            }
        }

        public bool SetValue(string key, byte[] value)
        {
            return redisConnection.GetDatabase().StringSet(key, value, TimeSpan.FromSeconds(120));
        }
    }
}
