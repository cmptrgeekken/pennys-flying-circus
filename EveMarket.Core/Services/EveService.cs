using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Models.Links;
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

        public void GetFittings()
        {
            
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

        protected string GenerateEncryptedKey()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_secretKey}"));
        }
    }
}
