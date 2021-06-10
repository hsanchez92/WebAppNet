using Modelos;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI;
using Utilerias;

namespace WebAppNet
{
    public partial class SiteMaster : MasterPage
    {
        #region Utilerias
        private Utilerias.Validador _objValidador;

        private Utilerias.Validador ObjValidador
        {
            get
            {
                if (_objValidador == null)
                    _objValidador = new Utilerias.Validador();
                return _objValidador;
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
        public string contenidoPaises = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                if(Session["sessionPais"] == null)
                {
                    System.Web.HttpContext.Current.Session["sessionPais"] =Constantes.MX;
                    validaPaises();
                }
                else
                {
                    validaPaises();
                }

            }

        }

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {
            LogErrorVO error;
            if (busqueda.Value.ToString() != Constantes.VACIO)
            {
                try
                {
                    var buscar = ObjValidador.validaQueryString(busqueda.Value.ToString());
                    Response.Redirect(Constantes.BUSQUEDA + buscar, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    error = new LogErrorVO(MethodBase.GetCurrentMethod().Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Name, Constantes.VACIO, ex.ToString());
                    ObjUtilLog.resgitroErrorParametrosLog(error);
                }
            }

        }

        
        public void validaPaises() {  
         

            string seleccioandoMX = string.Empty;
            string seleccioandoAR = string.Empty;
            string imgArg = string.Empty;
            string imgMex = string.Empty; 

            if (Session["sessionPais"].ToString() == Constantes.MX)
            {
                seleccioandoMX = Constantes.SELECCIONADO;
                imgArg =Constantes.IMG_AR_DESHABILITADA ;
                imgMex =Constantes.IMG_MX_HABILITADA ;

            }
            else if (Session["sessionPais"].ToString() == Constantes.AR)
            {
                seleccioandoAR = Constantes.SELECCIONADO;
                imgArg =Constantes.IMG_AR_HABILITADA;     
                imgMex =Constantes.IMG_MX_DESHABILITADA; 
            }

            contenidoPaises = string.Format($" <div id=\"dPaises\" class=\"seccion-paises\"> "+
                                          $" <div class=\"seccion-banderas\"> "+
                                          $" <input type = \"radio\" name=\"pais\" value=\"mx\" id=\"btnMX\"{seleccioandoMX}/> " +
                                          $" <img id = \"imgMX\" src=\"Imagenes/Paises/{imgMex}\" class=\"imgPaises\" "+ 
                                          $" onmouseover=\"overPais(this)\""+
                                          $" onmouseout=\"outPais(this)\""+
                                          $" onclick=\"seleccionaPais(this)\"></div> "+
                                          $" <div class=\"seccion-banderas\"> "+
                                          $" <input type = \"radio\" name=\"pais\" value=\"ar\" id=\"btnAR\"{seleccioandoAR}/> " +
                                          $" <img id = \"imgAR\" src=\"Imagenes/Paises/{imgArg}\" class=\"imgPaises\" "+ 
                                          $" onmouseover=\"overPais(this)\""+ 
                                          $" onmouseout=\"outPais(this)\""+
                                          $" onclick=\"seleccionaPais(this)\"> </div> </div>");
        }

        
    }
}