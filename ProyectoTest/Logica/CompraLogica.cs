using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoTest.Logica
{
    public class CompraLogica
    {
        private static CompraLogica _instancia = null;

        public CompraLogica()
        {

        }

        public static CompraLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CompraLogica();
                }

                return _instancia;
            }
        }
        public List<Encomendas> Listar()
        {

            List<Encomendas> rptListaEncomendas = new List<Encomendas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                SqlCommand cmd = new SqlCommand(@" Select idcompra, u.Nomes, Telefone,TotalProduto, direcao, total, CONVERT(VARCHAR(16), datacompra, 120) as datacompra from COMPRA 
                                                    inner join USUARIO u on u.IdUsuario= COMPRA.IdUsuario", oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaEncomendas.Add(new Encomendas()
                        {
                            IdCompra = Convert.ToInt32(dr["IdCompra"].ToString()),
                            Nomes = dr["Nomes"].ToString(),
                            Total = dr["Total"].ToString(),
                            TotalProduto = dr["TotalProduto"].ToString(),
                            Direcao = dr["Total"].ToString(),
                            Telefone = dr["Telefone"].ToString(),
                            DataCompra = dr["DataCompra"].ToString(),
                        });
                    }
                    dr.Close();

                    return rptListaEncomendas;

                }
                catch (Exception ex)
                {
                    rptListaEncomendas = null;
                    return rptListaEncomendas;
                }
            }
        }

        public bool Registrar(Compra oCompra)
        {

            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    foreach (DetalleCompra dc in oCompra.oDetalleCompra) {
                        query.AppendLine("insert into DETALHE_COMPRA(IdCompra,IdProduto,Qtdade,Total) values (¡idcompra!," + dc.IdProducto +","+dc.Cantidad+","+dc.Total+")");
                    }

                    SqlCommand cmd = new SqlCommand("sp_registrarCompra", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oCompra.IdUsuario);
                    cmd.Parameters.AddWithValue("TotalProduto", oCompra.TotalProducto);
                    cmd.Parameters.AddWithValue("Total", oCompra.Total);
                    cmd.Parameters.AddWithValue("Contacto", oCompra.Contacto);
                    cmd.Parameters.AddWithValue("Telefone", oCompra.Telefono);
                    cmd.Parameters.AddWithValue("Direcao", oCompra.Direccion);
                    cmd.Parameters.AddWithValue("IdDistrito", oCompra.IdDistrito);
                    cmd.Parameters.AddWithValue("QueryDETALHECompra", query.ToString());
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
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



    }
}