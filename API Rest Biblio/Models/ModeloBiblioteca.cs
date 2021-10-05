using ConectaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        //BUSCAR LIBROS POR Autor
        public IEnumerable<libro> GetLibros3(int autor)
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {

                return libros.libros.ToList().Where(e => e.id_autor == autor);
            }
        }

        //VISTA GENERAL
        public IEnumerable<libro> GetLibros2()
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {

                //return libros.libros.FirstOrDefault(e => e.titulo.Contains(nombre));
                return libros.libros.ToList();
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

        


       

        

    }
}