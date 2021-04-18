using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVC
{
    public class GlobalVariable
    {
        public static HttpClient webclient = new HttpClient();

       static GlobalVariable(){
            webclient.BaseAddress = new Uri("http://localhost:51729/api/");
            webclient.DefaultRequestHeaders.Clear();
            webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}