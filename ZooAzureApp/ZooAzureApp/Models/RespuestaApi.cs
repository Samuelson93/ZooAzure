using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooAzureApp
{
    public class RespuestaAPI

    {
        public int totalElementos { get; set; }
        public string error { get; set; }
        public  List<Especie> data { get; set; }
        public List<Clasificacion> dataClasificaciones { get; set; }
        public List<TipoAnimal> dataTiposAnimal  { get; set; }
    }
}