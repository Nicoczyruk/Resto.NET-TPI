using System.Xml.Serialization;

namespace Resto.NET_TPI
{
    [XmlRoot("Silla")]
    public class Silla : ElementoRestaurante
    {
        public Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                Ocupado = cliente != null;
                if (cliente != null)
                {
                    Consumos.Clear();
                    Consumos.AddRange(cliente.Consumos);
                }
                else
                {
                    Consumos.Clear();
                }
            }
        }

        public Silla()
        {
            esFija = false;
            this.Ocupado = false;
        }

        public void GenerarClienteAleatorio()
        {
            this.Cliente = new Cliente();
        }
    }
}
