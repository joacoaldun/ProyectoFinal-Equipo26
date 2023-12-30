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

       ENCAMINO=3,

       ENTREGADO = 4,

       CANCELADO=5
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

        public decimal ImporteTotal { get; set; }

        public Domicilio DomicilioPedido { get; set; }

        public int CodigoPago { get; set; }
        public int CodigoEnvio { get; set; }

        public MedioEnvio MedioDeEnvio { get; set; }

    }
}
