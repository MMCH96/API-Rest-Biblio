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
        public IEnumerable<libro> GetLibros(string nombre)
        {
            
            return this.modelo.GetLibros(nombre);
        }

        //Vista Autores

        [HttpGet]
        [Route("api/autores")]
        public IEnumerable<autores1> GetAutores(string nombre)
        {
            return modelo.GetAutores(nombre);
        }


        //VISTA GENERAL

        [HttpGet]
        [Route("api/libros2")]
        public IEnumerable<libro> GetLibros2()
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {

                //return libros.libros.FirstOrDefault(e => e.titulo.Contains(nombre));
                return libros.libros.ToList();
            }
        }

        //INSERTAR AUTOR NUEVO
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

        //INSERTAR LIBRO NUEVO
        [HttpPost]
        [Route("api/insertar/libro")]
        public IHttpActionResult AgregaLibro([FromBody] libro usu)
        {
            if (ModelState.IsValid)
            {
                dbContext.libros.Add(usu);
                dbContext.SaveChanges();
                return Ok(usu);
            }
            else
            {
                return BadRequest();
            }
        }

        //MODIFICAR AUTOR
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

        //MODIFICAR LIBRO
        [HttpPut]
        [Route("api/modificar/libro")]
        public IHttpActionResult Actualizar_Libro(int id, [FromBody] libro usu)
        {
            if (ModelState.IsValid)
            {
                var LibroExiste = dbContext.libros.Count(c => c.id_libro == id) > 0;
                if (LibroExiste)
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

        //ELIMINAR AUTOR
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

        //ELIMINAR LIBRO
        [HttpDelete]
        [Route("api/eliminar/libro")]

        public IHttpActionResult EliminarLibro(int id)
        {
            var usu = dbContext.libros.Find(id);
            if (usu != null)
            {
                dbContext.libros.Remove(usu);
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
