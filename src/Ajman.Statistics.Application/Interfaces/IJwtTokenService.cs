using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajman.Statistics.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(string username, string role);        
    }
}
