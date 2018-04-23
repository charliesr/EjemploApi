﻿using EjemploApi.Common.Logic;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.DataAccess.Redis
{
    public class RedisDaoAsync<T> : IGetAsync<T>, ISetAsync<T> where T : IModel
    {
        private readonly IDatabase _redis;
        public RedisDaoAsync()
        {
            this._redis = RedisConfiguration.RedisCache;
        }
        public async Task<T> AddAsync(T entity, string key)
        {
            await this._redis.StringSetAsync(key, JsonConvert.SerializeObject(entity));
            return await this.GetAsync(key);
        }

        public async Task<T> GetAsync(string key)
        {
            return JsonConvert.DeserializeObject<T>(await this._redis.StringGetAsync(key));
        }
    }
}
