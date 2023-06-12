using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }

        public  int  Numero { get; set; }

        public string Vivienda { get; set; }

        public string NumeroDepartamento { get; set; }
        public string Localidad { get; set; }

        public  string Provincia { get; set; }
    }
}
