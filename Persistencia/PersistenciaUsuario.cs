using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaUsuario: IPUsuario
    {
        //singleton
        private static PersistenciaUsuario _instancia;
        private PersistenciaUsuario() { }
        public static PersistenciaUsuario GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaUsuario();
            return _instancia;
        }
        
        
        //operaciones interface
        public void CrearUsuario(Entidades.Usuario pUsu,Entidades.Usuario pLogueo, int tipo)
        {
            //-----------------------------------------------
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo)); //uso usuario para logueo

            //defino SP a invocar
            SqlCommand _comando;
            if (tipo == 1) //damos de alta admin de seguridad
                _comando = new SqlCommand("CreoUsuario", _cnn);
            else //damos de alta usuario comun
                _comando = new SqlCommand("CreoUsuarioComun", _cnn);
            //-----------------------------


            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@nomU", pUsu.Nom);
            _comando.Parameters.AddWithValue("@passU", pUsu.Pass);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                // conecto a la bd
                _cnn.Open();

                //ejecuto comando de creacion de usuarios SQLServer
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int _Codcli = Convert.ToInt32(_ParmRetorno.Value);
                if(_Codcli == -1)
                    throw new Exception("Usuario existente");
                else if (_Codcli == -2)
                    throw new Exception("No se puede Crear usuario Login");
                else if (_Codcli == -3)
                    throw new Exception("No se puede crear usuario BD");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }
        public void Logueo(Entidades.Usuario pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
 
            try
            {
                // conecto a la bd - sino tengo permiso de conexion o no existe usuario da exception
                _cnn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }
        public void AltaEnTabla(Entidades.Usuario pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("AltaTabla", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

    }
}
