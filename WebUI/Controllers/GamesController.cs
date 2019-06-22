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
using WebUI.Models.Games.ViewModels;

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

        public ActionResult Detail(int id)
        {
            var vm = new GameDetailViewModel();

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"]+"/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            request.AddParameter("source", "App");

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var clientEvents = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
                var requestEvents = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"] + "/{id}/events", Method.GET);
                requestEvents.AddUrlSegment("id", id);
                var obj = JObject.Parse(response.Content);

                IRestResponse responseEvents = clientEvents.Execute(requestEvents);
                vm.Game = obj["data"].ToObject<Game>();

                if (responseEvents.IsSuccessful)
                {
                    var objEvents = JObject.Parse(responseEvents.Content);
                    vm.Events = objEvents["data"].ToObject<List<Event>>();
                }
                
            }

            return PartialView("GameDetail",vm);
        }

        public JsonResult Delete(int id)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"] + "/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return Json(new { success = true, redirectURL = "/Games/Index" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, redirectURL = "/Games/Index", message = "Game cannot be deleted." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var vm = new GameFormViewModel();
            vm.FormName = "Edit";

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"] + "/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            request.AddParameter("source", "App");

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            { 
                var obj = JObject.Parse(response.Content);            
                vm.Game = obj["data"].ToObject<Game>();
            }

            return PartialView("GameForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(GameFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
                var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"] + "/{id}", Method.PUT);
                request.AddUrlSegment("id", model.Game.GameId);
                request.AddParameter("source", "App", ParameterType.QueryString);

                var json = JsonConvert.SerializeObject(model.Game);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return Json(new { success = true , redirectURL = "/Games/Index"});
                }
            }
            return Json( new {success = false ,view = PartialView("GameForm", model) });  
        }

        public ActionResult Add()
        {
            var vm = new GameFormViewModel();
            vm.FormName = "Add";

            vm.Game = new Game();
            

            return PartialView("GameForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(GameFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(ConfigurationManager.AppSettings["WebApiEndpoint"]);
                var request = new RestRequest(ConfigurationManager.AppSettings["WebApiEndpoint"], Method.POST);
                request.AddParameter("source", "App", ParameterType.QueryString);

                var json = JsonConvert.SerializeObject(model.Game);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return Json(new { success = true, redirectURL = "/Games/Index" });
                }
            }
            return Json(new { success = false, view = PartialView("GameForm", model) });
        }
    }
}