using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooAzureApp
{
    public class Especie
    {
        public long idEspecie { get; set; }
        public string nombre { get; set; }
        public short nPatas { get; set; }
        public bool esMascota { get; set; }
        public Clasificacion clasificacion { get; set; }
        public  TipoAnimal tipoAnimal { get; set; }

    }


}