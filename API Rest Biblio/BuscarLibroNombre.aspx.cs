using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API_Rest_Biblio.Controllers;
using ConectaDatos;

namespace API_Rest_Biblio
{
    public partial class BuscarLibroNombre : System.Web.UI.Page
    {
        private IEnumerable<libro> x;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarLibroTitulo.Text.ToString();
            

            BibliotecaController controlador = new BibliotecaController();
            
            
            controlador.GetLibros(nombre);
           
        }

        
    }
}