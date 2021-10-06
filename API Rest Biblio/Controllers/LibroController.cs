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
    public class LibroController : Controller
    {

        string BaseUrl = "https://localhost:44393/";
        // GET: Libr



        public async Task<ActionResult> Index()
        {
            List<ClaseLibro> EmpInfo = new List<ClaseLibro>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                HttpResponseMessage Res = await cliente.GetAsync("lista/libros/");
                if(Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    EmpInfo = JsonConvert.DeserializeObject<List<ClaseLibro>>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }

        //CREAR LIBRO
        public ActionResult nuevolibro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult nuevolibro(ClaseLibro libro)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/insertar/libro");
                var postTask = cliente.PostAsJsonAsync<ClaseLibro>("libro", libro);
                postTask.Wait();
                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error,algo salio mal.");
            return View(libro);
        }

        //ACTUALIZAR LIBRO  
        public ActionResult Edit(int id)
        {
            ClaseLibro libro = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var responseTask = cliente.GetAsync("busca/libros/id/{id}" + id.ToString());
                //responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClaseLibro>();
                    //readTask.Wait();
                    libro = readTask.Result;

                }

            }
            return View(libro);
        }

        [HttpPost]
        public ActionResult Edit(ClaseLibro libro)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var putTask = cliente.PutAsJsonAsync($"modificar/libro/{ libro.id_libro}", libro);
                putTask.Wait();
                var result = putTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View(libro);
        }


        //BORRAR LIBRO
        public ActionResult Delete(int id)
        {
            ClaseLibro libro = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");

                var responseTask = cliente.GetAsync("busca/libros/id/{id}"+id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClaseLibro>();
                    readTask.Wait();
                    libro = readTask.Result;
                }
                
            }
            return View(libro);
        }

        [HttpPost]
        public ActionResult Delete(ClaseLibro libro, int id)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44393/");
                var deleteTask = cliente.DeleteAsync($"eliminar/libro/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(libro);
        }
    }
}