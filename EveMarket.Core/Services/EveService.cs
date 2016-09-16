using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using EveMarket.Core.Services.Interfaces;

namespace EveMarket.Core.Services
{
    public class EveService : IEveService
    {
        private readonly EveAuth _eveAuth;
        private readonly EveCrest _eveCrest;
        private readonly string _clientId = ConfigurationManager.AppSettings["EveSSO.ClientID"];
        private readonly string _secretKey = ConfigurationManager.AppSettings["EveSSO.SecretKey"];
        private readonly string _redirectUri = ConfigurationManager.AppSettings["EveSSO.RedirectURI"];
        private readonly string _scope = ConfigurationManager.AppSettings["EveSSO.Scope"];

        public EveService(EveAuth eveAuth, EveCrest eveCrest)
        {
            _eveAuth = eveAuth;
            _eveCrest = eveCrest;
        }

        public EveService(string refreshToken)
        {
            _eveAuth = new EveAuth();
            _eveCrest = new EveCrest(refreshToken, GenerateEncryptedKey());
        }

        public async Task<IEnumerable<FittingCollection.Fitting>> GetFittings()
        {
            return
                (await
                    (await
                        (await (await _eveCrest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Fittings)).AllItems();
        }

        public string GetAuthLink()
        {
            return _eveAuth.CreateAuthLink(_clientId, _redirectUri, "crest-login", _scope);
        }

        public async Task<AuthResponse> GetAuthResponse(string authCode)
        {
            var encryptedKey = GenerateEncryptedKey();
            var authResponse = await _eveAuth.AuthenticateAsync(encryptedKey, authCode);

            return authResponse;
        }

        public async Task<VerifyResponse> GetVerifyResponse(string accessToken)
        {
            return await _eveAuth.VerifyAsync(accessToken);
        }

        protected string GenerateEncryptedKey()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_secretKey}"));
        }
    }
}
