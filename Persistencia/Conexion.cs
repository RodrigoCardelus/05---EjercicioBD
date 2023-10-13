using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        internal static string Cnn(Entidades.Usuario pUsu = null)
        {
            if (pUsu == null)
                return "Data Source =.; Initial Catalog = EjemploExtraBD; Integrated Security = true";
            else
                return "Data Source =.; Initial Catalog = EjemploExtraBD; User=" + pUsu.Nom + "; Password='" + pUsu.Pass + "'";
        }
    }
}
