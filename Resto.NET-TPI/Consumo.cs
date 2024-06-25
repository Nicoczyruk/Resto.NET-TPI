using System.Xml.Serialization;

namespace Resto.NET_TPI
{
    [XmlRoot("Consumo")]
    public class Consumo
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"{Producto} Precio: ${Precio:F2}";
        }
    }
}
