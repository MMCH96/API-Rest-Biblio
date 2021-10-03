using ConectaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Rest_Biblio.Moldels;
using System.Data.Entity;

namespace API_Rest_Biblio.Controllers
{
    public class BibliotecaController : ApiController
    {

        private bibliotecaEntities dbContext = new bibliotecaEntities();
        ModeloBiblioteca modelo;
        public BibliotecaController()
        {
            this.modelo = new ModeloBiblioteca();
        }

        //Vista Libros
        [HttpGet]
        [Route("api/libros")]
        public libro GetLibros(string nombre)
        {
            
            return this.modelo.GetLibros(nombre);
        }

        //Vista Autores

        [HttpGet]
        [Route("api/autores")]
        public autores1 GetAutores(string nombre)
        {
            return modelo.GetAutores(nombre);
        }


        [HttpPost]
        [Route("api/insertar/autor")]
        public IHttpActionResult AgregaAutor([FromBody] autores1 usu)
        {
            if (ModelState.IsValid)
            {
                dbContext.autores1.Add(usu);
                dbContext.SaveChanges();
                return Ok(usu);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/modificar/autor")]
        public IHttpActionResult Actualizar_Autor(int id,[FromBody]autores1 usu)
        {
            if (ModelState.IsValid)
            {
                var AutorExiste = dbContext.autores1.Count(c => c.id_autor == id) > 0;
                if(AutorExiste)
                {
                    dbContext.Entry(usu).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();

                }
            }
            else
            {

                return BadRequest();
            }
        }

        //DELETE AUTOR
        [HttpDelete]
        [Route("api/eliminar/autor")]
        
        public IHttpActionResult EliminarAutor(int id)
        {
            var usu = dbContext.autores1.Find(id);
            if(usu != null)
            {
                dbContext.autores1.Remove(usu);
                dbContext.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }


    }
}
