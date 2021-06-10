using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class BusquedaVO
    {
        private string textoBusqueda;
        private string pais;

        public BusquedaVO(string textoBusqueda, string pais)
        {
            this.textoBusqueda = textoBusqueda;
            this.pais = pais;
        }

        public string TextoBusqueda
        {
            get { return textoBusqueda; }
            set { textoBusqueda = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

    }
}
