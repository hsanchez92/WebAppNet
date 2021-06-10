using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respuestas
{
    public class RespuestaExitosaVO
    {
        private Object objetoRespuesta;
        private string mensajeRespuesta;
        private string codigoRespuesta;


        public RespuestaExitosaVO(Object objetoRespuesta, string mensajeRespuesta, string cofdigoRespuesta)
        {
            this.objetoRespuesta = objetoRespuesta;
            this.mensajeRespuesta = mensajeRespuesta;
            this.codigoRespuesta = cofdigoRespuesta;
        }

        public string CodigoRespuesta
        {
            get { return codigoRespuesta; }
            set { codigoRespuesta = value; }
        }

        public string MensajeRespuesta
        {
            get { return mensajeRespuesta; }
            set { mensajeRespuesta = value; }
        }

        public Object ObjetoRespuesta
        {
            get { return objetoRespuesta; }
            set { objetoRespuesta = value; }
        }

    }
}
