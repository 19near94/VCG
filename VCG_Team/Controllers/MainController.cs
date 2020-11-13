using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace VCG_Team.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult GetConference()
        {
            string jsn = string.Empty;
            JToken Conference = null;
            JToken parent = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.balldontlie.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                //GET Method  
                var responseTask = client.GetAsync("api/v1/teams");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsStringAsync();
                    var res = json_serializer.Deserialize<object>(read.Result);
                    
                    JObject jObject = JObject.Parse(read.Result);

                    jsn = read.Result;
                }
            }


            return Json(jsn);

        }
    }
}