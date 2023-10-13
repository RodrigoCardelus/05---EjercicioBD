using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IPUsuario
    {
        void CrearUsuario(Entidades.Usuario pUsu, Entidades.Usuario pLogueo, int tipo);
        void Logueo(Entidades.Usuario pUsu);
        void AltaEnTabla(Entidades.Usuario pLogueo);

    }
}
