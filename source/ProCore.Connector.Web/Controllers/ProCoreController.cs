using ProCore.Connector.Web.Helper;
using ProCore.Connector.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProCore.Connector.Web.Controllers
{
   
    public class ProCoreController : Controller
    {
        private string _baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");// "https://app.procore.com";
        private string _clientId = "";
        private string _clientSecret = "";
        private string _redirectUrl = ConfigurationManager.AppSettings.Get("redirectUrl");//"http://localhost:64922/ProCore/Authenticate";
        // GET: ProCore
        public ActionResult Index()
        {
            if (Session["AccessToken"] == null)
            {
                Response.Redirect($"{_baseUrl}/oauth/authorize?response_type=code&client_id={_clientId}&redirect_uri={_redirectUrl}");
            }
            
            return View();
        }

        public void Authenticate()
       {
            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(_baseUrl + $"/oauth/token?grant_type=authorization_code&client_id={_clientId}&client_secret={_clientSecret}&redirect_uri={_redirectUrl}&code={code}", "").Result;
                RefreshToken newToken = response.Content.ReadAsAsync<RefreshToken>().Result;
                Session["AccessToken"] = newToken.access_token;
                Session["RefreshToken"] = newToken.refresh_token;
            }
            Response.Redirect("/ProCore");
           // RedirectToActionPermanent("Index");
            //return View("Index");
        }

        [HttpPost]
        public ActionResult GetData(ProCoreModel model)
        {
            string accessToken = Session["AccessToken"] as string;
            string refreshToken = Session["RefreshToken"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(refreshToken))
            {
                RedirectToAction("Index");
            }
            string response = string.Empty;
            if (ApiHelper.GetTokenInfo(accessToken, _baseUrl))
            {
                response = ApiHelper.GetData(_baseUrl, model.EndPoint, accessToken);

            }
            else
            {
               RefreshToken token =  ApiHelper.RefreshAccessToken(_baseUrl, refreshToken,_clientId, _clientSecret, _redirectUrl);
                Session["AccessToken"] = token.access_token;
                Session["RefreshToken"] = token.refresh_token;
                response = ApiHelper.GetData(_baseUrl, model.EndPoint,token.access_token);
            }
            byte[] filedata = Encoding.ASCII.GetBytes(response); //System.IO.File.ReadAllBytes(response);
            var temp = model.EndPoint.Remove(model.EndPoint.IndexOf('?')).Remove(0, 7).Split(new char[] { '/' });
            var result = (from s in temp select s).Reverse().Take(2).Reverse().ToList();

            return File(filedata, "application/json", result.Count == 2 ? $"{result[0]}_{result[1]}.json" : $"{result[0]}.json");
            //return Json(response);
        }
    }
}