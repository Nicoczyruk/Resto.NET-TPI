using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resto.NET_TPI
{
    [XmlRoot("Cliente")]
    public class Cliente
    {
        private static int contadoCliente = 1;

        public string Nombre { get; set; }
        public TimeSpan Permanencia { get; set; }
        public List<Consumo> Consumos { get; set; }

        public Cliente()
        {
            Nombre = $"Cliente{contadoCliente++}";
            this.Permanencia = new TimeSpan();
            Consumos = GenerarConsumosAleatorios();
        }

        private List<Consumo> GenerarConsumosAleatorios()
        {
            var consumos = new List<Consumo>();
            var random = new Random();
            int numConsumos = random.Next(1, 5);

            for (int i = 0; i < numConsumos; i++)
            {
                consumos.Add(new Consumo
                {
                    Producto = $"Producto{random.Next(1, 10)}",
                    Precio = Math.Round((decimal)(random.NextDouble() * 100), 2)
                });
            }

            return consumos;
        }
    }
}
