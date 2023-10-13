using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILUsuario GetLUsuario()
        {
            return LogicaUsuario.GetInstance();
        }
    }
}
