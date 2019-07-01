using AgencyPepsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ListMast.Utils
{

    public class MyHTTP
    {


        // Get new data rows
        public static async Task GetAgencyAsync(Action<IEnumerable<Agency>> action, Action<IEnumerable<Order>> actiona)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://10.168.13.8/api/Values");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var list = JsonConvert.DeserializeObject<IEnumerable<Agency>>(await response.Content.ReadAsStringAsync());
                var listq = JsonConvert.DeserializeObject<IEnumerable<Order>>(await response.Content.ReadAsStringAsync());
                action(list);
                actiona(listq);
            }

        }
     
    }
}