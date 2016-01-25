using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIandMVCTest.Controllers
{
    public class TestController : ApiController
    {
        public bool Get()
        {
            return true;
        }

        public bool Get(string param1)
        {
            return true;
        }

        public bool Get(string param1, string param2)
        {
            return true;
        }

        
        
        public bool Post([FromBody]string value)
        {
            return true;
        }

            /*
        public bool Post([FromBody]string data)        //成  传一些零散的数据时用
        {
            dynamic jsonData = JObject.Parse(data);
            string name = jsonData.Name;
            return true;
        }
        */

            /*
        public bool Post([FromBody]string data)     //成
        {
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
            return true;
        }
        */

        public bool Put([FromUri]int userId, [FromBody]string data)
        {
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
            return true;
        }

        public bool Delete([FromUri]int userId)
        {
            return true;
        }
    }
}
