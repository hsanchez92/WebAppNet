using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilerias;

namespace WebAppNet
{
    public partial class DetProducto : System.Web.UI.Page
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
        private CapaNegocio.BusquedaNG _ObjNegocio;
        public CapaNegocio.BusquedaNG ObjNegocio
        {
            get
            {
                if (_ObjNegocio == null)
                    _ObjNegocio = new CapaNegocio.BusquedaNG();
                return _ObjNegocio;
            }
        }
        #endregion

        public string _ContenidoDetalle = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idProducto = "";
            LogErrorVO error;
            try
            {
                if (Request.QueryString["id"] != null && Session["sessionPais"] != null)
                {
                    idProducto = Request.QueryString["id"].ToString();
                    Modelos.ProductoVO ObjetoProducto = new Modelos.ProductoVO(idProducto, Session["sessionPais"].ToString());
                    _ContenidoDetalle = ObjNegocio.getDetalleProductoNg(ObjetoProducto);

                    if (_ContenidoDetalle == string.Empty)
                    {
                        _ContenidoDetalle = Validador.Mensajes.MENSAJESINPRODUCTOS;
                    }

                }

            }
            catch (Exception ex)
            {
                error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                ObjUtilLog.resgitroErrorParametrosLog(error);
            }
        }
    }
}