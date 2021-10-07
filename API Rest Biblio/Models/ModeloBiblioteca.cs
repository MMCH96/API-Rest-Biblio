using ConectaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace API_Rest_Biblio.Moldels
{

    public class ModeloBiblioteca
    {
        private bibliotecaEntities dbContext = new bibliotecaEntities();
        bibliotecaEntities entidad;

        public ModeloBiblioteca()
        {
            this.entidad = new bibliotecaEntities();

        }

        //BUSCAR LIBROS POR NOMBRE
        public IEnumerable<libro> GetLibros(string nombre)
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {
                
               
                return libros.libros.ToList().Where(e => e.titulo.Contains(nombre));
                
                
            }
        }

        //BUSCAR LIBROS POR ID
        public IEnumerable<libro> GetLibros4(int id)
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {


                return libros.libros.ToList().Where(e => e.id_libro == id);


            }
        }

        //BUSCAR LIBROS POR Autor
        public IEnumerable<libro> GetLibros3(int autor)
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {

                return libros.libros.ToList().Where(e => e.id_autor == autor);
            }
        }

        //VISTA GENERAL LIBROS
        public IEnumerable<libro> GetLibros2()
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {
                //return libros.libros.FirstOrDefault(e => e.titulo.Contains(nombre));
                return libros.libros.ToList();
            }

        }


        //VISTA GENERAL AUTORES
        public IEnumerable<autores1> GetAutores2()
        {
            using (bibliotecaEntities autores1 = new bibliotecaEntities())
            {
                //return libros.libros.FirstOrDefault(e => e.titulo.Contains(nombre));
                return autores1.autores1.ToList();
            }

        }
        private libro view()
        {
            throw new NotImplementedException();
        }

        //BUSCAR AUTORES POR NOMBRE
        public IEnumerable<autores1> GetAutores(string nombre)
        {
            using (bibliotecaEntities autores = new bibliotecaEntities())
            {
                return autores.autores1.ToList().Where(e => e.nomb_comp.Contains(nombre));
            }
        }

        //BUSCAR AUTORES POR ID
        public IEnumerable<autores1> GetAutores3(int id)
        {
            using (bibliotecaEntities autores = new bibliotecaEntities())
            {
                return autores.autores1.ToList().Where(e => e.id_autor == id);
            }
        }






    }
}