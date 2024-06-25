using System;
using System.Drawing;
using System.Windows.Forms;

namespace Resto.NET_TPI
{
    public class MiGrilla : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            for (int x = 0; x <= this.Width; x += 20)
                g.DrawLine(Pens.LightGray, x, 0, x, this.Height);
            for (int y = 0; y <= this.Height; y += 20)
                g.DrawLine(Pens.LightGray, 0, y, this.Width, y);
        }
    }
}
