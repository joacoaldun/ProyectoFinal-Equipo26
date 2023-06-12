using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public enum TipoAcceso
    {
        ADMIN = 1,
        CLIENTE =2
    }
    public abstract class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public string  Apellido{ get; set; }

        public string UsarName { get; set; }

        public  string Email { get; set; }

        public string  Pass { get; set; }

        public TipoAcceso TipoAcceso { get; set; }

        public bool EstadoActivo { get; set; }
    }
}
