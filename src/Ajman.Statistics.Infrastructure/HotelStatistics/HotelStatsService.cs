using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Domain.Entities;

namespace Ajman.Statistics.Infrastructure.Services
{
    public class HotelStatisticsService : IHotelStatsService
    {
        private readonly ICacheService _cache;

        public HotelStatisticsService(ICacheService cache)
        {
            _cache = cache;
        }

        public async Task<HotelInventoryResponse> GetInventoryAsync(HotelInventoryQuery query)
        {
            // 1️⃣ Create a cache key based on query parameters
            string cacheKey = $"inventory_{query.FromDate:yyyyMMdd}_{query.ToDate:yyyyMMdd}";

            // 2️⃣ Try to get from cache
            var cached = await _cache.GetAsync<HotelInventoryResponse>(cacheKey);
            if (cached != null)
            {
                return cached; // return cached value
            }

            // 3️⃣ If not cached, generate response (dummy logic here)
            var response = new HotelInventoryResponse
            {
                NoOfHotels = 50,
                TotalRooms = 20
            };

            // 4️⃣ Store in cache for 5 minutes
            await _cache.SetAsync(cacheKey, response, TimeSpan.FromMinutes(5));

            return response;
        }
    }
}
