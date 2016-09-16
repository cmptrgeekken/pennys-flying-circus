using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace EveMarket.Core.Services.Interfaces
{
    public interface IEveService
    {
        string GetAuthLink();
        Task<AuthResponse> GetAuthResponse(string authCode);
        Task<VerifyResponse> GetVerifyResponse(string accessToken);
        Task<IEnumerable<FittingCollection.Fitting>> GetFittings();
    }
}
