﻿using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTest.Logica
{
    public class MarcaLogica
    {
        private static MarcaLogica _instancia = null;

        public MarcaLogica()
        {

        }

        public static MarcaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new MarcaLogica();
                }

                return _instancia;
            }
        }

        public List<Marca> Listar()
        {

            List<Marca> rptListaMarca = new List<Marca>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerLoja", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMarca.Add(new Marca()
                        {
                            IdMarca = Convert.ToInt32(dr["IdLoja"].ToString()),
                            Descripcion = dr["Descricao"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMarca;

                }
                catch (Exception ex)
                {
                    rptListaMarca = null;
                    return rptListaMarca;
                }
            }
        }


        public bool Registrar(Marca oMarca)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarLoja", oConexion);
                    cmd.Parameters.AddWithValue("Descricao", oMarca.Descripcion);
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

        public bool Modificar(Marca oMarca)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarLoja", oConexion);
                    cmd.Parameters.AddWithValue("IdLoja", oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("Descricao", oMarca.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oMarca.Activo);
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

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN1))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Loja where idLoja = @id", oConexion);
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