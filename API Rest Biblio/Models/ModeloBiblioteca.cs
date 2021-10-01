using ConectaDatos;
using System;
using System.Collections.Generic;
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

        //GET LIBROS
        public List<libro> GetLibros()
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {
                return libros.libros.ToList();
            }
        }

        //GET AUTORES
        public List<autores1> GetAutores()
        {
            using (bibliotecaEntities autores = new bibliotecaEntities())
            {
                return autores.autores1.ToList();
            }
        }

        //GET VISTA GENERAL
        /* public List<> GetVista()
         {
             using (bibliotecaEntities autores = new bibliotecaEntities())
             {
                 return autores.autores1.ToList();
             }
         }*/


        //POST NUEVO LIBRO

        

    }
}