using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProCore.Connector
{
    public class ApiHelper
    {
        public static bool GetTokenInfo(string accessToken , string baseUrl)
        {
            string tokenInfoUrl = "/oauth/token/info";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            // List data response.
            HttpResponseMessage response = client.GetAsync(baseUrl + tokenInfoUrl).Result;
            return response.IsSuccessStatusCode;
        }

        public static string RefreshAccessToken(string baseUrl, string refreshToken)
        {
            string clientId = "";
            string clientSecret = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync(baseUrl + $"oauth/token?grant_type=refresh_token&client_id={clientId}&client_secret={clientSecret}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&refresh_token={refreshToken}", "").Result;
           
            RefreshToken newToken = response.Content.ReadAsAsync<RefreshToken>().Result;
            return newToken.access_token;
        }

        public static string GetData(string baseUrl , string dataEndpoint)
        {
            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationSettings.AppSettings.Get("accessToken"));
            response = client.GetAsync(baseUrl + $"{dataEndpoint}").Result;  // Blocking call!
            string result = response.Content.ReadAsAsync<string>().Result;
           return JValue.Parse(result).ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
