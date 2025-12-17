using Ajman.Statistics.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Ajman.Statistics.Infrastructure.Caching
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            _cache.Set(key, value, expiry);
        }
    }
}
