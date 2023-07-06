using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {

        public string Dni { get; set; }

        public List<Articulo> ListaFavoritos { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public Domicilio  DomicilioCliente { get; set; }

        public bool Validado { get; set; }

        public string CodigoValidacion { get; set; }

        public string CodigoRecuperacion { get; set; }


    }
}
