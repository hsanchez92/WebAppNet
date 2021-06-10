using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilerias
{
    public class Validador
    {
        log4net.ILog log = log4net.LogManager.GetLogger("DebugAppender");

        ///<summary>
        ///Método para limpiar palabras de caracteres  
        ///</summary>
        ///<param name="palabra">
        ///string de palabra a limpiar 
        ///</param>
        ///<return>Devuelve palabra si caracteres</return>       
        public string limpiaPalabra(string palabra)
        {
            return new string(palabra.Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
            || (c >= 'a' && c <= 'z') || (c == '.') || (c == '_') || (c == ' ')).ToArray());
        }


        ///<summary>
        ///Método para validar si un objeto esta vacio
        ///</summary>
        ///<param name="obj">
        ///Object objeto
        ///</param>
        ///<return>Devuelve true si el objeto esta vacio si no devuelve false</return>   
        public bool objetoVacio(Object obj)
        {
            bool respuesta = false;
            if(obj == null)
            {
                if((string)obj == string.Empty)
                {
                    respuesta = true; 
                }
            }
            return respuesta;
        }

        ///<summary>
        ///Método para validar si una lista esta vacio
        ///</summary>
        ///<param name="lista">
        ///Object objeto
        ///</param>
        ///<return>Devuelve true si la lista esta vacia si no devuelve false</return>   
        public bool listaVacia<T>(List<T> lista)
        {
            bool respuesta = true;
            if (lista != null)
            {
                if (lista.Any() != true)
                {
                    if (lista.Count > 0)
                    {
                        respuesta = false;
                    }
                }
            }
            return respuesta;
        }

        ///<summary>
        ///Método para validar si un endpoint esta disponible para su consumo 
        ///</summary>
        ///<param name="url">
        ///string de la url del endpoint
        ///</param>
        ///<return>Devuelve true si el endpoint esta disponible o un false de lo contrario</return>  
        public bool validaConexionServicio(string url)
        {
            bool respuesta = false;
            WebClient servicio = null;
            LogErrorVO error;
            try
            {
                servicio = new WebClient();
                var resultData = servicio.DownloadString(url);
                respuesta = true;
            }
            catch (ArgumentNullException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, url, ex.ToString());
                resgitroErrorParametrosLog(error);
            }
            catch (WebException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), url, ex.ToString());
                resgitroErrorParametrosLog(error);
            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, url, ex.ToString());
                resgitroErrorParametrosLog(error);
            }
            finally
            {
                servicio?.Dispose();
            }

            return respuesta;

        }

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
                log.Error(string.Format("Clase: {0}", MethodBase.GetCurrentMethod().DeclaringType));
                log.Error(string.Format("Metodo:  {0}", MethodBase.GetCurrentMethod().DeclaringType.Name));
                log.Error(string.Format("MensajeError: {0}", detalleErroLog));
            }

        }

        ///<summary>
        ///Método para validar un Query String
        ///</summary>
        ///<param name="queryString">
        ///String validado
        ///</param>
        public string validaQueryString(object queryString)
        {
            if (queryString == null)
                return string.Empty;
            try
            {
                var tagWithoutClosingRegex = new Regex(@"<[^>]+>");
                var hasTags = tagWithoutClosingRegex.IsMatch(queryString.ToString());
                return !hasTags ? queryString.ToString() : string.Empty;
            }
            catch { return string.Empty; }

        }
    }
}
