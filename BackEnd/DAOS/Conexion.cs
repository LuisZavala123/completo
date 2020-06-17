using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackEnd.DAOS
{
    public class Conexion
    {
        static MySqlConnection conexion;

        public static bool conectar()
        {
            try
            {

                if (conexion == null || conexion.State != ConnectionState.Open)
                {
                    conexion = new MySqlConnection();
                    conexion.ConnectionString = "Server=localhost;" +
                    "Database=tiemda;" +
                    "uid=root;" +
                    "pwd=root;";
                    conexion.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public static DataTable ejecutarConsulta(MySqlCommand consulta)
        {
            if (conectar())
            {
                consulta.Connection = conexion;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            return null;
        }

        public static int ejecutarSentencia(MySqlCommand sentencia, bool esInsertar)
        {
            int valor = 0;
            if (conectar())
            {
                sentencia.Connection = conexion;
                if (esInsertar)
                    valor = int.Parse(sentencia.ExecuteScalar().ToString());
                else
                    valor = sentencia.ExecuteNonQuery();
            }
            return valor;
        }

        public static void desconectar()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }
}
