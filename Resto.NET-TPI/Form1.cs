using Resto.NET_TPI.Properties;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Resto.NET_TPI
{
    public partial class Form1 : Form
    {
        private PictureBox arrastreImagen = null; //controla el arrastre de la imagen. Cuando suelte el usuario se marcará null
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
            miGrilla.BackgroundImageLayout = ImageLayout.Stretch;//Ajustar imagen al tamaño
            panelDiseño.BackgroundImageLayout = ImageLayout.Stretch;

            panelDiseño.EnableDoubleBuffering(); //Tecnica de renderizado secundario  [] -> muestra picture box
            miGrilla.EnableDoubleBuffering();



            //Agregar manejador de eventos para el panelDiseño
            panelDiseño.MouseClick += PanelDiseño_MouseClick;

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
            if (pictureBox.Tag is Divisor)
            {
                return;
            }

            Label infoLabel = null;

            // Verificar si el PictureBox ya tiene un Label asociado
            foreach (Control control in panelDiseño.Controls)
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
                panelDiseño.Controls.Add(infoLabel);
            }

            // Actualizar el texto del Label
            string numero = elemento.Numero == 0 ? "No asignado" : elemento.Numero.ToString();

            string ocupadoTexto = elemento.Ocupado ? "Ocupada" : "Disponible";

            string reservadoTexto = elemento.Reservado ? "Reservada" : "No reservada";

            string mozoAsignado = elemento.Mozo == 0 ? "No asignado" : elemento.Mozo.ToString();

            decimal totalConsumo = 0;

            string clientes = "";

            if (elemento is Mesa mesa)
            {
                if (elemento.Consumos.Count > 0)
                {
                    totalConsumo = elemento.Consumos.Sum(consumo => consumo.Precio);
                }
                clientes = mesa.Clientes.Count == 0 ? "Sin clientes" : mesa.Clientes.Count.ToString();
                mesa.ActualizarConsumos();

                // Actualización de estados de reserva y ocupación
                if (mesa.Reservado)
                {
                    mesa.Ocupado = false;
                    mesa.Clientes.Clear();
                    mesa.Consumos.Clear();
                    infoLabel.Text = $"#{numero}\nEstado: {reservadoTexto}";
                }
                else if (mesa.Clientes.Count > 0)
                {
                    mesa.Ocupado = true;
                    infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}\nClientes: {clientes}\nConsumo: ${totalConsumo:F2}";
                }
                else
                {
                    mesa.Ocupado = false;
                    mesa.Clientes.Clear();
                    mesa.Consumos.Clear();
                    infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}";
                }
            }

            if (elemento is Silla silla)
            {
                //Controla la logica dependiendo de lo que tenga el propertygrid
                if (silla.Ocupado && silla.Cliente == null)
                {
                    silla.Cliente = new Cliente();
                }
                else if (silla.Ocupado == false)
                {
                    silla.Cliente = null;
                }

                //Añade el consumo del cliente a la silla.Consumos
                if (silla.Consumos != null && silla.Cliente != null)
                {
                    silla.Consumos.Clear();
                    silla.Consumos.AddRange(silla.Cliente.Consumos);

                    totalConsumo = silla.Consumos.Sum(consumo => consumo.Precio);

                }



                //formateo de datos para mostrar en el label
                string consumosTexto = totalConsumo == 0 ? "Sin consumos" : $"Consumos: ${totalConsumo:F2}";
                string cliente = (silla.Cliente == null) ? "Sin cliente" : "1";
                if (silla.Reservado)
                {
                    silla.Ocupado = false;
                    infoLabel.Text = $"#{numero}\nEstado: {reservadoTexto}";

                }
                else if (silla.Ocupado)
                {
                    silla.Reservado = false;
                    infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}\nCliente: {cliente}\n{consumosTexto:F2}";

                }
                else
                {
                    infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}";
                }


            }

            // Posicionar el Label sobre el PictureBox
            infoLabel.Location = new Point(pictureBox.Left, pictureBox.Top - infoLabel.Height);
            infoLabel.BringToFront();
            infoLabel.Visible = esModoPrevisualizacion;  // Mostrar solo en modo previsualización
        }

        private void ActualizarVisibilidadLabels()
        {
            foreach (Control control in panelDiseño.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Visible = esModoPrevisualizacion;
                }
            }
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

        private void PanelDiseño_MouseClick(object sender, MouseEventArgs e)
        {
            // Variable para verificar si se hizo clic fuera de todas las PictureBoxes
            bool clicFueraPictureBox = true;

            // Iterar sobre cada PictureBox en la lista paneles
            foreach (PictureBox pictureBox in paneles)
            {
                // Verificar si la ubicación del clic está dentro de los límites de la PictureBox actual
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
            timer1.Start();
        }
        private void modoEdiciónToolStripMenuItem_Click_1(object sender, EventArgs e) //Modo Edicion
        {
            esModoPrevisualizacion = false;
            miGrilla.Visible = true;
            propertyGrid1.Visible = false;
            panelHerramientas.Visible = true;
            ActualizarVisibilidadLabels();
            ActualizarEstadoEliminarItem();
            timer1.Stop();
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
            pictureBox.Tag = elementoRestaurante;


            pictureBoxToElemento.Add(pictureBox, elementoRestaurante);


            //Agregar los manejadores de eventos de arrastre
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseClick += PictureBox_MouseClick;

            panelDiseño.Controls.Add(pictureBox); //Agregar cada PictureBox creado al control del contenedor panelDiseño
            pictureBox.BringToFront();
            ActualizarElementoInterfaz(pictureBox, elementoRestaurante);
            ActualizarVisibilidadLabels();

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");

            eliminarItem.Click += (s, e) =>
            {

                panelDiseño.Controls.Remove(pictureBox);
                paneles.Remove(pictureBox);
                EliminarLabelAsociado(pictureBox);
            };



            contextMenu.Items.Add(eliminarItem);
            pictureBox.ContextMenuStrip = contextMenu;

            paneles.Add(pictureBox);//se agrega a la lista por si se necesita eliminar


        }

        private void EliminarLabelAsociado(PictureBox pictureBox)
        {
            // Buscar y eliminar el Label asociado al PictureBox
            foreach (Control control in panelDiseño.Controls)
            {
                if (control is Label lbl && lbl.Tag == pictureBox)
                {
                    panelDiseño.Controls.Remove(lbl);
                    lbl.Dispose(); // Liberar recursos del Label eliminado
                    break; // Salir del bucle una vez encontrado y eliminado el Label
                }
            }
        }

        private void ActualizarEstadoEliminarItem()
        {
            foreach (PictureBox pictureBox in paneles)
            {

                ToolStripMenuItem eliminar = (ToolStripMenuItem)pictureBox.ContextMenuStrip.Items[0];
                eliminar.Enabled = !esModoPrevisualizacion;

            }
        }

        //Métodos y eventos para arrastrar la imagen
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Al hacer clic en el PictureBox, se establece el PictureBox que se está arrastrando y se registra la posición de inicio del mouse
            if (e.Button == MouseButtons.Left)
            {
                arrastreImagen = sender as PictureBox;
                coordenadasImagen = e.Location;
                ultimaPosicion = arrastreImagen.Location;

                if (arrastreImagen.Tag is Divisor) //Si es un divisor, no muestra el panel de propiedades
                {
                    return;
                }
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

            // Cuando se suelta el botón del mouse, se restablece el PictureBox que se está arrastrando
            arrastreImagen = null;


        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (esModoPrevisualizacion)
            {
                return;
            }

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


                Point nuevaUbicacion = new Point(x, y);

                arrastreImagen.Location = nuevaUbicacion;


                panelDiseño.Refresh(); //refresca el panel forzando el redibujado de todo el panel y sus controles.

            }

        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Verificar si se hizo clic con el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                // Obtener la PictureBox que generó el evento
                PictureBox pictureBox = sender as PictureBox;

                // Verificar si la PictureBox no es nula y si está presente en el diccionario pictureBoxToElemento
                if (pictureBox != null && pictureBoxToElemento.ContainsKey(pictureBox))
                {
                    // Verificar si estamos en modo previsualización
                    if (esModoPrevisualizacion)
                    {
                        if (pictureBox.Tag is Divisor) //Si es un divisor, no muestra el panel de propiedades
                        {
                            return;
                        }
                        // Mostrar el objeto asociado a la PictureBox en el PropertyGrid
                        propertyGrid1.SelectedObject = pictureBoxToElemento[pictureBox];

                        // Hacer visible el PropertyGrid
                        propertyGrid1.Visible = true;

                        // Actualizar la interfaz para reflejar cambios en el estado de ocupación
                        ElementoRestaurante elemento = pictureBoxToElemento[pictureBox];
                        ActualizarElementoInterfaz(pictureBox, elemento);
                    }
                }
            }
        }

        //Carga las imágenes a los botones llamando al método y utilizando el evento
        private void bntCircular2_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 2;
            CargarImagenMesa(Resources.mesaParaDosCircu, mesa);
        }
        private void btnRec2_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 2;
            CargarImagenMesa(Resources.mesaParaDosRectang, mesa);
        }
        private void bntCir4_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 4;
            CargarImagenMesa(Resources.mesaParaCuatroCircu, mesa);
        }
        private void btnRec4_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 4;
            CargarImagenMesa(Resources.mesaParaCuatroRectang, mesa);
        }
        private void btnCir6_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 6;
            CargarImagenMesa(Resources.mesaParaSeisCircu, mesa);
        }
        private void btnRec6_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 6;
            CargarImagenMesa(Resources.mesaParaSeisRectang, mesa);
        }
        private void btnCir8_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 8;
            CargarImagenMesa(Resources.mesaParaOchoCircu, mesa);
        }
        private void btnRec8_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.CantSillas = 8;
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
                panelDiseño.Controls.Remove(ultimoPanel);
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
                foreach (Control control in panelDiseño.Controls)
                {
                    if (control is Label lbl && lbl.Tag == ultimoPanel)
                    {
                        panelDiseño.Controls.Remove(lbl);
                        lbl.Dispose();
                        break;
                    }
                }
            }




        }
        private bool HayColision(Point posicion, Size tamano, Control ignoreControl)
        {
            // Crea un rectángulo basado en la posición y tamaño especificados.
            Rectangle rect = new Rectangle(posicion, tamano);

            // Itera a través de todos los PictureBox en la lista de paneles.
            foreach (PictureBox pictureBox in paneles)
            {
                // Si el PictureBox actual es el que se debe ignorar, continúa con el siguiente.
                if (pictureBox == ignoreControl) continue;

                // Crea un rectángulo para el PictureBox actual basado en su ubicación y tamaño.
                Rectangle exRect = new Rectangle(pictureBox.Location, pictureBox.Size);

                // Verifica si el rectángulo especificado intersecta con el rectángulo del PictureBox actual.
                if (rect.IntersectsWith(exRect))
                {
                    // Si hay una intersección, retorna true indicando una colisión.
                    return true;
                }
            }
            // Si no se detecta ninguna colisión después de verificar todos los PictureBox, retorna false
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control control in panelDiseño.Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Tag is ElementoRestaurante elemento)
                {
                    // Verificar si el PictureBox tiene un Label asociado
                    Label infoLabel = null;
                    foreach (Control innerControl in panelDiseño.Controls)
                    {
                        if (innerControl is Label label && label.Tag == pictureBox)
                        {
                            infoLabel = label;
                            break;
                        }
                    }

                    // Si se encuentra el Label asociado, actualizar su contenido
                    if (infoLabel != null)
                    {
                        // Actualizar el texto del Label
                        string numero = elemento.Numero == 0 ? "No asignado" : elemento.Numero.ToString();

                        string ocupadoTexto = elemento.Ocupado ? "Ocupada" : "Disponible";

                        string reservadoTexto = elemento.Reservado ? "Reservada" : "No reservada";

                        string mozoAsignado = elemento.Mozo == 0 ? "No asignado" : elemento.Mozo.ToString();

                        decimal totalConsumo = 0;

                        string clientes = "";

                        if (elemento is Mesa mesa)
                        {
                            if (elemento.Consumos.Count > 0)
                            {
                                totalConsumo = elemento.Consumos.Sum(consumo => consumo.Precio);
                            }
                            clientes = mesa.Clientes.Count == 0 ? "Sin clientes" : mesa.Clientes.Count.ToString();
                            mesa.ActualizarConsumos();

                            // Actualización de estados de reserva y ocupación
                            if (mesa.Reservado)
                            {
                                mesa.Ocupado = false;
                                mesa.Clientes.Clear();
                                mesa.Consumos.Clear();
                                infoLabel.Text = $"#{numero}\nEstado: {reservadoTexto}";
                            }
                            else if (mesa.Clientes.Count > 0)
                            {
                                mesa.Ocupado = true;
                                infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}\nClientes: {clientes}\nConsumo: ${totalConsumo:F2}";
                            }
                            else
                            {
                                mesa.Ocupado = false;
                                mesa.Clientes.Clear();
                                mesa.Consumos.Clear();
                                infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}";
                            }
                        }

                        if (elemento is Silla silla)
                        {
                            //Controla la logica dependiendo de lo que tenga el propertygrid
                            if (silla.Ocupado && silla.Cliente == null)
                            {
                                silla.Cliente = new Cliente();
                            }
                            else if (silla.Ocupado == false)
                            {
                                silla.Cliente = null;
                            }

                            //Añade el consumo del cliente a la silla.Consumos
                            if (silla.Consumos != null && silla.Cliente != null)
                            {
                                silla.Consumos.Clear();
                                silla.Consumos.AddRange(silla.Cliente.Consumos);

                                totalConsumo = silla.Consumos.Sum(consumo => consumo.Precio);

                            }



                            //formateo de datos para mostrar en el label
                            string consumosTexto = totalConsumo == 0 ? "Sin consumos" : $"Consumos: ${totalConsumo:F2}";
                            string cliente = (silla.Cliente == null) ? "Sin cliente" : "1";
                            if (silla.Reservado)
                            {
                                silla.Ocupado = false;
                                infoLabel.Text = $"#{numero}\nEstado: {reservadoTexto}";

                            }
                            else if (silla.Ocupado)
                            {
                                silla.Reservado = false;
                                infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}\nCliente: {cliente}\n{consumosTexto:F2}";

                            }
                            else
                            {
                                infoLabel.Text = $"#{numero}\nEstado: {ocupadoTexto}\nMozo: {mozoAsignado}";
                            }

                            // Posicionar el Label sobre el PictureBox
                            infoLabel.Location = new Point(pictureBox.Left, pictureBox.Top - infoLabel.Height);
                            infoLabel.BringToFront();
                            infoLabel.Visible = esModoPrevisualizacion;  // Mostrar solo en modo previsualización
                        }
                    }
                }
            }
        }
    }
}
