using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumirApi.Models
{
    public class Libros
    {
        public int id_libro { get; set; }
        public int id_autor { get; set; }
        public string titulo { get; set; }
        public string fecha_lanz { get; set; }
        public string editoria { get; set; }
        public string idioma { get; set; }
        public string paginas { get; set; }
        public byte[] portada { get; set; }

    }
}