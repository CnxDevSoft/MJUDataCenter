using MJU.DataCenter.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.Helper
{
    public class AuthenticationApi
    {
        public static async Task<AuthenticationModel> Authenticated(AuthenticateModel auth, string webHost)
        {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using var client = new HttpClient(clientHandler);
                using var request = new HttpRequestMessage(HttpMethod.Post, $"{webHost}/account/AuthenticatedToken?token=" + auth.Token);
                request.Headers.Add("token", auth.Token);

                request.Properties.Add("token", auth.Token);

                using var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthenticationModel>(content);
                return result;
            
        }
    }

}
