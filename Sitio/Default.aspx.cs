using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Logueo1_Loguearse(string pUsu, string pPass)
    {
        try
        {
            //creo objecto con datos
            Entidades.Usuario _unU = new Entidades.Usuario(pUsu, pPass);

            //llamo al servicio
            Logica.FabricaLogica.GetLUsuario().Logueo(_unU);

            //dejo usuario logueado en session
            Session["Logueo"] = _unU;

            //llegue aca - todo OK
            Response.Redirect("Acciones.aspx");

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
 
}