using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ErrorVO
    {
        private string codigo;
        private string mensaje;
        private string detalles;
        public ErrorVO() { }

        public ErrorVO(string codigo, string mensaje, string detalles)
        {
            this.codigo = codigo;
            this.mensaje = mensaje;
            this.detalles = detalles;
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
    }
}
