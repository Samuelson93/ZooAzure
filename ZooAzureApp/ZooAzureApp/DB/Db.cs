using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ZooAzureApp
{
    public static class Db
    {
        private static SqlConnection conexion = null;
        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                //string cadenaConexion = @"Server=samuelcurso.database.windows.net;
                //                          Database=SamuelPrueba;
                //                          User Id=samuel;
                //                          Password=!Curso@2017;";

                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

                //// PREGUNTO POR EL ESTADO DE LA CONEXIÓN
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("Conexión abierta con éxito");
                //    // CIERRO LA CONEXIÓN
                //    conexion.Close();
                //}
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                // DESTRUYO LA CONEXIÓN
                //if (conexion != null)
                //{
                //    if (conexion.State != ConnectionState.Closed)
                //    {
                //        conexion.Close();
                //        Console.WriteLine("Conexión cerrada con éxito");
                //    }
                //    conexion.Dispose();
                //    conexion = null;
                //}
            }
        }
        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }
        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }
        public static List<Especie> GetEspecies() {
            List<Especie> resultado = new List<Especie>();
            //Preparamos la linea de ejecución del proyecto 
            string procedimiento = "dbo.GetEspecies";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while(reader.Read())
                //Creamos la especie
            {
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.denominacion = reader["denominacionClasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.denominacion = reader["denominacionTiposAnimal"].ToString();
                resultado.Add(especie);
            }
            return resultado;

        }
    }
}