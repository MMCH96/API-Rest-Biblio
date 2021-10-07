using API_Rest_Biblio.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_Rest_Biblio.Controllers
{
    public class AutoresController : Controller
    {
        string BaseUrl = "https://localhost:44393/";

        public async Task<ActionResult> Index()
        {
            List<ClaseAutores> EmpInfo = new List<ClaseAutores>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                HttpResponseMessage Res = await cliente.GetAsync("lista/autores/");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    EmpInfo = JsonConvert.DeserializeObject<List<ClaseAutores>>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }

        //CREAR LIBRO
        public ActionResult nuevoautor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult nuevoautor(ClaseAutores autor)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/insertar/libro");
                var postTask = cliente.PostAsJsonAsync<ClaseAutores>("autor", autor);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error,algo salio mal.");
            return View(autor);
        }


        //ACTUALIZAR AUTOR
        public ActionResult Edit(int id)
        {
            ClaseAutores autor = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var responseTask = cliente.GetAsync("busca/autores/id/{id}" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ClaseAutores>();
                    readTask.Wait();
                    autor = readTask.Result;
                    return View(autor);
                }

            }
            return View(autor);
        }

        [HttpPost]
        public ActionResult Edit(ClaseAutores autor)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var putTask = cliente.PutAsJsonAsync($"modificar/autor/{ autor.id_autor}", autor);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(autor);
        }


        //BORRAR LIBRO
        public ActionResult Delete(int id)
        {
            ClaseAutores autor = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");

                var responseTask = cliente.GetAsync("busca/autor/{id}" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClaseAutores>();
                    readTask.Wait();
                    autor = readTask.Result;
                }

            }
            return View(autor);
        }

        [HttpPost]
        public ActionResult Delete(ClaseAutores autor, int id)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var deleteTask = cliente.DeleteAsync($"eliminar/autor/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(autor);
        }
    }
}