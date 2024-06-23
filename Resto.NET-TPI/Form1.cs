using Resto.NET_TPI.Properties;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Resto.NET_TPI
{
    public partial class Form1 : Form
    {
        private PictureBox arrastreImagen = null; //controla el arrastre de la imagen. Cuando suelte el usuario se marcar� null
        private Point coordenadasImagen; //Se almacena las coordenadas de la imagen
        List<PictureBox> paneles = new List<PictureBox>(); //lista para borrar.
        private Dictionary<PictureBox, ElementoRestaurante> pictureBoxToElemento = new Dictionary<PictureBox, ElementoRestaurante>();
        private bool esModoPrevisualizacion = false;
        private int contadorMesa = 0;
        private Point ultimaPosicion;



        public Form1()
        {
            InitializeComponent();
            VisibilidadInicial(); //Ocultar paneles menu

            miGrilla.Visible = false; //Por defecto se va a iniciar apagada. 
            miGrilla.BackgroundImageLayout = ImageLayout.Stretch;//Ajustar imagen al tama�o
            panelDise�o.BackgroundImageLayout = ImageLayout.Stretch;

            panelDise�o.EnableDoubleBuffering(); //Tecnica de renderizado secundario  [] -> muestra picture box
            miGrilla.EnableDoubleBuffering();


            //Agregar manejador de eventos para el panelDise�o
            panelDise�o.MouseClick += PanelDise�o_MouseClick;

            //Agregar evento cada vez que se cambia un valor en el propertyGrid1
            propertyGrid1.PropertyValueChanged += PropertyGrid1_PropertyValueChanged;

            //por defecto, inicializar el programa en modo previsualizacion
            esModoPrevisualizacion = true;
            miGrilla.Visible = false;
            panelHerramientas.Visible = false;
            ActualizarVisibilidadLabels();
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

        private void ActualizarElementoInterfaz(PictureBox pictureBox, ElementoRestaurante elemento)
        {
            Label infoLabel = null;

            // Verificar si el PictureBox ya tiene un Label asociado
            foreach (Control control in panelDise�o.Controls)
            {
                if (control is Label lbl && lbl.Tag == pictureBox)
                {
                    infoLabel = lbl;
                    break;
                }
            }

            if (infoLabel == null)
            {
                // Crear un nuevo Label y asociarlo con el PictureBox
                infoLabel = new Label();
                infoLabel.Tag = pictureBox;
                infoLabel.AutoSize = true;
                panelDise�o.Controls.Add(infoLabel);
            }

            // Actualizar el texto del Label
            string numero = elemento.Numero.ToString() ?? "N/A"; //null-coalescing operator -> sirve para proporcionar un valor "por defecto" en caso de la que la expresion a la izq
                                                                 //sea null
            string ocupadoTexto = elemento.Ocupado ? "S�" : "No";
            string MozoAsignado = elemento.Mozo.ToString();
            infoLabel.Text = $"Nro: {numero}\nOcupado: {ocupadoTexto}\nConsumo: ${45}\nMozo: {MozoAsignado}";

            // Posicionar el Label sobre el PictureBox
            infoLabel.Location = new Point(pictureBox.Left, pictureBox.Top - infoLabel.Height);
            infoLabel.BringToFront();
            infoLabel.Visible = esModoPrevisualizacion;  // Mostrar solo en modo previsualizaci�n
        }

        private void ActualizarVisibilidadLabels()
        {
            foreach (Control control in panelDise�o.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Visible = esModoPrevisualizacion;
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

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.propertygrid?view=windowsdesktop-8.0#methods
        {
            // Verificar si el objeto seleccionado en el PropertyGrid es un ElementoRestaurante
            if (propertyGrid1.SelectedObject is ElementoRestaurante elemento)
            {
                // Buscar el PictureBox asociado al ElementoRestaurante
                var pictureBox = pictureBoxToElemento.FirstOrDefault(x => x.Value == elemento).Key;

                if (pictureBox != null)
                {
                    // Actualizar la interfaz del PictureBox (por ejemplo, el Label asociado)
                    ActualizarElementoInterfaz(pictureBox, elemento);
                }
            }
        }

        private void PanelDise�o_MouseClick(object sender, MouseEventArgs e)
        {
            // Variable para verificar si se hizo clic fuera de todas las PictureBoxes
            bool clicFueraPictureBox = true;

            // Iterar sobre cada PictureBox en la lista paneles
            foreach (PictureBox pictureBox in paneles)
            {
                // Verificar si la ubicaci�n del clic est� dentro de los l�mites de la PictureBox actual
                if (pictureBox.Bounds.Contains(e.Location))
                {
                    // Si se hizo clic dentro de una PictureBox, marcar que no fue clic afuera
                    clicFueraPictureBox = false;
                    break; // Salir del bucle porque ya encontramos la PictureBox clicada
                }
            }

            // Si se hizo clic fuera de todas las PictureBoxes
            if (clicFueraPictureBox)
            {
                // Desseleccionar el objeto seleccionado en el PropertyGrid
                propertyGrid1.SelectedObject = null;

                // Ocultar el PropertyGrid
                propertyGrid1.Visible = false;
            }
        }
        private void modoToolStripMenuItem_Click_1(object sender, EventArgs e) //Modo Previsualizacion
        {
            esModoPrevisualizacion = true;
            miGrilla.Visible = false;
            panelHerramientas.Visible = false;
            ActualizarVisibilidadLabels();
            ActualizarEstadoEliminarItem();
        }
        private void modoEdici�nToolStripMenuItem_Click_1(object sender, EventArgs e) //Modo Edicion
        {
            esModoPrevisualizacion = false;
            miGrilla.Visible = true;
            propertyGrid1.Visible = false;
            panelHerramientas.Visible = true;
            ActualizarVisibilidadLabels();
            ActualizarEstadoEliminarItem();
        }

        //En cada bot�n de los paneles de la barra de Herram llamamos al m�todo para que sea visible
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

        //M�todo para cargar la imagen y sus propiedades a los pictureBox y para asociar las imagenes a los botones
        private void CargarImagenMesa(Image nombre, Mesa mesa)
        {
            CargarImagen(nombre, mesa);
        }

        private void CargarImagenSilla(Image nombre, Silla silla)
        {
            CargarImagen(nombre, silla);
        }

        private void CargarImagenDivisor(Image nombre, Divisor divisor)
        {
            CargarImagen(nombre, divisor);
        }

        private void CargarImagen(Image nombre, ElementoRestaurante elementoRestaurante)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = nombre;
            pictureBox.Size = new Size(100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;//Establece SizeMode a StretchImage para ajustar la imagen

            Point posicion;
            Random random = new Random();
            bool hayPosicionDisponible = false; //Variable que me indica que hay una posici�n disponible para crear mesa/silla
            int maxIntentos = 1000; //La cantidad de veces que intenta encontrar una posici�n
            int intentos = 0;
            //Agregar cada PictureBox creado al control del contenedor panelDise�o
            panelDise�o.Controls.Add(pictureBox);
            pictureBox.BringToFront();

            pictureBoxToElemento.Add(pictureBox, elementoRestaurante);


            while (intentos < maxIntentos)
            {
                posicion = new Point(random.Next(panelDise�o.Width - pictureBox.Size.Width), random.Next(panelDise�o.Height - pictureBox.Size.Height));

                if (!HayColision(posicion, pictureBox.Size, null))
                {
                    hayPosicionDisponible = true;
                    pictureBox.Location = posicion;
                    break;
                }
                intentos++;
            }

            if (!hayPosicionDisponible)
            {
                MessageBox.Show("No hay m�s lugar para agregar.");
            }
            else
            {
                //Agregar los manejadores de eventos de arrastre
                pictureBox.MouseDown += PictureBox_MouseDown;
                pictureBox.MouseMove += PictureBox_MouseMove;
                pictureBox.MouseUp += PictureBox_MouseUp;

                panelDise�o.Controls.Add(pictureBox); //Agregar cada PictureBox creado al control del contenedor panelDise�o
                pictureBox.BringToFront();
                ActualizarElementoInterfaz(pictureBox, elementoRestaurante);
                ActualizarVisibilidadLabels();
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");

                eliminarItem.Click += (s, e) =>
                {

                    panelDise�o.Controls.Remove(pictureBox);
                    paneles.Remove(pictureBox);
                };



                contextMenu.Items.Add(eliminarItem);
                pictureBox.ContextMenuStrip = contextMenu;
                //cantidadImagen++; (VER SI ES NECESARIO para el modo PreVisualizaci�n)
                paneles.Add(pictureBox);//se agrega a la lista por si se necesita eliminar
            }

        }

        private void ActualizarEstadoEliminarItem()
        {
            foreach(PictureBox pictureBox in paneles)
            {

                ToolStripMenuItem eliminar = (ToolStripMenuItem)pictureBox.ContextMenuStrip.Items[0];
                eliminar.Enabled = !esModoPrevisualizacion;

            }
        }

        //M�todos y eventos para arrastrar la imagen
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el PictureBox, se establece el PictureBox que se est� arrastrando y se registra la posici�n de inicio del mouse
            if (e.Button == MouseButtons.Left)
            {
                arrastreImagen = sender as PictureBox;
                coordenadasImagen = e.Location;
                ultimaPosicion = arrastreImagen.Location;
            }

            if (arrastreImagen != null && esModoPrevisualizacion && e.Button == MouseButtons.Left)
            {
                // Mostrar el PropertyGrid y seleccionar el objeto asociado al PictureBox
                propertyGrid1.SelectedObject = pictureBoxToElemento[arrastreImagen];
                propertyGrid1.Visible = true;
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            if (arrastreImagen != null)
            {
                if (HayColision(arrastreImagen.Location, arrastreImagen.Size, arrastreImagen))
                {
                    arrastreImagen.Location = ultimaPosicion;
                }
                else
                {
                    ultimaPosicion = arrastreImagen.Location;
                }
            }

            // Cuando se suelta el bot�n del mouse, se restablece el PictureBox que se est� arrastrando
            arrastreImagen = null;


        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (esModoPrevisualizacion) 
            {
                return;
            }

            //Se verifica si se est� arrastrando un PictureBox y si se est� manteniendo presionado el bot�n izquierdo del mouse
            if (arrastreImagen != null && e.Button == MouseButtons.Left)
            {
                //Se convierte la posici�n del rat�n en coordenadas relativas a la grilla
                Point newLocation = miGrilla.PointToClient(MousePosition);
                //Se calcula la nueva posici�n del PictureBox arrastrado
                int x = newLocation.X - coordenadasImagen.X;
                int y = newLocation.Y - coordenadasImagen.Y;

                // Se verifica si el PictureBox est� dentro de los l�mites de la grilla
                // Si la posici�n X es menor que 0, se ajusta para que est� en el borde izquierdo de la grilla
                if (x < 0)
                    x = 0;
                // Si la posici�n x + el ancho del PictureBox es mayor que el ancho de la grilla, se ajusta para que est� en el borde derecho
                else if (x + arrastreImagen.Width > miGrilla.Width)
                    x = miGrilla.Width - arrastreImagen.Width;

                // Se verifica si la posici�n Y es menor que 0, se ajusta para que est� en el borde superior de la grilla
                if (y < 0)
                    y = 0;
                // Si la posici�n Y + la altura del PictureBox es mayor que la altura de la grilla, se ajusta para que est� en el borde inferior de la misma
                else if (y + arrastreImagen.Height > miGrilla.Height)
                    y = miGrilla.Height - arrastreImagen.Height;

               
                Point nuevaUbicacion = new Point(x, y);

                arrastreImagen.Location = nuevaUbicacion;


                panelDise�o.Refresh(); //refresca el panel forzando el redibujado de todo el panel y sus controles.

            }

        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Verificar si se hizo clic con el bot�n izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                // Obtener la PictureBox que gener� el evento
                PictureBox pictureBox = sender as PictureBox;

                // Verificar si la PictureBox no es nula y si est� presente en el diccionario pictureBoxToElemento
                if (pictureBox != null && pictureBoxToElemento.ContainsKey(pictureBox))
                {
                    // Verificar si estamos en modo previsualizaci�n
                    if (esModoPrevisualizacion)
                    {
                        // Mostrar el objeto asociado a la PictureBox en el PropertyGrid
                        propertyGrid1.SelectedObject = pictureBoxToElemento[pictureBox];

                        // Hacer visible el PropertyGrid
                        propertyGrid1.Visible = true;

                        // Actualizar la interfaz para reflejar cambios en el estado de ocupaci�n
                        ElementoRestaurante elemento = pictureBoxToElemento[pictureBox];
                        ActualizarElementoInterfaz(pictureBox, elemento);
                    }
                }
            }
        }

        //Carga las im�genes a los botones llamando al m�todo y utilizando el evento
        private void bntCircular2_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 2;
            mesa.MesaCuadrada = false;
            CargarImagenMesa(Resources.mesaParaDosCircu, mesa);
        }
        private void btnRec2_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 2;
            mesa.MesaCuadrada = true;
            CargarImagenMesa(Resources.mesaParaDosRectang, mesa);
        }
        private void bntCir4_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 4;
            mesa.MesaCuadrada = false;
            CargarImagenMesa(Resources.mesaParaCuatroCircu, mesa);
        }
        private void btnRec4_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 4;
            mesa.MesaCuadrada = true;
            CargarImagenMesa(Resources.mesaParaCuatroRectang, mesa);
        }
        private void btnCir6_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 6;
            mesa.MesaCuadrada = false;
            CargarImagenMesa(Resources.mesaParaSeisCircu, mesa);
        }
        private void btnRec6_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 6;
            mesa.MesaCuadrada = true;
            CargarImagenMesa(Resources.mesaParaSeisRectang, mesa);
        }
        private void btnCir8_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 8;
            mesa.MesaCuadrada = false;
            CargarImagenMesa(Resources.mesaParaOchoCircu, mesa);
        }
        private void btnRec8_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.cantSillas = 8;
            mesa.MesaCuadrada = true;
            CargarImagenMesa(Resources.mesaParaOchoRectang, mesa);
        }
        private void bntHorizontal_Click_1(object sender, EventArgs e)
        {
            Divisor divisor = new Divisor();
            CargarImagenDivisor(Resources.divisorHorizontal, divisor);
        }
        private void btnVertical_Click_1(object sender, EventArgs e)
        {
            Divisor divisor = new Divisor();
            CargarImagenDivisor(Resources.divisorVertical, divisor);
        }
        private void btnSilla_Click_1(object sender, EventArgs e)
        {
            Silla silla = new Silla();
            CargarImagenSilla(Resources.Banqueta, silla);
        }

        //Para BORRAR la ultima accion
        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (paneles.Count > 0)
            {
                PictureBox ultimoPanel = paneles[paneles.Count - 1];
                panelDise�o.Controls.Remove(ultimoPanel);
                paneles.RemoveAt(paneles.Count - 1);

                // Verificar si existe la entrada en el diccionario
                if (pictureBoxToElemento.ContainsKey(ultimoPanel))
                {
                    // Eliminar el objeto del diccionario
                    var objetoEliminado = pictureBoxToElemento[ultimoPanel];
                    pictureBoxToElemento.Remove(ultimoPanel);

                    // Ocultar el propertyGrid si el objeto eliminado es el seleccionado
                    if (propertyGrid1.SelectedObject == objetoEliminado)
                    {
                        propertyGrid1.SelectedObject = null;
                        propertyGrid1.Visible = false;
                    }
                }

                // Eliminar el label asociado a la PictureBox
                foreach (Control control in panelDise�o.Controls)
                {
                    if (control is Label lbl && lbl.Tag == ultimoPanel)
                    {
                        panelDise�o.Controls.Remove(lbl);
                        lbl.Dispose();
                        break;
                    }
                }
            }




        }
        private bool HayColision(Point posicion, Size tamano, Control ignoreControl)
        {
            // Crea un rect�ngulo basado en la posici�n y tama�o especificados.
            Rectangle rect = new Rectangle(posicion, tamano);

            // Itera a trav�s de todos los PictureBox en la lista de paneles.
            foreach (PictureBox pictureBox in paneles)
            {
                // Si el PictureBox actual es el que se debe ignorar, contin�a con el siguiente.
                if (pictureBox == ignoreControl) continue;

                // Crea un rect�ngulo para el PictureBox actual basado en su ubicaci�n y tama�o.
                Rectangle exRect = new Rectangle(pictureBox.Location, pictureBox.Size);

                // Verifica si el rect�ngulo especificado intersecta con el rect�ngulo del PictureBox actual.
                if (rect.IntersectsWith(exRect))
                {
                    // Si hay una intersecci�n, retorna true indicando una colisi�n.
                    return true;
                }
            }





            // Si no se detecta ninguna colisi�n despu�s de verificar todos los PictureBox, retorna false
            return false;
        }

    }
}
