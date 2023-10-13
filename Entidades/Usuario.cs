using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        //atributos
        private string _Nom;
        private string _Pass;

        //propiedades
        public string Nom
        {
            get { return _Nom; }

            set
            {
                if (value.Length <= 20)
                    _Nom = value;
                else
                    throw new Exception("En la bd esperan hasta 20 caracteres,");
            }
        }

        public string Pass
        {
            get { return _Pass; }

            set
            {
                if (value.Length <= 10)
                    _Pass = value;
                else
                    throw new Exception("En la bd esperan hasta 20 caracteres,");
            }
        }

        //construtor
        public Usuario(string pNom, string pPass)
        {
            Nom = pNom;
            Pass = pPass;
        }
    }
}
