using ConsumirApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumirApi.Controllers
{
    public class LibrosController : Controller
    {

        string BaseURL = "https://localhost:44393/";

        public async Task<ActionResult> Index()
        {
            List<Libros> EmpInfo = new List<Libros>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/libros2/");
                if(Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Libros>>(EmpResponse);

                }
                return View(EmpInfo);
            }
            

        }

        // GET: Libros
        /*public ActionResult Index()
        {
            return View();
        }*/
    }
}