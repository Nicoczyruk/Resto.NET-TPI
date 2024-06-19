using PANELHERRAMIENTAS.Properties;
using System.Windows.Forms;

namespace PANELHERRAMIENTAS
{
    public partial class Form1 : Form
    {
        int cantidadImagen = 0;// cuantas imagenes se est�n generando **VER si dejamos.
        private PictureBox arrastreImagen = null;//controla el arrastre de la imagen. Cuando suete el usuario se maracar� null
        private Point coordenadasImagen;//Se almacena las coordenadas de la imagen
        List<PictureBox> paneles = new List<PictureBox>();
       
        public Form1()
        {
            InitializeComponent();
            VisibilidadInicial();//si no, mostrar� todos los paneles del men� antes del evento Click.
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

        //M�todo para que se despliegue el men� 
        private void OcultarPanel()
        {
            if (panelMesa.Visible == true)
            {
                panelMesa.Visible = false;
                if (panelMesa2.Visible == true)
                {
                    panelMesa2.Visible = false;
                }
                else
                {
                    if (panelMesa4.Visible == true)
                    {
                        panelMesa4.Visible = false;
                    }
                    else
                    {
                        if (panelMesa6.Visible == true)
                        {
                            panelMesa6.Visible = false;
                        }
                        else
                        {
                            panelMesa8.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if (panelDivisor.Visible == true)
                {
                    panelDivisor.Visible = false;
                }
            }
        }

        //M�todo que hace visible los paneles que contienen los botones.
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

        private void bntMesa8_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelMesa8);
        }

        private void btnDivisor_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelDivisor);
        }

        //M�todo para cargar la imagen y sus propiedades a los pictutebox y para asociar las imagenes a los botones
        private void CargarImagen(Image nombre)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = nombre;

            pictureBox.Size = new Size(100, 100);
            pictureBox.Location = new Point(cantidadImagen * 110, 10);
           

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;// Establece SizeMode a StretchImage para ajustar la imagen 

            // Agregar los manejadores de eventos de arrastre
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            // Agregar el PictureBox al contenedor
            groupBox1.Controls.Add(pictureBox);

            // Incrementar la cantidad de PictureBox **VER SI ES NECESARIO
            cantidadImagen++;
            paneles.Add(pictureBox);
        }

        
        private void btnCircular2_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaDosCir);
        }
        private void btn4Circular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaCuatroCir);
        }
        private void btn6Circular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaSeisCir);
        }
        private void btn8Circular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaOchoCir);
        }
        private void bntHorizontal_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.divisorHorizontal);
        }

        private void btn2Rectangular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaDosRec);
        }

        private void btn4Rectangular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaCuatroRec);
        }

        private void btn6Rectangular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaSeisRec);
        }

        private void btn8Rectangular_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.mesaParaOchoRec);
        }

        private void btnVertical_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.divisorVertical);
        }

        private void btnSilla_Click(object sender, EventArgs e)
        {
            CargarImagen(Resources.Banqueta);
        }

       

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el PictureBox, se establece el PictureBox que se est� arrastrando y se registra la posici�n de inicio del rat�n
            arrastreImagen = sender as PictureBox;
            coordenadasImagen = e.Location;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Se verifica si se est� arrastrando un PictureBox y si se est� manteniendo presionado el bot�n izquierdo del rat�n
            if (arrastreImagen != null && e.Button == MouseButtons.Left)
            {
                // Se convierte la posici�n del rat�n en coordenadas relativas al groupBox1
                Point newLocation = groupBox1.PointToClient(MousePosition);
                // Se calcula la nueva posici�n del PictureBox arrastrado
                int x = newLocation.X - coordenadasImagen.X;
                int y = newLocation.Y - coordenadasImagen.Y;

                // Se verifica si el PictureBox est� dentro de los l�mites del groupBox1
                // Si la posici�n x es menor que 0, se ajusta para que est� en el borde izquierdo del groupBox1
                if (x < 0)
                    x = 0;
                // Si la posici�n x + el ancho del PictureBox es mayor que el ancho del groupBox1, se ajusta para que est� en el borde derecho del groupBox1
                else if (x + arrastreImagen.Width > groupBox1.Width)
                    x = groupBox1.Width - arrastreImagen.Width;

                // Se verifica si la posici�n y es menor que 0, se ajusta para que est� en el borde superior del groupBox1
                if (y < 0)
                    y = 0;
                // Si la posici�n y + la altura del PictureBox es mayor que la altura del groupBox1, se ajusta para que est� en el borde inferior del groupBox1
                else if (y + arrastreImagen.Height > groupBox1.Height)
                    y = groupBox1.Height - arrastreImagen.Height;

                // Se establece la nueva posici�n del PictureBox arrastrado
                arrastreImagen.Location = new Point(x, y);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Cuando se suelta el bot�n del rat�n, se restablece el PictureBox que se est� arrastrando
            arrastreImagen = null;
        }

        private void deshacer_Click(object sender, EventArgs e)
        {
            if (paneles.Count > 0)//Verifica si hay elementos en una colecci�n llamada paneles.
            {
                PictureBox ultimoPanel = paneles[paneles.Count - 1]; //recupera el �ltimo elemento (el PictureBox agregado m�s recientemente) de la colecci�n paneles.
                groupBox1.Controls.Remove(ultimoPanel);//elimina el �ltimo Panel (el PictureBox) de la colecci�n Controls del groupBox1.
                paneles.RemoveAt(paneles.Count - 1);// elimina el �ltimo elemento (el mismo PictureBox que se acaba de eliminar de groupBox1) de la colecci�n paneles.
                cantidadImagen--;//VER SI ES NECESARIO 
            }
        }

       
    }
}
