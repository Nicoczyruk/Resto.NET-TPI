using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Globalization;

namespace Resto.NET_TPI
{
    [XmlInclude(typeof(Mesa))]
    [XmlInclude(typeof(Silla))]
    [XmlInclude(typeof(Divisor))]
    [XmlRoot("ElementoRestaurante")]
    public abstract class ElementoRestaurante
    {
        [ReadOnly(true)]
        public Point Posicion { get; set; }
        public int Numero { get; set; }
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
}
