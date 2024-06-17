namespace Resto.NET_TPI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            guardarPlanoToolStripMenuItem = new ToolStripMenuItem();
            cargarPlanoToolStripMenuItem = new ToolStripMenuItem();
            vistaToolStripMenuItem = new ToolStripMenuItem();
            modoEdiciónToolStripMenuItem = new ToolStripMenuItem();
            modoToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            panelHerramientas = new Panel();
            button1 = new Button();
            panelDiseño = new Panel();
            propertyGrid1 = new PropertyGrid();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            panelHerramientas.SuspendLayout();
            panelDiseño.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, vistaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guardarPlanoToolStripMenuItem, cargarPlanoToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            archivoToolStripMenuItem.Click += archivoToolStripMenuItem_Click;
            // 
            // guardarPlanoToolStripMenuItem
            // 
            guardarPlanoToolStripMenuItem.Name = "guardarPlanoToolStripMenuItem";
            guardarPlanoToolStripMenuItem.Size = new Size(149, 22);
            guardarPlanoToolStripMenuItem.Text = "Guardar plano";
            // 
            // cargarPlanoToolStripMenuItem
            // 
            cargarPlanoToolStripMenuItem.Name = "cargarPlanoToolStripMenuItem";
            cargarPlanoToolStripMenuItem.Size = new Size(149, 22);
            cargarPlanoToolStripMenuItem.Text = "Cargar plano";
            cargarPlanoToolStripMenuItem.Click += cargarPlanoToolStripMenuItem_Click;
            // 
            // vistaToolStripMenuItem
            // 
            vistaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modoEdiciónToolStripMenuItem, modoToolStripMenuItem });
            vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            vistaToolStripMenuItem.Size = new Size(44, 20);
            vistaToolStripMenuItem.Text = "Vista";
            // 
            // modoEdiciónToolStripMenuItem
            // 
            modoEdiciónToolStripMenuItem.Name = "modoEdiciónToolStripMenuItem";
            modoEdiciónToolStripMenuItem.Size = new Size(193, 22);
            modoEdiciónToolStripMenuItem.Text = "Modo edición";
            // 
            // modoToolStripMenuItem
            // 
            modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            modoToolStripMenuItem.Size = new Size(193, 22);
            modoToolStripMenuItem.Text = "Modo previsualización";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 739);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1184, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // panelHerramientas
            // 
            panelHerramientas.BorderStyle = BorderStyle.FixedSingle;
            panelHerramientas.Controls.Add(button1);
            panelHerramientas.Dock = DockStyle.Left;
            panelHerramientas.Location = new Point(0, 24);
            panelHerramientas.Name = "panelHerramientas";
            panelHerramientas.Size = new Size(200, 715);
            panelHerramientas.TabIndex = 2;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(80, 80);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // panelDiseño
            // 
            panelDiseño.BorderStyle = BorderStyle.FixedSingle;
            panelDiseño.Controls.Add(propertyGrid1);
            panelDiseño.Dock = DockStyle.Fill;
            panelDiseño.Location = new Point(200, 24);
            panelDiseño.Name = "panelDiseño";
            panelDiseño.Size = new Size(984, 715);
            panelDiseño.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Right;
            propertyGrid1.Location = new Point(782, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(200, 713);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(panelDiseño);
            Controls.Add(panelHerramientas);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Resto.NET";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelHerramientas.ResumeLayout(false);
            panelDiseño.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem guardarPlanoToolStripMenuItem;
        private ToolStripMenuItem cargarPlanoToolStripMenuItem;
        private ToolStripMenuItem vistaToolStripMenuItem;
        private ToolStripMenuItem modoEdiciónToolStripMenuItem;
        private ToolStripMenuItem modoToolStripMenuItem;
        private StatusStrip statusStrip1;
        private Panel panelHerramientas;
        private Panel panelDiseño;
        private PropertyGrid propertyGrid1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
    }
}
