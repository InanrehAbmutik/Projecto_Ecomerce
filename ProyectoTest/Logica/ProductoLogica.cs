using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProyectoTest.Logica
{
    public class ProductoLogica
    {
        private static ProductoLogica _instancia = null;

        public ProductoLogica()
        {

        }

        public static ProductoLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ProductoLogica();
                }

                return _instancia;
            }
        }

        public List<Producto> Listar()
        {

            List<Producto> rptListaProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                SqlCommand cmd = new SqlCommand("sp_obterProduto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProducto.Add(new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProduto"].ToString()),
                            Nombre = dr["Nome"].ToString(),
                            Descripcion = dr["Descricao"].ToString(),
                            oMarca = new Marca() { IdMarca = Convert.ToInt32(dr["IdLoja"].ToString()),Descripcion = dr["DescricaoLoja"].ToString() },
                            oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()), Descripcion = dr["DescricaoCategoria"].ToString() },
                            Precio = Convert.ToDecimal(dr["Preco"].ToString(), new CultureInfo("pt-PT")),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            RutaImagen = dr["RotaImagem"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProducto;

                }
                catch (Exception ex)
                {
                    rptListaProducto = null;
                    return rptListaProducto;
                }
            }
        }



        public int Registrar(Producto oProducto)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrarProduto", oConexion);
                    cmd.Parameters.AddWithValue("Nome", oProducto.Nombre );
                    cmd.Parameters.AddWithValue("Descricao", oProducto.Descripcion );
                    cmd.Parameters.AddWithValue("IdMarca", oProducto.oMarca.IdMarca );
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Preco", oProducto.Precio );
                    cmd.Parameters.AddWithValue("Stock", oProducto.Stock=1 );
                    cmd.Parameters.AddWithValue("RotaImagem", oProducto.RutaImagen );
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public bool Modificar(Producto oProducto)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_editarProduto", oConexion);
                    cmd.Parameters.AddWithValue("IdProduto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("Nome", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("Descricao", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("IdMarca", oProducto.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Preco", oProducto.Precio);
                    cmd.Parameters.AddWithValue("Stock", oProducto.Stock);
                    cmd.Parameters.AddWithValue("Activo", oProducto.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        

        public bool ActualizarRutaImagen(Producto oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizarRotaImagem", oConexion);
                    cmd.Parameters.AddWithValue("IdProduto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("RotaImagem", oProducto.RutaImagen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Producto where idProducto = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

    }
}