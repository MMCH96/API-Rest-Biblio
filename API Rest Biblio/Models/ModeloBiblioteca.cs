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
        public libro GetLibros(string nombre)
        {
            using (bibliotecaEntities libros = new bibliotecaEntities())
            {
                return libros.libros.FirstOrDefault(e => e.titulo.Contains(nombre));
                //return libros.libros.ToList();
            }
        }

        //GET AUTORES
        public autores1 GetAutores(string nombre)
        {
            using (bibliotecaEntities autores = new bibliotecaEntities())
            {
                return autores.autores1.FirstOrDefault(e => e.nomb_comp.Contains(nombre));
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