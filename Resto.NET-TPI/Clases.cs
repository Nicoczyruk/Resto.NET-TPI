using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Resto.NET_TPI
{
    internal class Clases
    {
    }


    [XmlInclude(typeof(Mesa))]
    [XmlInclude(typeof(Silla))]
    [XmlInclude(typeof(Divisor))]
    [XmlRoot("ElementoRestaurante")]
    public abstract class ElementoRestaurante
    {
        public Point Posicion { get; set; }
        public int Numero { get; set; } // Número de mesa/silla
        [TypeConverter(typeof(SiNoConverter))]
        public bool Ocupado { get; set; }
        [TypeConverter(typeof(SiNoConverter))]
        public bool Reservado { get; set; }
        public List<Consumo> Consumos { get; set; }
        [Browsable(false)]
        public Stopwatch RelojPermanencia { get; set; }
        [Browsable(false)]
        public TimeSpan Permanencia { get; set; }
        public int Mozo { get; set; }
        public bool esFija;
        [Browsable(false)]
        public String nameImg { get; set; }


        public void Fix()
        {
            esFija = true;
        }

        public void UnFix()
        {
            esFija = false;
        }

        public ElementoRestaurante()
        {
            Consumos = new List<Consumo>();
            RelojPermanencia = new Stopwatch();
        }
    }
    [Serializable]
    [XmlRoot("Mesa")]
    public class Mesa : ElementoRestaurante
    {
        private List<Cliente> clientes = new List<Cliente>();

        public int CantSillas { get; set; } //va por defecto dependiendo del tipo de mesa

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set
            {
                // Verificar si la cantidad de clientes excede la cantidad de sillas
                if (value.Count > CantSillas)
                {
                    // Tomar solo la cantidad de clientes que cabe en la mesa
                    clientes = value.Take(CantSillas).ToList();
                }
                else
                {
                    // Si no excede, asignar la lista completa
                    clientes = value;
                }

                ActualizarConsumos();
            }
        }
        // Ocultar la propiedad Ocupado de la clase base
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
                        // Si se establece a true, agregar aleatoriamente clientes
                        AgregarClientesAleatorios();
                    }
                    else
                    {
                        // Si se establece a false, borrar la lista de clientes
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
            // Asegurarse de que no haya más clientes que sillas
            if (clientes.Count > CantSillas)
            {
                clientes = clientes.Take(CantSillas).ToList(); // Tomar solo los primeros 'CantSillas' clientes
            }

            // Actualizar los consumos según los clientes actuales
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
                // Actualizar Consumos si hay cliente asignado
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

    [XmlRoot("Divisor")]
    public class Divisor : ElementoRestaurante
    {

        public Divisor()
        {
            esFija = false;
        }
    }

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
            this.Permanencia = new TimeSpan();//Arranca desde cero
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

    public class SiNoConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "Si" : "No";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                return strValue.ToLower() == "si";
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "Si", "No" });
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
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


