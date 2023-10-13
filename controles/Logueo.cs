using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace controles
{
    //el delegado debe informar del contexto del evento: usuario y contraseña que
    //se quiere usar para el logueo

    public delegate void EHLogueo(string pUsu, string pPass);

    public class Logueo:WebControl,INamingContainer
    {
        //atributos - controles contenidos
        private TextBox _CajaUsu;
        private TextBox _CajaPass;
        private Button _BotonLogueo;
        private Panel _panel;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //primero creo el panel para poder agregarle los controles contenidos
            _panel = new Panel();

            //creo los controles contenidos
            _CajaUsu = new TextBox();
            _CajaUsu.Height = Unit.Pixel(15);
            _CajaUsu.Width = Unit.Pixel(100);
            _panel.Controls.Add(new LiteralControl("Usuario: "));
            _panel.Controls.Add(_CajaUsu);

            _CajaPass = new TextBox();
            _CajaPass.Height = Unit.Pixel(15);
            _CajaPass.Width = Unit.Pixel(100);
            _CajaPass.TextMode = TextBoxMode.Password; 
            _panel.Controls.Add(new LiteralControl("<BR/>"));
            _panel.Controls.Add(new LiteralControl("Pass: "));
            _panel.Controls.Add(_CajaPass);

            //el boton anzara un evento, para que el fomulario que contenga este 
            //control, pueda asignar un controlador propio
            _BotonLogueo = new Button();
            _BotonLogueo.Text = "Ingresar";
            _BotonLogueo.Click += new EventHandler(ControladorLogueo);
            _panel.Controls.Add(new LiteralControl("<BR/>"));
            _panel.Controls.Add(_BotonLogueo);

            this.Controls.Add(_panel);

        }

        private void ControladorLogueo(object sender, EventArgs e)
        {
            //provoca el evento del composite control, para que cualquier formulario
            // que contenga un objeto de este control, pueda asignarle por medio de un
            // delegado el controlador 

            Loguearse(_CajaUsu.Text.Trim(), _CajaPass.Text.Trim());
            //le debo pasar los datos, que me pide el delegado, para 
                        // pasarselos al controlador asignado al evento de un objeto
                        //de esta clase
        }

        //evento del control que captura el formulario
        public event EHLogueo Loguearse;



    }
}
