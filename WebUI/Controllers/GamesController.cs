using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Games;

namespace WebUI.Controllers
{
    public class GamesController : Controller
    {
        public ActionResult Index()
        {
            var vm = new GamesListViewModel();

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"], Method.GET);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var obj = JObject.Parse(response.Content);
                vm.Games = obj["data"].ToObject<List<Game>>();
            }

            return View(vm);
        }
    }
}