using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public enum EstadoEnvio
    {
        RECIBIDO = 1,
            
       PREPARACION = 2,

       ENTREGADO = 3
    }


    public class Pedido
    {
        public int Id { get; set; }

        public Carrito CarritoPedidos { get; set; }

        public Cliente Cliente { get; set; }

        public MedioPago MedioDePago { get; set; }

        public DateTime FechaPedido { get; set; }

        public EstadoEnvio EstadoEnvio { get; set; }

        public bool EstadoPago { get; set; }

    }
}
