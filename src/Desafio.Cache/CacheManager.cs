using Desafio.Cache.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace Desafio.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;
        private readonly int ExpiracaoCache;
        public CacheManager(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            ExpiracaoCache = Convert.ToInt32(configuration["ExpiracaoCache"]);
        }
        public void GravarCache<T>(string chave, T objeto)
        {
            var opcoesCache = new DistributedCacheEntryOptions();

            opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(ExpiracaoCache));

            _distributedCache.SetString(chave, JsonSerializer.Serialize(objeto), opcoesCache);
        }

        public T ObterChache<T>(string chave)
        {
            var cache = _distributedCache.GetString(chave);

            if (cache == null)
                return default;

            return JsonSerializer.Deserialize<T>(cache);
        }
    }
}
