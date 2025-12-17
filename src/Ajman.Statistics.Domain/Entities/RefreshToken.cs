using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajman.Statistics.Domain
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAtUtc { get; set; }
        public bool IsRevoked { get; set; }
    }
}
