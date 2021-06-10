using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilerias
{
    public class Constantes
    {
        #region contantes EndPoint
        public static string SITES = "/sites/";
        public static string MLA = "MLA";
        public static string MLM = "MLM";
        public static string SEARCH = "/search?q=$";
        public static string DESCRIPCION = "/description";

        public static string GENERAL = "/sites/MLA/";

        public static string BUSQUEDAPRODUCTO = "/sites/MLA/search?q=$";
        public static string BUSQUEDADETALLE = "/items/";
        public static string BUSQUEDADET = "/items/MLA00000";
        #endregion

        #region contantes Generales
        public static string VACIO = "";
        public static string BUSQUEDA = "~/Busqueda.aspx?Buscar=";
        public static string IMGENVIO = $"<img src = \"Imagenes/ic_shipping@2x.png\" class=\"imgEnvio\" >";
        public static string MX = "MX";
        public static string MODENAMX = "es-MX";
        public static string AR = "AR";
        public static string MONEDAAR = "es-AR";
        public static string SELECCIONADO= " checked=\"true\" ";
        public static string IMG_MX_HABILITADA= "MX_Habilitado.png";
        public static string IMG_MX_DESHABILITADA= "MX_Deshabilitado.png";
        public static string IMG_AR_HABILITADA= "AR_Habilitado.png";
        public static string IMG_AR_DESHABILITADA= "AR_Deshabilitado.png";
        public static string CODICIONPRODUCTO= "ITEM_CONDITION";  
        #endregion


        #region contantes Mensajes
        
        public static string ERROR_400_CODIGO = "400";
        public static string ERROR_400_MENSAJE = "Petición invalida";
        public static string ERROR_400_DETALLE = "[Parametros de entrada son requeridos]";

        public static string ERROR_404_CODIGO = "404";
        public static string ERROR_404_MENSAJE = "Petición invalida";
        public static string ERROR_404_DETALLE = "[El Servicio MELI no existe]";

        public static string ERROR_500_CODIGO = "500";
        public static string ERROR_500_MENSAJE = "Error inesperado en la aplicación.";
        public static string ERROR_500_DETALLE = "[ \"Error inesperado en la aplicación\" ]";
        public static string ERROR_500_URL = "error";

        public static string EXITO_200_CODIGO = "200";
        public static string RESULTADO_EXITOSO = "Resultado EXITOSO!";
        public static string RESULTADO_FALLIDO = "Resultado FALLIDO!";

        #endregion
    }
}
