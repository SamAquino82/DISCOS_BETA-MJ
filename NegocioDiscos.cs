using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace proyecto_beta_discos
{
    internal class NegocioDiscos
    {
        public List<Discos> listar()
        {
            List<Discos>listadiscos = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType=System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Tipo, t.Descripcion Formato from DISCOS, ESTILOS E, TIPOSEDICION T where IdEstilo=e.Id and IdTipoEdicion=t.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector= comando.ExecuteReader();
                while(lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Nombre = (string)lector["Titulo"];
                    aux.lanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.ventas = (int)lector["CantidadCanciones"];
                    aux.imagen = (string)lector["UrlImagenTapa"];
                    //Estilo tipo = new Estilo();
                    aux.Tipo = (string)lector["Tipo"];
                    aux.Formato = (string)lector["Formato"];

                    listadiscos.Add(aux);


                }
                conexion.Close();
                return listadiscos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
