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
        public static async Task<string> Authenticated(string token, string userName)
        {
            // HttpClientHandler clientHandler = new HttpClientHandler();
            //  clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //  HttpClient client = new HttpClient(clientHandler);

            using (var client = new HttpClient(clientHandler))
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost/MJU.DataCenter.Web/account/AuthenticatedToken?token="+token+"&userName="+ userName +""))       
            {

                request.Headers.Add("token", token);
                request.Headers.Add("userName", userName);

                request.Properties.Add("token", token);
                request.Properties.Add("userName", userName);

                using (var response = await client.SendAsync(request))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }


         //   return a;
         //  HttpResponseMessage test =  await client.GetAsync("https://localhost/MJU.DataCenter.Web/account/Test");
         // var a = test.Result;

            //   System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.SystemDefault;
           // var restClient = new RestClient("https://localhost/MJU.DataCenter.Web");
          //  var restRequest = new RestRequest("account/Test");
            //  restRequest.RequestFormat = DataFormat.Json;
            //  restRequest.Method = Method.GET;
            // Add Jwt Token here
            // restRequest.AddHeader("Content-Type", "application/json");
            // restRequest.AddBody("token", token);
            // restRequest.AddBody("userName", userName);



          //  var response = restClient.Execute(restRequest);
  
          //  return response.StatusCode.ToString();
        }

        public static async Task<string> TestAsync()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var result = await client.GetAsync("https://localhost/MJU.DataCenter.Web/account/Test");

            return result.Content.ToString();
            
        } 

    }
}
