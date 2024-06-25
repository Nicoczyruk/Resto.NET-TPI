using System.Xml.Serialization;

namespace Resto.NET_TPI
{
    [XmlRoot("Divisor")]
    public class Divisor : ElementoRestaurante
    {
        public Divisor()
        {
            esFija = false;
        }
    }
}
