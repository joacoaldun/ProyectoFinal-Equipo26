using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {

        public string Dni { get; set; }

        public List<Articulo> ListaFavoritos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Domicilio  DomicilioCliente { get; set; }


    }
}
