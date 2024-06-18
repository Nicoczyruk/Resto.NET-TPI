namespace Resto.NET_TPI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            miGrilla.Visible = false;//Por defecto se va a iniciar apagada 
            miGrilla.BackgroundImageLayout = ImageLayout.Stretch;// Ajustar imagen al tamaño
            panelDiseño.BackgroundImageLayout= ImageLayout.Stretch;
            
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
    }
}
