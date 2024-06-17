using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Resto.NET_TPI
{
    internal class Clases
    {
    }

    public abstract class ElementoRestaurante
    {

        public Point Posicion { get; set; }//Investigar sobre Point
        public ElementoRestaurante()
        {
        }
    }

    public class Mesa : ElementoRestaurante
    {
        public int nro { get; set; }
        public int cantSillas { get; set; }//va por defecto dependiendo del tipo de mesa
        public char estado { get; set; } //{L,O,R} si se encuentra ocupada, reservado o libre
        public Boolean MesaCuadrada { get; set; }
        public Boolean MesaSimple { get; set; }//true
        public List<Silla> sillas { get; set; }


        public Mesa()
        {
            sillas = new List<Silla>();
            this.estado = 'L';
            this.MesaCuadrada = true;
            this.MesaSimple = true;
        }

        public void tipoMesa(Boolean cuadrada, Boolean simple)
        {
            this.MesaCuadrada = cuadrada;
            this.MesaSimple = simple;
            CargarSillas();
        }
        //cantidad de sillas por defecto dependiendo del tipo de mesa
        private void CargarSillas()
        {
            if (MesaCuadrada)
            {
                cantSillas = 4;
            }
            else
            {
                cantSillas = 6;
            }

            for (int i = 0; i < cantSillas; i++)//agrega a la lista la cantidad de sillas por defecto 
            {
                sillas.Add(new Silla());
            }
        }

        //Agregar silla
        public void agregarSilla()
        {
            if (MesaSimple && cantSillas < 6 || !MesaSimple && cantSillas < 8)
            {
                sillas.Add(new Silla());
                cantSillas++;
            }
            else
            {
                //Mensaje ya no sillas. Con un MessageShow
            }
        }
        public void quitarSilla(Silla silla)
        {

            if (!silla.estado && cantSillas > 1)
            {
                cantSillas--;
            }
            else
            {
                //Mensaje ya no sillas.
            }
        }

        public void OcuparSilla(Cliente cliente)
        {
            var sillaLibre = sillas.Find(s => !s.estado); //busca las sillas que estan desocupadas y la asigna al cliente
            if (sillaLibre != null)
            {
                sillaLibre.estado = true;// true(ocupado), false(libre)
                sillaLibre.ClienteActual = cliente; //se le asigna el cliente a la silla
            }
            else
            {
                Console.WriteLine("No hay sillas disponibles.");
            }
        }

        public void DesocuparSilla(Silla silla)
        {
            if (this.estado == 'L')
            {
                foreach (Silla s in sillas)
                {//para restablecer el estado de las sillas y los clientes
                    s.estado = false;
                    s.ClienteActual = null;
                }
            }
        }

    }


    public class Silla : ElementoRestaurante
    {
        public bool estado { get; set; } //true ocupada, false libre  
        public bool barra { get; set; } //si es de  barra o no

        public Cliente ClienteActual { get; set; }



        public Silla()
        {
            this.estado = false;
            this.ClienteActual = null;
            this.barra = false;
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

    public class Ambientes : ElementoRestaurante//baño, cocina,etc
    {
        public string tipo;

        public Ambientes(string tipo)

        {
            this.tipo = tipo;

        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public TimeSpan Permanencia { get; set; }
        public List<Consumo> Consumos { get; set; }
        public Mesa Mesa;//le asignamos un nro de mesa


        public Cliente()
        {
            this.Permanencia = new TimeSpan();//Arranca desde cero
            Consumos = new List<Consumo>();
        }

    }

    public class Consumo
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }
    }


    public class Mozo
    {
        public int MesasACargo { get; set; }
        public List<Mesa> mesas { get; set; }
        public string Nombre { get; set; }


        public Mozo()
        {
            mesas = new List<Mesa>();
            MesasACargo = 0;
        }
        public void asignarMesa(Mesa mesa)
        {
            mesas.Add(mesa);
            MesasACargo++;
        }


    }
}


