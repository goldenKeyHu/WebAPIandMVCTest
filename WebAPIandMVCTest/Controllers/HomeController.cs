using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebAPIandMVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private string requestBaseAddress = "http://localhost:3951/";
        private HttpClient _httpClient;
        public HttpClient HtpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }
                return _httpClient;
            }
        }

        public ActionResult RequestHelper(FormCollection formData)
        {
            string httpMethod = HttpContext.Request["method"];         //http请求的mothod，如：Get、Post、Delete、Put
            //string token = HttpContext.Cache.Get("accessToken").ToString();     //获取该用户拥有的accessToken
            string responseValue = string.Empty;                  //请求返回的结果
            string requestUrl = HttpContext.Request["ReuestUrl"];       //将要请请求的url

            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (formData != null)       //组织form 数据，在post、put的时候可能会用到
            {
                if (formData.Count == 3)
                {
                    dict.Add("", formData[formData.Keys[0]]);
                }
                else if (formData.Count > 3)
                {
                    for (int i = 0; i < formData.Keys.Count - 2; i++)
                    {
                        dict.Add(formData.Keys[i], formData[formData.Keys[i]]);
                    }
                }
            }

            switch (httpMethod.ToLower())
            {
                case "post":
                    responseValue = HtpClient.PostAsync(requestBaseAddress + requestUrl, new FormUrlEncodedContent(dict)).Result.Content.ReadAsStringAsync().Result;
                    break;
                case "get":
                    responseValue = HtpClient.GetAsync(requestBaseAddress + requestUrl).Result.Content.ReadAsStringAsync().Result;
                    break;
                case "put":
                    responseValue = HtpClient.PutAsync(requestBaseAddress + requestUrl, new FormUrlEncodedContent(dict)).Result.Content.ReadAsStringAsync().Result;
                    break;
                case "delete":
                    responseValue = HtpClient.DeleteAsync(requestBaseAddress + requestUrl).Result.Content.ReadAsStringAsync().Result;
                    break;
                default:
                    break;
            }
            return Json(responseValue, JsonRequestBehavior.AllowGet);
        }
    }
}
