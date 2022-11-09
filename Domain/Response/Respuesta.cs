using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class Respuesta
    {
         public int Exito { get; set; }
         public string Mensaje { get; set; } = string.Empty;
        public object Data { get; set; } = null;

        public Respuesta()
        {
            this.Exito = 0;
        }

    }
}
