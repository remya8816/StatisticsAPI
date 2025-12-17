using Ajman.Statistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajman.Statistics.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SaveAsync(RefreshToken token);
        Task<RefreshToken?> GetAsync(string token);
        Task RevokeAsync(string token);
    }
}
