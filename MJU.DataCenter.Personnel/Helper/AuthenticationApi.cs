using MJU.DataCenter.Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.Helper
{
    public class AuthenticationApi
    {
        public static async Task<AuthenticationModel> Authenticated(string token, string userName)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost/MJU.DataCenter.Web/account/AuthenticatedToken?token=" + token + "&userName=" + userName + "");
            request.Headers.Add("token", token);
            request.Headers.Add("userName", userName);

            request.Properties.Add("token", token);
            request.Properties.Add("userName", userName);

            using var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthenticationModel>(content);
            return result;
        }
    }
}
