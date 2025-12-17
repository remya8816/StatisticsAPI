using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ajman.Statistics.Domain.Entities.Common
{
    public class CommonDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string Emirate { get; set; }
        public string City { get; set; }
        public string Zone { get; set; }
        public string EstablishmentType { get; set; }
        public string EstablishmentClass { get; set; }

        [JsonIgnore]
        public int RowCounts { get; set; }
    }
}
