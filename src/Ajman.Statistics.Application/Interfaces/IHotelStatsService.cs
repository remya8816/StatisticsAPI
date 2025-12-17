using Ajman.Statistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajman.Statistics.Application.Interfaces
{
    public interface IHotelStatsService
    {
        Task<HotelInventoryResponse> GetInventoryAsync(HotelInventoryQuery query);
    }
}
