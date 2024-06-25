using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Resto.NET_TPI
{
    [Serializable]
    [XmlRoot("Mesa")]
    public class Mesa : ElementoRestaurante
    {
        private List<Cliente> clientes = new List<Cliente>();

        public int CantSillas { get; set; }

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set
            {
                if (value.Count > CantSillas)
                {
                    clientes = value.Take(CantSillas).ToList();
                }
                else
                {
                    clientes = value;
                }

                ActualizarConsumos();
            }
        }

        public new bool Ocupado
        {
            get { return base.Ocupado; }
            set
            {
                if (base.Ocupado != value)
                {
                    base.Ocupado = value;
                    if (base.Ocupado)
                    {
                        AgregarClientesAleatorios();
                    }
                    else
                    {
                        clientes.Clear();
                        Consumos.Clear();
                    }
                }
            }
        }

        public Mesa()
        {
            esFija = false;
        }

        public void ActualizarConsumos()
        {
            if (clientes.Count > CantSillas)
            {
                clientes = clientes.Take(CantSillas).ToList();
            }

            Consumos.Clear();
            foreach (Cliente cliente in Clientes)
            {
                Consumos.AddRange(cliente.Consumos);
            }
        }

        private void AgregarClientesAleatorios()
        {
            clientes.Clear();
            for (int i = 0; i < CantSillas; i++)
            {
                clientes.Add(new Cliente());
            }

            ActualizarConsumos();
        }
    }
}
