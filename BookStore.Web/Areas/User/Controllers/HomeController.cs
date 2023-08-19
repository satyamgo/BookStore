using BookStore.Core.Entities.Models;
using BookStore.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace BookStore.Web.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        HttpClient _client;
        IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(configuration["ApiAddress"]);
        }

        private IEnumerable<StatusModel> GetStatus()
        {
            IEnumerable<StatusModel> categories = new List<StatusModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/status/get").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                categories = JsonSerializer.Deserialize<IEnumerable<StatusModel>>(data,options);
            }
            return categories;
        }
        public IActionResult Index()
        {
            IEnumerable<Bookitem> products = new List<Bookitem>();
            var response = _client.GetAsync(_client.BaseAddress + "/items/getbystatus").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                products = JsonSerializer.Deserialize<IEnumerable<Bookitem>>(data,options);
            }

            return View(products);

        }
        public IActionResult Create()
        {
           
           ViewBag.Status=GetStatus();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bookitem model)
        {
            if (ModelState.IsValid)
            {
                string strdata = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strdata, Encoding.UTF8, "application/json");
                var response1 = _client.PostAsync(_client.BaseAddress + "/items/add", content).Result;
                if (response1.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }           
            ViewBag.Status = GetStatus();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Status = GetStatus();
            Bookitem model = new Bookitem();
            var response = _client.GetAsync(_client.BaseAddress + "/items/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                model = JsonSerializer.Deserialize<Bookitem>(data, options);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Bookitem model)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");

                var response = _client.PutAsync(_client.BaseAddress + "/items/update/" + model.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Status = GetStatus();
            return View();
        }



    }
}
