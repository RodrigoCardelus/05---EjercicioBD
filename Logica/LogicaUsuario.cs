using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaUsuario : ILUsuario
    {
        //singleton
        private static LogicaUsuario _instancia;
        private LogicaUsuario() { }
        public static LogicaUsuario GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();
            return _instancia;
        }

        //operaciones interface
        public void CrearUsuario(Entidades.Usuario pUsu, Entidades.Usuario pLogueo, int tipo)
        {
            Persistencia.FabricaPersistencia.GetPUsuario().CrearUsuario(pUsu, pLogueo, tipo);
        }

        public void Logueo(Entidades.Usuario pUsu)
        {
            Persistencia.FabricaPersistencia.GetPUsuario().Logueo(pUsu);
        }

        public void AltaEnTabla(Entidades.Usuario pLogueo)
        {
            Persistencia.FabricaPersistencia.GetPUsuario().AltaEnTabla(pLogueo);
        }

    }
}
