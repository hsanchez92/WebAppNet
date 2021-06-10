using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppNet
{
    public partial class ValidaPais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pais = "";

            if (Request.QueryString["Pais"] != null)
            {
                pais = Request.QueryString["Pais"].ToString();

                if (pais == "imgMX")
                {
                    System.Web.HttpContext.Current.Session["sessionPais"] = "MX";
                }
                else
                {
                    System.Web.HttpContext.Current.Session["sessionPais"] = "AR";
                }

                Response.Redirect("~/Busqueda.aspx");
            }
        }
    }
}