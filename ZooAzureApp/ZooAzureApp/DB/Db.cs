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
                especie.clasificacion.denominacion = reader["clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.denominacion = reader["animalTipo"].ToString();
                resultado.Add(especie);
            }
            return resultado;

        }
        public static List<Especie> GetEspeciesId(long id)
        {
            List<Especie> resultado = new List<Especie>();
            string procedimiento = "dbo.GetEspeciesId";
            SqlCommand comando = new SqlCommand(procedimiento,conexion);
            comando.CommandType = CommandType.StoredProcedure;
            //Aquí indicamos el parámetro que le vamos a pasar 
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = id

            });
            //Esta línea dice que se lea el comando creado que en este caso es un procedimiento almacenado.
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            //Aquí debajo crearemos la especie 
            {
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.denominacion = reader["clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.denominacion = reader["animalTipo"].ToString();
                //En esta línea es donde añadimos la especie creada.
                resultado.Add(especie);
            }
            //Aquí devolvemos la lista que la hemos llamado resultado.
            return resultado;
        }
        public static int AgregarEspecie(Especie especie)
        {
            string procedimiento = "dbo.AgregarEspecie";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idClasificacion",
                SqlDbType = SqlDbType.Int,
                SqlValue = especie.clasificacion.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idTipoAnimal",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = especie.tipoAnimal.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "nombre",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = especie.nombre
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "nPatas",
                SqlDbType = SqlDbType.SmallInt,
                SqlValue = especie.nPatas
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "esMascota",
                SqlDbType = SqlDbType.Bit,
                SqlValue = especie.esMascota
            });
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int ActualizarEspecie(long id,Especie especie)
        {
            string procedimiento = "dbo.ActualizarEspecie";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                SqlValue = id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idClasificacion",
                SqlDbType = SqlDbType.Int,
                SqlValue = especie.clasificacion.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idTipoAnimal",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = especie.tipoAnimal.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "nombre",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = especie.nombre
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "nPatas",
                SqlDbType = SqlDbType.SmallInt,
                SqlValue = especie.nPatas
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "esMascota",
                SqlDbType = SqlDbType.Bit,
                SqlValue = especie.esMascota
            });
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int EliminarEspecie(int id)
        {
            string procedimiento = "dbo.EliminarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "id";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery(); //Esta linea ejecuta el procedimiento

            return filasAfectadas;
        }
    }
}