using Resto.NET_TPI.Properties;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Resto.NET_TPI
{
    public partial class Form1 : Form
    {
        //int cantidadImagen = 0;// cuantas imagenes se están generando **(VER si dejamos para la lógica en modo previsualización)
        private PictureBox arrastreImagen = null;//controla el arrastre de la imagen. Cuando suelte el usuario se maracará null
        private Point coordenadasImagen;//Se almacena las coordenadas de la imagen
        List<PictureBox> paneles = new List<PictureBox>();//lista para borrar.


        public Form1()
        {
            InitializeComponent();
            VisibilidadInicial();//Si no, mostrará todos los paneles del menú.
            miGrilla.Visible = false;//Por defecto se va a iniciar apagada. 
            miGrilla.BackgroundImageLayout = ImageLayout.Stretch;//Ajustar imagen al tamaño
            panelDiseño.BackgroundImageLayout = ImageLayout.Stretch;

        }
        private void VisibilidadInicial()
        {
            panelMesa.Visible = false;
            panelDivisor.Visible = false;
            panelMesa2.Visible = false;
            panelMesa4.Visible = false;
            panelMesa6.Visible = false;
            panelMesa8.Visible = false;

        }


        //Método que hace visible los paneles que contienen los botones.
        private void MostrarPanel(Panel subPanel)
        {
            if (subPanel.Visible == false)
            {
                //si hay alguno abierto lo oculta 
                subPanel.Visible = true;
            }
            else
            {
                subPanel.Visible = false;
            }

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cargarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void modoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            miGrilla.Visible = false;

        }

        private void modoEdiciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            miGrilla.Visible = true;

        }

        //En cada botón de los paneles de la barra de Herram llamamos al método para que sea visible
        private void btnMesa_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa);
        }

        private void btnMesa2_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa2);
        }

        private void btnMesa4_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa4);
        }

        private void btnMesa6_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa6);
        }

        private void btnMesa8_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa8);
        }

        private void btnDivisor_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelDivisor);
        }

        //Método para cargar la imagen y sus propiedades a los pictureBox y para asociar las imagenes a los botones
        private void CargarImagen(Image nombre)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = nombre;
            pictureBox.Size = new Size(100, 100);
            // pictureBox.Location = new Point(cantidadImagen * 110, 10);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;//Establece SizeMode a StretchImage para ajustar la imagen 
            miGrilla.Controls.Add(pictureBox); //Agregar cada PictureBox creado al control del contenedor mi grilla

            //Agregar los manejadores de eventos de arrastre
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            //cantidadImagen++; (VER SI ES NECESARIO para el modo PreVisualización)
            paneles.Add(pictureBox);//se agrega a la lista por si se necesita eliminar
        }

        //Métodos y eventos para arrastrar la imagen
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el PictureBox, se establece el PictureBox que se está arrastrando y se registra la posición de inicio del mouse
            arrastreImagen = sender as PictureBox;
            coordenadasImagen = e.Location;
        }
        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            // Cuando se suelta el botón del mouse, se restablece el PictureBox que se está arrastrando
            arrastreImagen = null;
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            //Se verifica si se está arrastrando un PictureBox y si se está manteniendo presionado el botón izquierdo del mouse
            if (arrastreImagen != null && e.Button == MouseButtons.Left)
            {
                //Se convierte la posición del ratón en coordenadas relativas a la grilla
                Point newLocation = miGrilla.PointToClient(MousePosition);
                //Se calcula la nueva posición del PictureBox arrastrado
                int x = newLocation.X - coordenadasImagen.X;
                int y = newLocation.Y - coordenadasImagen.Y;

                // Se verifica si el PictureBox está dentro de los límites de la grilla
                // Si la posición X es menor que 0, se ajusta para que esté en el borde izquierdo de la grilla
                if (x < 0)
                    x = 0;
                // Si la posición x + el ancho del PictureBox es mayor que el ancho de la grilla, se ajusta para que esté en el borde derecho
                else if (x + arrastreImagen.Width > miGrilla.Width)
                    x = miGrilla.Width - arrastreImagen.Width;

                // Se verifica si la posición Y es menor que 0, se ajusta para que esté en el borde superior de la grilla
                if (y < 0)
                    y = 0;
                // Si la posición Y + la altura del PictureBox es mayor que la altura de la grilla, se ajusta para que esté en el borde inferior de la misma
                else if (y + arrastreImagen.Height > miGrilla.Height)
                    y = miGrilla.Height - arrastreImagen.Height;

                // Se establece la nueva posición del PictureBox arrastrado
                arrastreImagen.Location = new Point(x, y);
            }
        }

        //Carga las imágenes a los botones llamando al método y utilizando el evento
        private void bntCircular2_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaDosCircu);
        }
        private void btnRec2_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaDosRectang);
        }
        private void bntCir4_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaCuatroCircu);
        }
        private void btnRec4_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaCuatroRectang);
        }
        private void btnCir6_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaSeisCircu);
        }
        private void btnRec6_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaSeisRectang);
        }

        private void btnCir8_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaOchoCircu);
        }
        private void btnRec8_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaOchoRectang);
        }
        private void bntHorizontal_Click_1(object sender, EventArgs e)
        {
            CargarImagen(Resources.divisorHorizontal);
        }
        private void btnVertical_Click_1(object sender, EventArgs e)
        {
            CargarImagen(Resources.divisorVertical);
        }
        private void btnSilla_Click_1(object sender, EventArgs e)
        {
            CargarImagen(Resources.Banqueta);
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (paneles.Count > 0)//Verifica si hay elementos en la lista
            {
                PictureBox ultimoPanel = paneles[paneles.Count - 1]; //recupera el último elemento (el PictureBox agregado más recientemente) de la lista.
                miGrilla.Controls.Remove(ultimoPanel);//elimina el último PictureBox de la colección Controls de la grilla.
                paneles.RemoveAt(paneles.Count - 1);//elimina el último elemento (el mismo PictureBox que se acaba de eliminar de la grilla) de la lista.
            }
        }

        
    }
}
