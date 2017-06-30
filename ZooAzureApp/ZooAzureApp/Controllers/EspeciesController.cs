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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Especies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especies/5
        public void Delete(int id)
        {
        }
    }
}
