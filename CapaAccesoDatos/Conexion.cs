using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        private string conexionString;
        private SqlConnection _Conexion { get; set; }
        public SqlConnection _CurrentConexion => this._Conexion;
        public Conexion()
        {
            this.conexionString = ConfigurationManager.AppSettings["ConexionString"];

        }
        public void OpenConexion()
        {
            _Conexion = new SqlConnection(this.conexionString);
            _Conexion.Open();
        }
        public void CloseConexion()
        {
            _Conexion.Close();
        }
    }
}
