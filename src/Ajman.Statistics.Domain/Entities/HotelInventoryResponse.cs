using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajman.Statistics.Domain.Entities.Common;

namespace Ajman.Statistics.Domain.Entities
{
    public class HotelInventoryResponse : CommonDto
    {
        public int NoOfHotels { get; set; } //NumberOfHotels
        public int TotalRooms { get; set; }
    }
}
