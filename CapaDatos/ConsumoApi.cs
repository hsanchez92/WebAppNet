using Modelos;
using Newtonsoft.Json;
using Respuestas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilerias;

namespace CapaDatos
{
    public class ConsumoApi
    {
        #region ObjetosUtilerias 
        private Utilerias.Logs _ObjUtilLog;
        public Utilerias.Logs ObjUtilLog
        {
            get
            {
                if (_ObjUtilLog == null)
                    _ObjUtilLog = new Utilerias.Logs();
                return _ObjUtilLog;
            }
        }
        #endregion


        /// <summary>
        /// Método de Datos getInicio() Obtiene Datos de Inicio desde Servicio MELI
        /// </summary>
        /// <returns>Retorno datos genereales de Servicio MELI</returns>  
        public RespuestaInicioVO getInicioDa()
        {
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString() + Constantes.GENERAL;
            var respuestaObjeto = new RespuestaInicioVO();
            LogErrorVO error;
            try
            {

                HttpWebRequest requests = (HttpWebRequest)WebRequest.Create(url);
                requests.Method = "GET";
                requests.ContentType = "application/json";
                requests.Accept = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)requests.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    respuestaObjeto = JsonConvert.DeserializeObject<RespuestaInicioVO>(json);
                }

            }
            catch (WebException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuestaObjeto;

        }

        /// <summary>
        /// Método de Datos getBusquedaProducto() Obtiene Respuesta de Busqueda de Producto en Servicio MELI
        /// </summary>
        /// <parameters name="busqueda">
        /// String de Busqueda de algún producto cosumiendo Servicio MELI
        /// </parameters>
        /// <returns>Retorno respuesta de busqueda de producto</returns>  
        public RespuestaBusquedaVO getBusquedaProductoDa(string busquedas,string pais)
        {
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
            var respuesta = new RespuestaBusquedaVO();
            LogErrorVO error;
            try
            {
                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.SITES);
                if (pais == Constantes.MX)
                {
                    sbUrlCompleta.Append(Constantes.MLM);
                }
                else if (pais == Constantes.AR)
                {
                    sbUrlCompleta.Append(Constantes.MLA);
                }
                
                //sbUrlCompleta.Append(Constantes.BUSQUEDAPRODUCTO);
                sbUrlCompleta.Append(Constantes.SEARCH);
                sbUrlCompleta.Append(busquedas);

                HttpWebRequest requests = (HttpWebRequest)WebRequest.Create(sbUrlCompleta.ToString());
                requests.Method = "GET";
                requests.ContentType = "application/json";
                requests.Accept = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)requests.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    respuesta = JsonConvert.DeserializeObject<RespuestaBusquedaVO>(json);
                }

            }
            catch (WebException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, busquedas, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuesta;

        }

        /// <summary>
        /// Método de Datos getDetalleProducto() Obtiene Respuesta de Busqueda por Código de Producto en Servicio MELI
        /// </summary>
        /// <parameters name="codigoProducto">
        /// String de Busqueda por Código de Producto por Servicio MELI
        /// </parameters>
        /// <returns>Retorno respuesta de busqueda por código de producto</returns>
        public RespuestaDetalleProductoVO getDetalleProductoDa(string codigoProducto)
        {
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
            var respuesta = new RespuestaDetalleProductoVO();
            LogErrorVO error;
            try
            {

                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.BUSQUEDADETALLE);
                sbUrlCompleta.Append(codigoProducto);

                HttpWebRequest requests = (HttpWebRequest)WebRequest.Create(sbUrlCompleta.ToString());
                requests.Method = "GET";
                requests.ContentType = "application/json";
                requests.Accept = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)requests.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    respuesta = JsonConvert.DeserializeObject<RespuestaDetalleProductoVO>(json);
                }

            }
            catch (WebException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, codigoProducto, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuesta;

        }


        /// <summary>
        /// Método de Datos getDetalleDescripcionDa() Obtiene Respuesta de Detalle de un producto con Servicio MELI
        /// </summary>
        /// <parameters name="codigoProducto">
        /// String de Busqueda detalle por Código de Producto por Servicio MELI
        /// </parameters>
        /// <returns>Retorno respuesta de busqueda de detalle por código de producto</returns>
        public RespuestaDetalleDescripcion getDetalleDescripcionDa(string codigoProducto)
        {
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
            var respuesta = new RespuestaDetalleDescripcion();
            LogErrorVO error;
            try
            {

                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.BUSQUEDADETALLE);
                sbUrlCompleta.Append(codigoProducto);
                sbUrlCompleta.Append(Constantes.DESCRIPCION);

                HttpWebRequest requests = (HttpWebRequest)WebRequest.Create(sbUrlCompleta.ToString());
                requests.Method = "GET";
                requests.ContentType = "application/json";
                requests.Accept = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)requests.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    respuesta = JsonConvert.DeserializeObject<RespuestaDetalleDescripcion>(json);
                }

            }
            catch (WebException ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, codigoProducto, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuesta;

        }


    }
}
