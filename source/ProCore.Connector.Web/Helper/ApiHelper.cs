using Newtonsoft.Json.Linq;
using ProCore.Connector.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ProCore.Connector.Web.Helper
{
    public class ApiHelper
    {
        public static bool GetTokenInfo(string accessToken, string baseUrl)
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

        public static RefreshToken RefreshAccessToken(string baseUrl, string refreshToken, string clientId,string clientSecret, string redirectUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync(baseUrl + $"/oauth/token?grant_type=refresh_token&client_id={clientId}&client_secret={clientSecret}&redirect_uri={redirectUrl}&refresh_token={refreshToken}", "").Result;

            RefreshToken newToken = response.Content.ReadAsAsync<RefreshToken>().Result;
           
            return newToken;
        }

        public static string GetData(string baseUrl, string dataEndpoint,string accessToken)
        {
            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("company_id", "6797");
            response = client.GetAsync(baseUrl + $"{dataEndpoint}").Result;  // Blocking call!
            string result = response.Content.ReadAsStringAsync().Result;
            return JValue.Parse(result).ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}