using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveAuthModule;

namespace EveMarket.Core.Services.Interfaces
{
    public interface IEveService
    {
        string GetAuthLink();
        Task<AuthResponse> GetAuthResponse(string authCode);
    }
}
