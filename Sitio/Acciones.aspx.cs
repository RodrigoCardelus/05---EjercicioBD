using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Acciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["Logueo"] is Entidades.Usuario))
            Response.Redirect("default.aspx");

    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            //creo objecto con datos
            Entidades.Usuario _unU = new Entidades.Usuario(TxTNombre.Text.Trim(), TxtPass.Text.Trim());

            //llamo al servicio
            Logica.FabricaLogica.GetLUsuario().CrearUsuario(_unU,
                                                           (Entidades.Usuario)Session["Logueo"],
                                                           1);

            //llegue aca - todo OK
            LblError.Text = "Alta con exito - Compruebe en Logueo";
            TxTNombre.Text = "";
            TxtPass.Text = "";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnAltaComun_Click(object sender, EventArgs e)
    {
        try
        {
            //creo objecto con datos
            Entidades.Usuario _unU = new Entidades.Usuario(TxTNombre.Text.Trim(), TxtPass.Text.Trim());

            //llamo al servicio
            Logica.FabricaLogica.GetLUsuario().CrearUsuario(_unU,
                                                           (Entidades.Usuario)Session["Logueo"],
                                                           2);

            //llegue aca - todo OK
            LblError.Text = "Alta con exito - Compruebe en Logueo";
            TxTNombre.Text = "";
            TxtPass.Text = "";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnDeslogueo_Click(object sender, EventArgs e)
    {
        Session["Logueo"] = null;
        Response.Redirect("default.aspx");
    }

    protected void BtnPruebo_Click(object sender, EventArgs e)
    {
        try
        {
            //llamo al servicio
            Logica.FabricaLogica.GetLUsuario().AltaEnTabla((Entidades.Usuario)Session["Logueo"]);

            //llegue aca - todo OK
            LblError.Text = "Probar uso SP con exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }
}