using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilerias;
using CapaNegocio;
using Modelos;
using Respuestas;
using System.Reflection;

namespace WebAppNet
{
    public partial class _Default : Page
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

        #region ObjetosNegocio
        private CapaNegocio.BusquedaNG  _ObjNegocio;
        public CapaNegocio.BusquedaNG    ObjNegocio
        {
            get
            {
                if (_ObjNegocio == null)
                    _ObjNegocio = new CapaNegocio.BusquedaNG();
                return _ObjNegocio;
            }
        }
        #endregion

        public string _ContenidoBusqueda = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string busqueda = string.Empty;
            LogErrorVO error;
            try
            {
                if (Request.QueryString["Buscar"] != null && Session["sessionPais"] != null)
                {
                    busqueda = Request.QueryString["Buscar"].ToString();
                    BusquedaVO ObjetoBusqueda = new BusquedaVO(busqueda, Session["sessionPais"].ToString());
                    _ContenidoBusqueda = ObjNegocio.getBusquedaProductoNg(ObjetoBusqueda);

                    if (_ContenidoBusqueda == string.Empty)
                    {
                        _ContenidoBusqueda = Validador.Mensajes.MENSAJESINPRODUCTOS;
                    }
                }
            }
            catch(Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }
            
        }

        #region Metodos
      
        #endregion

    }
}