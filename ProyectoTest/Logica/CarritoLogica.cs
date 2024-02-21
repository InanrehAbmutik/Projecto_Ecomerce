using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace ProyectoTest.Logica
{
    public class CarritoLogica
    {
        private static CarritoLogica _instancia = null;

        public CarritoLogica()
        {

        }

        public static CarritoLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CarritoLogica();
                }

                return _instancia;
            }
        }

        public int Registrar(Carrito oCarrito)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarCarrito", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oCarrito.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProduto", oCarrito.oProducto.IdProducto);
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


        public int Cantidad(int idusuario)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from carrito where idusuario = @idusuario", oConexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public List<Carrito> Obtener(int _idusuario)
        {
            List<Carrito> lst = new List<Carrito>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerCarrito", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", _idusuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Carrito() {

                                IdCarrito = Convert.ToInt32(dr["IdCarrito"].ToString()),
                                oProducto = new Producto() {
                                    IdProducto = Convert.ToInt32(dr["IdProduto"].ToString()),
                                    Nombre = dr["Nome"].ToString(),
                                    oMarca = new Marca() { Descripcion = dr["Descricao"].ToString() },
                                    Precio = Convert.ToDecimal(dr["Preco"].ToString(), new CultureInfo("pt-PT")),
                                    RutaImagen = dr["RotaImagem"].ToString()
                                },
                                
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<Carrito>();
                }
            }
            return lst;
        }

        public bool Eliminar(string IdCarrito, string IdProducto) {

            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("delete from carrito where idcarrito = @idcarrito");
                    query.AppendLine("update Produto set Stock = Stock + 1 where IdProduto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idcarrito", IdCarrito);
                    cmd.Parameters.AddWithValue("@idproducto", IdProducto);
                    cmd.CommandType = CommandType.Text;

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

        public List<Compra> ObtenerCompra(int IdUsuario)
        {
            List<Compra> rptDetalleCompra = new List<Compra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCompra", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DATA") != null)
                            {
                                rptDetalleCompra = (from c in doc.Element("DATA").Elements("COMPRA")
                                                    select new Compra()
                                                    {
                                                        Total = Convert.ToDecimal(c.Element("Total").Value,new CultureInfo("pt-PT")),
                                                        FechaTexto = c.Element("DATA").Value,
                                                        oDetalleCompra = (from d in c.Element("DETALHE_Produto").Elements("PRODUCTO")
                                                                          select new DetalleCompra() {
                                                                              oProducto = new Producto() {
                                                                                  oMarca = new Marca() { Descripcion = d.Element("Descricao").Value  },
                                                                                  Nombre = d.Element("Nome").Value,
                                                                                  RutaImagen = d.Element("RotaImagem").Value
                                                                              },
                                                                              Total = Convert.ToDecimal(d.Element("Total").Value,new CultureInfo("pt-PT")),
                                                                              Cantidad = Convert.ToInt32(d.Element("Qtdade").Value)
                                                                          }).ToList()
                                                    }).ToList();
                            }
                            else
                            {
                                rptDetalleCompra = new List<Compra>();
                            }
                        }

                        dr.Close();

                    }

                    return rptDetalleCompra;
                }
                catch (Exception ex)
                {
                    rptDetalleCompra = null;
                    return rptDetalleCompra;
                }
            }
        }



    }
}