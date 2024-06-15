using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.NET_TPI
{
    internal class Clases
    {
    }

    public abstract class ElementoRestaurante
    {
        public string Tamaño { get; set; }
        public Point Posicion { get; set; }

        public ElementoRestaurante()
        {
        }

    }

    public class Mesa : ElementoRestaurante
    {
        
        public Mesa()
        {
        }
    }

    public class Silla : ElementoRestaurante
    {
        
        public Silla()
        {
        }
    }

    public class Divisor : ElementoRestaurante
    {
        
        public Divisor()
        {
        }
    }

    public class Pared : ElementoRestaurante
    {
        public Pared()
        {
            
        }
    }

    public class Puerta : ElementoRestaurante
    {
        public Puerta()
        {
            
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public TimeSpan Permanencia { get; set; }
        public List<Consumo> Consumos { get; set; }

        public Cliente()
        {
            Consumos = new List<Consumo>();
        }
    }

    public class Consumo
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }
    }

   
}
