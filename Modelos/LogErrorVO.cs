using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class LogErrorVO
    {
            private string clase;
            private string metodo;
            private string parametros;
            private string error;

            public LogErrorVO() { }

            public LogErrorVO(string clase, string metodo, string parametros, string error)
            {
                this.clase = clase;
                this.metodo = metodo;
                this.parametros = parametros;
                this.error = error;

            }

            public string Clase
            {
                get { return clase; }
                set { clase = value; }
            }

            public string Metodo
            {
                get { return clase; }
                set { clase = value; }
            }

            public string Parametros
            {
                get { return parametros; }
                set { parametros = value; }
            }

            public string Error
            {
                get { return error; }
                set { error = value; }
            }
        }
}
