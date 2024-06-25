using System.Windows.Forms;

namespace Resto.NET_TPI
{
    public static class ControlExtensions
    {
        public static void EnableDoubleBuffering(this Control control)
        {
            System.Reflection.PropertyInfo? doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, true, null);
        }
    }
}
