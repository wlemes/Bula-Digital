using BulaDigital.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BulaDigital.WEB.Controllers
{
    public class BulaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string termo)
        {
            var EmpInfo = new AnvisaResponse();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://bula.vercel.app");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("/pesquisar?nome="+ termo + "&pagina=1");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<AnvisaResponse>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }
    }
}
