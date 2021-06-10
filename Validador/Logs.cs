using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilerias
{
    public class Logs
    {
        log4net.ILog log = log4net.LogManager.GetLogger("DebugAppender");


        ///<summary>
        ///Método para registrar el log de una excepción 
        ///</summary>
        ///<param name="error">
        ///Objeto de log de Erros con información del erroro
        ///</param>
        public void resgitroErrorParametrosLog(LogErrorVO error)
        {
            try
            {

                log.Error(string.Format("Clase: {0}", error.Clase));
                log.Error(string.Format("Metodo:  {0}", error.Metodo));
                log.Error(string.Format("Parametros:  {0}", error.Parametros));
                log.Error(string.Format("MensajeError: {0}", error.Error));
            }
            catch (Exception ex)
            {
                String detalleErroLog = ex.ToString();
                log.Error(string.Format("Clase: {0}", MethodBase.GetCurrentMethod().Name.ToString()));
                log.Error(string.Format("Metodo:  {0}", MethodBase.GetCurrentMethod().DeclaringType.Name));
                log.Error(string.Format("MensajeError: {0}", detalleErroLog));
            }

        }

        public Object logError(string codigo, string mensaje, string detalle)
        {
            return new ErrorVO(codigo, mensaje, detalle);
        }


        public void resgitroInformacionLog(string nombreClase, string nombreMetodo, string parametros)
        {
            string nombreClaseLog = "";
            try
            {
                nombreClaseLog = this.GetType().FullName;
                log.Info(string.Format("Clase: {0}", nombreClase));
                log.Info(string.Format("Metodo:  {0}", nombreMetodo));
                log.Info(string.Format("Parametros: {0}", parametros));

            }
            catch (Exception ex)
            {
                String detalleErroLog = ex.ToString();
                log.Error(string.Format("Clase: {0}", MethodBase.GetCurrentMethod().Name.ToString()));
                log.Error(string.Format("Metodo:  {0}", MethodBase.GetCurrentMethod().DeclaringType.Name));
                log.Error(string.Format("MensajeError: {0}", detalleErroLog));
            }

        }
    }
}
