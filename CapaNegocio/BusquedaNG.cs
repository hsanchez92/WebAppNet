using Modelos;
using Respuestas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilerias;

namespace CapaNegocio
{
    public class BusquedaNG
    {

        #region ObjetosDA
        private CapaDatos.ConsumoApi _ObjDatos;
        public CapaDatos.ConsumoApi objDatos
        {
            get
            {
                if (_ObjDatos == null)
                    _ObjDatos = new CapaDatos.ConsumoApi();
                return _ObjDatos;
            }
        }
        #endregion

        #region ObjetosUtilerias
        private Utilerias.Validador _ObjUtil;
        public Utilerias.Validador ObjUtil
        {
            get
            {
                if (_ObjUtil == null)
                    _ObjUtil = new Utilerias.Validador();
                return _ObjUtil;
            }
        }

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
        /// Método de Negocio getInicio() Procesa Datos de Inicio App 
        /// </summary>
        /// <returns>Retorno datos genereales</returns>    
        public Object getInicioNg()
        {
            RespuestaInicioVO respuestaInicioObjeto = new RespuestaInicioVO();
            Object respuesta = null;
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
            LogErrorVO error;
            try
            {

                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.SITES);

                if (ObjUtil.validaConexionServicio(sbUrlCompleta.ToString()))
                {
                    respuestaInicioObjeto = objDatos.getInicioDa();

                    if (!ObjUtil.objetoVacio(respuestaInicioObjeto))
                    {
                        respuesta = registraRespuesta(respuestaInicioObjeto, Constantes.RESULTADO_EXITOSO);
                    }
                    else
                    {
                        respuesta = registraRespuestaVacia(respuestaInicioObjeto, Constantes.RESULTADO_FALLIDO, Constantes.RESULTADO_FALLIDO, MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO);
                    }

                }
                else
                {
                    return ObjUtilLog.logError(Utilerias.Constantes.ERROR_404_CODIGO, Utilerias.Constantes.ERROR_404_MENSAJE, Utilerias.Constantes.ERROR_404_DETALLE);
                }


            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
                return ObjUtilLog.logError(Utilerias.Constantes.ERROR_500_CODIGO, Utilerias.Constantes.ERROR_500_MENSAJE, Utilerias.Constantes.ERROR_500_DETALLE);
            }

            return respuesta;
        }


        /// <summary>
        /// Método de Negocio getBusquedaProducto() Procesa Datos de Busqueda de Producto
        /// </summary>
        /// <parameters name="busqueda">
        /// Objeto de busqueda de algún producto 
        /// </parameters>
        /// <returns>Retorno respuesta de busqueda de producto</returns>
        public string  getBusquedaProductoNg(BusquedaVO busqueda)
        {
            LogErrorVO error;
            RespuestaBusquedaVO respuestaProductoObjeto = new RespuestaBusquedaVO();           
            var url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
            StringBuilder sb = new StringBuilder();
            string respuesta = string.Empty;
            string busquedas = string.Empty;
            string pais = string.Empty;

            try
            {
                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.SITES);

                if (ObjUtil.validaConexionServicio(sbUrlCompleta.ToString()))
                {
                    busquedas = ObjUtil.limpiaPalabra(busqueda.TextoBusqueda);
                    pais = ObjUtil.limpiaPalabra(busqueda.Pais);
                    respuestaProductoObjeto = objDatos.getBusquedaProductoDa(busquedas,pais);
                    if (!ObjUtil.objetoVacio(respuestaProductoObjeto))
                    {
                        
                        string imgProducto;
                        string precio;
                        string descripcion;
                        string informacion;
                        string idProducto;
                        bool   envioGratis;
                        string descripcionProducto;
                        string ciudad;
                        string imgEnvio;
                        string linkProducto; 

                        int registros = respuestaProductoObjeto.results.Count();
                        sb.Append($"<body>");
                        for (int i = 0;  respuestaProductoObjeto.results.Count > i ; i++)
                        {
                            imgProducto = string.Empty;
                            precio = string.Empty;
                            descripcion = string.Empty;
                            informacion = string.Empty;
                            idProducto = string.Empty;
                            envioGratis = false;
                            descripcionProducto = string.Empty;
                            ciudad = string.Empty;
                            imgEnvio = string.Empty;
                            linkProducto = string.Empty;

                            imgProducto = respuestaProductoObjeto.results[i].thumbnail;
                            precio = respuestaProductoObjeto.results[i].price.ToString("C3", CultureInfo.CreateSpecificCulture(obtieneMoneda(busqueda.Pais)));
                            descripcion = respuestaProductoObjeto.results[i].title;
                            idProducto = respuestaProductoObjeto.results[i].id;
                            envioGratis = Convert.ToBoolean(respuestaProductoObjeto.results[i].shipping.free_shipping.ToString());
                            descripcionProducto = respuestaProductoObjeto.results[i].title.ToString();
                            ciudad = respuestaProductoObjeto.results[i].address.state_name.ToString();
       
                            if (envioGratis)
                            {
                              imgEnvio= Constantes.IMGENVIO;
                            }

                            if (idProducto != string.Empty)
                            {
                                linkProducto = $"DetProducto.aspx?id={idProducto} ";
                            }

                            informacion = string.Format($"<div class=\"seccion-producto\">" +
                                                    $"<a class=\"seccion-link\" href={linkProducto}>"+
                                                     $" <div class=\"seccion-Img\">" +
                                                     $"<img class=\"imgProducto\" src={imgProducto}>" +
                                                     $"</div><div class=\"seccion-precio\">" +
                                                     $"<div class=\"precioProducto\">" +
                                                     $"<span>{precio}"  +
                                                     //$"<img src = { imgEnvio } class=\"imgEnvio\" >" +
                                                     $"{imgEnvio}"+
                                                     $"</span></div></div>" +
                                                     $"<div class=\"seccion-detalles\">" +
                                                     $"<div>" +
                                                     $"<span>{descripcionProducto}</span><div><span>CompletoUnico</span></div></div></div>" +
                                                     $"<div class=\"seccion-ciudad\">" +
                                                     $"<div><span>{ciudad}</span>" +
                                                     $"</div></div></div></a>");


                            
                            sb.Append(informacion);

                        }
                        sb.Append("<body>");
                    }
                }

                respuesta = sb.ToString();

            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuesta;
        }


        /// <summary>
        /// Método de Negocio getDetalleProducto() Procesa Datos de Busqueda por Código de Producto
        /// </summary>
        /// <parameters name="codigoProducto">
        /// Objeto de Busqueda por Código de Producto
        /// </parameters>
        /// <returns>Retorno respuesta de busqueda por código de producto</returns> 
        public string getDetalleProductoNg(ProductoVO producto)
        {
            RespuestaDetalleProductoVO respuestaProductoObjeto = new RespuestaDetalleProductoVO();
            RespuestaDetalleDescripcion respuestaDetalleProductoObjeto = new RespuestaDetalleDescripcion();
            StringBuilder sbContenido = new StringBuilder();
            LogErrorVO error;

            string respuesta = string.Empty;
            string informacionDetalle = "";
            string codigoProducto = string.Empty;
            var url= string.Empty;
           
            try
            {
                url = ConfigurationManager.AppSettings["UrlApiMeli"].ToString();
                codigoProducto = ObjUtil.limpiaPalabra(producto.CodigoProducto.ToString());
                StringBuilder sbUrlCompleta = new StringBuilder();
                sbUrlCompleta.Append(url);
                sbUrlCompleta.Append(Constantes.BUSQUEDADETALLE);
                sbUrlCompleta.Append(codigoProducto);

                
                string imagenDetalle;
                string estadoProducto;
                string titulo;
                string precioDetalle;
                string descripcionDetalle;

                if (ObjUtil.validaConexionServicio(sbUrlCompleta.ToString()))
                {
                    
                    respuestaProductoObjeto = objDatos.getDetalleProductoDa(codigoProducto);

                    if (!ObjUtil.objetoVacio(respuestaProductoObjeto))
                    {                       
                        imagenDetalle = string.Empty;
                        estadoProducto = string.Empty; //Nuevo - 234 vendidos
                        titulo = string.Empty;
                        precioDetalle = string.Empty;
                        descripcionDetalle = string.Empty;

                        imagenDetalle = respuestaProductoObjeto.pictures[0].secure_url.ToString();
                        //  estadoProducto = respuestaProductoObjeto.attributes[0].id[0]["ITEM_CONDITION"].  //string.Empty; //Nuevo - 234 vendidos
                        estadoProducto = obtieneCodicionesProducto(respuestaProductoObjeto);// (x => x.id = "ITEM_CONDITION");  //string.Empty; //Nuevo - 234 vendidos
                        titulo = respuestaProductoObjeto.title.ToString();
                        precioDetalle = respuestaProductoObjeto.price.ToString("C3", CultureInfo.CreateSpecificCulture(obtieneMoneda(producto.Pais)));
                        respuestaDetalleProductoObjeto = objDatos.getDetalleDescripcionDa(codigoProducto);

                        if (!ObjUtil.objetoVacio(respuestaDetalleProductoObjeto))
                        {
                            if (respuestaDetalleProductoObjeto.plain_text != Constantes.VACIO)
                            {
                                descripcionDetalle = respuestaDetalleProductoObjeto.plain_text.ToString();
                            }

                        }




                        informacionDetalle = string.Format
                                                   ($" <div class=\"container\">" +
                                                    
                                                    $" <div class=\"seccion-costo\"><div class=\"vendidos\">" +
                                                    $" <p>{estadoProducto}</p></div>" +
                                                    $" <div class=\"descripcionProducto\">" +
                                                    $" <p>{titulo}</p></div>" +
                                                    $" <div class=\"precioDetalle\">" +
                                                    $" <p>{precioDetalle}</p></div>" +
                                                    $" <div class=\"comprar\"><button id=\"btnComprar\" onclick=\"myFunction()\" class=\"estilobtn\">Compar</button></div></div>" +

                                                    $" <div class=\"seccion-imgDetalle\">" +
                                                    $" <img class=\"imgDetalle\" src={imagenDetalle}></div>" +

                                                    $" <div class=\"seccion-Descripcion\"> <div class=\"tituloDescripcion\">" +
                                                    $" <p>Descripción el producto</p> </div>	<div class=\"detalleDescripcion\">" +
                                                    $" <p>{descripcionDetalle}</p> </div> </div>" +
                                                    $"</div>");


                    }

                    sbContenido.Append(informacionDetalle);
                }

                respuesta = sbContenido.ToString();
            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, codigoProducto, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuesta;
        }

        /// <summary>
        /// Método de Negocio generaRespuesta() Crea respuesta 
        /// </summary>
        /// <parameters name="codigoProducto">
        /// Objeto de Busqueda por Código de Producto
        /// </parameters>
        /// <returns>Retorno lista respuesta exitosa</returns> 
        public RespuestaExitosaVO registraRespuesta(Object objeto, string respuestaExitosa)
        {
            LogErrorVO error;
            RespuestaExitosaVO respuestaExitosaObjeto = null;
            try
            {
                respuestaExitosaObjeto = new RespuestaExitosaVO(objeto, respuestaExitosa, Constantes.EXITO_200_CODIGO);
            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, objeto.ToString(), ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuestaExitosaObjeto;
        }

        /// <summary>
        /// Método de Negocio generaRespuestaVacia() Crea respuesta 
        /// </summary>
        /// <parameters name="codigoProducto">
        /// Objeto de Busqueda por Código de Producto
        /// </parameters>
        /// <returns>Retorno objeto respuesta exitosa</returns> 
        public RespuestaExitosaVO registraRespuestaVacia(Object objeto, string respuestaExitosa, string clase, string metodo, string parametro)
        {
            LogErrorVO error;
            RespuestaExitosaVO respuestaExitosaObjeto = null;
            try
            {
                respuestaExitosaObjeto = new RespuestaExitosaVO(objeto, respuestaExitosa, Constantes.EXITO_200_CODIGO);
                ObjUtilLog.resgitroInformacionLog(clase, metodo, parametro);
            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, objeto.ToString(), ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return respuestaExitosaObjeto;
        }


        /// <summary>
        /// Método de Negocio obtiene tipo de  moneda 
        /// </summary>
        /// <parameters name="pais">
        /// País de busqueda
        /// </parameters>
        /// <returns>Retorno tipo de modela del país</returns> 
        public string obtieneMoneda( string pais )
        {
            LogErrorVO error;
            string moneda = string.Empty;
            try
            {
                if (pais == Constantes.MX)
                {
                    moneda = Constantes.MODENAMX;
                }
                else if ( pais == Constantes.AR)
                {
                    moneda = Constantes.MONEDAAR; 
                }
                else
                {
                    moneda = Constantes.MODENAMX;
                }


            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, pais, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return moneda;
        }

        /// <summary>
        /// Método de Negocio Obtiene Condiciones de producto 
        /// </summary>
        /// <parameters name="detalle">
        /// Objeto detalle
        /// </parameters>
        /// <returns>Retornocondiciones de Producto</returns> 
        public string obtieneCodicionesProducto(RespuestaDetalleProductoVO detalle)
        {
            LogErrorVO error;
            string codicionesProducto = string.Empty;
            try
            {

                List<RespuestaDetalleProductoVO.Attributes> lista = new List<RespuestaDetalleProductoVO.Attributes>(detalle.attributes);
                var condicionesLista = lista.FindAll(x =>  x.id == Constantes.CODICIONPRODUCTO);                

                foreach (var informacion in condicionesLista)
                {
                    codicionesProducto= informacion.value_name.ToString();
                }
            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, detalle.ToString(), ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }

            return codicionesProducto;
        }

    }
}
