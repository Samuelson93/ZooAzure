using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooAzureApp.Controllers
{
    public class EspeciesController : ApiController
    {
        // GET: api/Especies
      
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especie> especies = new List<Especie>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    especies = Db.GetEspecies();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch(Exception ex)
            {
                resultado.error = "Se produjo un error"+ex.ToString();
            }
            resultado.totalElementos = especies.Count;
            resultado.data = especies;
            return resultado;
        }
    

        // GET: api/Especies/5
        public RespuestaAPI Get(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especie> especies = new List<Especie>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    especies = Db.GetEspeciesId(id);
                }
                resultado.error = "";
                Db.Desconectar();

            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error" +ex.ToString();
            }
            resultado.totalElementos = especies.Count;
            resultado.data = especies;
            return resultado;
        }

        // POST: api/Especies
        [HttpPost]
        public RespuestaAPI Post([FromBody]Especie especie)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarEspecie(especie);
                }
                resultado.error = "";
                Db.Desconectar();

            }
            catch (Exception ex)
            {

                resultado.error = "Se produjo un error " + ex.ToString();
            }

            resultado.totalElementos = filasAfectadas;
            resultado.data = null;
            return resultado;
        }

        // PUT: api/Especies/5
        [HttpPut]
        public RespuestaAPI Put(int id, [FromBody]Especie especie)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarEspecie(id,especie);
                }
                resultado.error = "";
                Db.Desconectar();

            }
            catch (Exception ex)
            {

                resultado.error = "Se produjo un error " + ex.ToString();
            }

            resultado.totalElementos = filasAfectadas;
            resultado.data = null;
            return resultado;
        }

        // DELETE: api/Especies/5
        [HttpDelete]
        public RespuestaAPI Delete(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            resultado.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarEspecie(id);
                }
                resultado.totalElementos = filasAfectadas;

                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.totalElementos = 0;
                resultado.error = "error al borrar especie";
                resultado.data = null;

            }

            return resultado;
        }
    
    }
}
