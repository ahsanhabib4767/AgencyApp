using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AgencyPepsi.Helpers;

using Newtonsoft.Json;
using AgencyPepsi.Models;
using Newtonsoft.Json.Linq;

namespace AgencyPepsi.Services
{
    internal class ApiServices
    {
        public async Task<string> LoginAsync(string Username, string Password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Username", Username),
                new KeyValuePair<string, string>("Password", Password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            var request = new HttpRequestMessage(
               HttpMethod.Post, Constants.BaseApiAddress + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);
           

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
            var user = jwtDynamic.Value<string>("name");
            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            
            

            Settings.Username = user;
            //Settings.Password = password;
            Settings.AccessTokenExpirationDate = accessTokenExpiration;

            //Debug.WriteLine(accessTokenExpiration);

            // Debug.WriteLine(content);

            return accessToken;


        }

      

        public async Task<List<Employee>> GetIdeasAsync(string gender,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Employee?gender=" + gender);

            var ideas = JsonConvert.DeserializeObject<List<Employee>>(json);

            return ideas;
        }
        public async Task<List<Agency>> GetAgencyAsync(string user,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Agency?user="+user);

            var agency = JsonConvert.DeserializeObject<List<Agency>>(json);

            return agency;
            
        }
        public async Task<List<Order>> GetOrderAsync(int AgencyId,DateTime startdate,DateTime enddate,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Values?id="+AgencyId+ "&startdate="+startdate+ "&enddate="+enddate);

            var agency = JsonConvert.DeserializeObject<List<Order>>(json);
         
           
            return agency;

        }
        public async Task<List<Ord>> GetAllOrderAsync(string user, DateTime startdate,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Datewise?user="+user+"&start="+startdate);

            var ideas = JsonConvert.DeserializeObject<List<Ord>>(json);

            return ideas;
        }
        public async Task PostIdeaAsync(Employee idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "api/Employee", content);
        }










    }
}