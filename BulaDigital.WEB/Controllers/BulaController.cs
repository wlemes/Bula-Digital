using BulaDigital.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                if (termo.Contains("'") || termo.Contains("--") || termo.Contains(";") || termo.Contains("=") || termo.Contains("<") || termo.Contains("/"))
                {
                    TempData["mensagemErro"] = "Por favor, não utilize caracteres especiais no campo de busca.";
                    return RedirectToAction("Index");
                }
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
                // if totalElements is 0
                if (EmpInfo.totalElements == 0)
                {
                    TempData["mensagemErro2"] = "Nenhum medicamento encontrado.";
                    return RedirectToAction("Index");
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }

    }
}
