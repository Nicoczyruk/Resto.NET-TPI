using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Resto.NET_TPI
{
    internal class Clases
    {
    }

    public abstract class ElementoRestaurante
    {
        public Point Posicion { get; set; }
        public int Numero { get; set; } // Número de mesa/silla
        public bool Ocupado { get; set; }
        public List<string> Consumo { get; set; }
        public TimeSpan Permanencia { get; set; }
        
    }

    public class Mesa : ElementoRestaurante
    {
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

    //CLASE DE LA GRILLA
    public class MiGrilla : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Logica para dibujar lineas horizontales y verticales
            for (int x = 0; x <= this.Width; x += 20) // Lineas cada 20 píxeles
                g.DrawLine(Pens.LightGray, x, 0, x, this.Height);
            for (int y = 0; y <= this.Height; y += 20)
                g.DrawLine(Pens.LightGray, 0, y, this.Width, y);
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

    public static class ControlExtensions 
    {
        //Clase estática ControlExtensions:

        //Es una clase estática que contiene métodos de extensión para la clase Control y sus derivados.Los métodos de extensión permiten agregar funcionalidad a tipos existentes sin modificar su estructura original.
        //Método de extensión EnableDoubleBuffering:

        //Este método extiende la funcionalidad de cualquier objeto Control, permitiendo que se aplique el doble búfer a dicho control.
        //Uso de reflexión:

        //Utiliza la reflexión (System.Reflection) para acceder a la propiedad protegida DoubleBuffered de la clase Control.
        //GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic): Este método estático GetProperty busca una propiedad llamada "DoubleBuffered" en la instancia específica del control(Instance) y permite acceder a propiedades no públicas(NonPublic).
        //Habilitación del doble búfer:

        //doubleBufferPropertyInfo.SetValue(control, true, null);: Una vez obtenida la propiedad DoubleBuffered, se utiliza SetValue para establecer su valor en true, lo que habilita el doble búfer para ese control específico.
        //Funcionamiento del doble búfer:
        //Doble búfer (Double Buffering): Es una técnica utilizada en interfaces gráficas para reducir el parpadeo (flickering) al renderizar controles, especialmente útil cuando se actualiza frecuentemente el contenido de la interfaz de usuario.
        //Beneficios: Al habilitar el doble búfer, se renderiza primero en un búfer de memoria oculto y luego se muestra en la pantalla, evitando la visibilidad temporal de dibujos parciales.
        
        public static void EnableDoubleBuffering(this Control control)
        {
            System.Reflection.PropertyInfo? doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, true, null);
        }
    }
}


