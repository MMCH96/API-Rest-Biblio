using ConectaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Rest_Biblio.Moldels;
using System.Data.Entity;
using System.Data.SqlClient;

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

        //VISTA GENERAL LIBROS
        [HttpGet]
        [Route("lista/libros")]
        public IEnumerable<libro> GetLibros2()
        {
           
            return this.modelo.GetLibros2();

            
        }

        //VISTA GENERAL AUTORES
        [HttpGet]
        [Route("lista/autores")]
        public IEnumerable<autores1> GetAutores2()
        {

            return this.modelo.GetAutores2();


        }

        //BUSQUEDA POR NOMBRE DE AUTOR

        [HttpGet]
        [Route("busca/autores/nombre/{nombre}")]
        public IEnumerable<autores1> GetAutores(string nombre)
        {
            return modelo.GetAutores(nombre);
        }

        //BUSQUEDA POR IDE DE AUTOR

        [HttpGet]
        [Route("busca/autores/id/{id}")]
        public IEnumerable<autores1> GetAutores3(int id)
        {
            return modelo.GetAutores3(id);
        }

        //BUSQUEDA POR NOMBRE DE LIBRO

        [HttpGet]
        [Route("busca/libros/nombre/{nombre}")]
        public IEnumerable<libro> GetLibros(string nombre)
        {
           return modelo.GetLibros(nombre);
            
        }

        //BUSQUEDA POR ID DE LIBRO

        [HttpGet]
        [Route("busca/libros/id/{id}")]
        public IEnumerable<libro> GetLibros4(int id)
        {
            return modelo.GetLibros4(id);

        }

        //BUSQUEDA POR AUTOR DE LIBRO

        [HttpGet]
        [Route("busca/libros/autor/{autor}")]
        public IEnumerable<libro> GetLibros3(int autor)
        {
            return modelo.GetLibros3(autor);

        }


        //INSERTAR AUTOR NUEVO
        [HttpPost]
        [Route("insertar/autor")]
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
        [Route("insertar/libro")]
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
        [Route("modificar/autor/{id}")]
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
        [Route("modificar/libro/{id}")]
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
        [Route("eliminar/autor/{id}")]
        
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
        [Route("eliminar/libro/{id}")]

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
