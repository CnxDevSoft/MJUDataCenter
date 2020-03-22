using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MJU.DataCenter.WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadApi();




            //var restRequest = new RestRequest("api/TokenAuth/Authenticate")
            //{
            //    RequestFormat = DataFormat.Json,
            //    Method = Method.POST
            //};
            //// Add Jwt Token here
            //restRequest.AddHeader("Authorization", "Authorization");
            //restRequest.AddHeader("Content-Type", "application/json");
            //restRequest.AddHeader("Abp.TenantId", "2");


            //restRequest.AddJsonBody(new { userNameOrEmailAddress = "admin", password = "123qwe" }); ;

            //var response = restClient.Execute(restRequest);

            //var objects = JsonConvert.DeserializeObject<ResultObjects>(response.Content.Trim());

            //AuthKey = string.Format("Bearer {0}", objects.result.AccessToken);

            //restRequest = new RestRequest("api/services/app/Courses/GetAll")
            //{
            //    RequestFormat = DataFormat.Json,
            //    Method = Method.GET
            //};
            //// Add Jwt Token here
            //restRequest.AddHeader("Authorization", AuthKey);
            //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //restRequest.AddHeader("Abp.TenantId", "2");

            //response = restClient.Execute(restRequest);

            //return JsonConvert.DeserializeObject<object>(response.Content.Trim());

        }

        public void LoadApi()
        {
            //https://localhost:44341/api/ResearchDepartment/2

            var restClient = new RestClient("http://localhost:44341/");
            var restRequest = new RestRequest("api/ResearchDepartment/2")
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };
            restRequest.AddHeader("Content-Type", "application/json");

            var response = restClient.Execute(restRequest);



        }
    }
}