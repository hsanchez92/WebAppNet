using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ProductoVO
    {
        private string codigoProducto;
        private string pais;

        public ProductoVO( string codigoProducto, string pais)
        {
            this.codigoProducto = codigoProducto;
            this.pais = pais; 
        }


        public string CodigoProducto
        {
            get { return codigoProducto; }
            set { codigoProducto = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

    }
}
