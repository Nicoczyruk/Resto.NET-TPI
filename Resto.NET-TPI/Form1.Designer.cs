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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            guardarPlanoToolStripMenuItem = new ToolStripMenuItem();
            cargarPlanoToolStripMenuItem = new ToolStripMenuItem();
            vistaToolStripMenuItem = new ToolStripMenuItem();
            modoEdiciónToolStripMenuItem = new ToolStripMenuItem();
            modoToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            panelHerramientas = new Panel();
            panel2 = new Panel();
            btnDeshacer = new Button();
            panelDivisor = new Panel();
            btnVertical = new Button();
            bntHorizontal = new Button();
            btnDivisor = new Button();
            btnSilla = new Button();
            panelMesa = new Panel();
            panelMesa8 = new Panel();
            btnRec8 = new Button();
            btnCir8 = new Button();
            btnMesa8 = new Button();
            panelMesa6 = new Panel();
            btnRec6 = new Button();
            btnCir6 = new Button();
            btnMesa6 = new Button();
            panelMesa4 = new Panel();
            btnRec4 = new Button();
            bntCir4 = new Button();
            btnMesa4 = new Button();
            panelMesa2 = new Panel();
            btnRec2 = new Button();
            bntCircular2 = new Button();
            btnMesa2 = new Button();
            btnMesa = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panelDiseño = new Panel();
            propertyGrid1 = new PropertyGrid();
            miGrilla = new MiGrilla();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            panelHerramientas.SuspendLayout();
            panel2.SuspendLayout();
            panelDivisor.SuspendLayout();
            panelMesa.SuspendLayout();
            panelMesa8.SuspendLayout();
            panelMesa6.SuspendLayout();
            panelMesa4.SuspendLayout();
            panelMesa2.SuspendLayout();
            panel1.SuspendLayout();
            panelDiseño.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, vistaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1370, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guardarPlanoToolStripMenuItem, cargarPlanoToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarPlanoToolStripMenuItem
            // 
            guardarPlanoToolStripMenuItem.Name = "guardarPlanoToolStripMenuItem";
            guardarPlanoToolStripMenuItem.Size = new Size(180, 22);
            guardarPlanoToolStripMenuItem.Text = "Guardar plano";
            guardarPlanoToolStripMenuItem.Click += guardarPlanoToolStripMenuItem_Click;
            // 
            // cargarPlanoToolStripMenuItem
            // 
            cargarPlanoToolStripMenuItem.Name = "cargarPlanoToolStripMenuItem";
            cargarPlanoToolStripMenuItem.Size = new Size(180, 22);
            cargarPlanoToolStripMenuItem.Text = "Cargar plano";
            cargarPlanoToolStripMenuItem.Click += cargarPlanoToolStripMenuItem_Click_1;
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
            modoEdiciónToolStripMenuItem.Click += modoEdiciónToolStripMenuItem_Click_1;
            // 
            // modoToolStripMenuItem
            // 
            modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            modoToolStripMenuItem.Size = new Size(193, 22);
            modoToolStripMenuItem.Text = "Modo previsualización";
            modoToolStripMenuItem.Click += modoToolStripMenuItem_Click_1;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Location = new Point(0, 727);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1370, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // panelHerramientas
            // 
            panelHerramientas.BorderStyle = BorderStyle.FixedSingle;
            panelHerramientas.Controls.Add(panel2);
            panelHerramientas.Controls.Add(panel1);
            panelHerramientas.Dock = DockStyle.Left;
            panelHerramientas.Location = new Point(0, 24);
            panelHerramientas.Name = "panelHerramientas";
            panelHerramientas.Size = new Size(200, 703);
            panelHerramientas.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Cornsilk;
            panel2.Controls.Add(btnDeshacer);
            panel2.Controls.Add(panelDivisor);
            panel2.Controls.Add(btnDivisor);
            panel2.Controls.Add(btnSilla);
            panel2.Controls.Add(panelMesa);
            panel2.Controls.Add(btnMesa);
            panel2.Dock = DockStyle.Fill;
            panel2.ForeColor = Color.Thistle;
            panel2.Location = new Point(0, 36);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 665);
            panel2.TabIndex = 1;
            // 
            // btnDeshacer
            // 
            btnDeshacer.AutoSize = true;
            btnDeshacer.BackColor = Color.Plum;
            btnDeshacer.Dock = DockStyle.Bottom;
            btnDeshacer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeshacer.ForeColor = SystemColors.ActiveCaptionText;
            btnDeshacer.Location = new Point(0, 635);
            btnDeshacer.Margin = new Padding(2);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(198, 30);
            btnDeshacer.TabIndex = 0;
            btnDeshacer.Text = "Deshacer ult acción";
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // panelDivisor
            // 
            panelDivisor.BackColor = Color.BlanchedAlmond;
            panelDivisor.Controls.Add(btnVertical);
            panelDivisor.Controls.Add(bntHorizontal);
            panelDivisor.Dock = DockStyle.Fill;
            panelDivisor.Location = new Point(0, 425);
            panelDivisor.Margin = new Padding(2);
            panelDivisor.Name = "panelDivisor";
            panelDivisor.Size = new Size(198, 240);
            panelDivisor.TabIndex = 4;
            // 
            // btnVertical
            // 
            btnVertical.AutoSize = true;
            btnVertical.BackColor = Color.Cornsilk;
            btnVertical.Dock = DockStyle.Top;
            btnVertical.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnVertical.ForeColor = SystemColors.ActiveCaptionText;
            btnVertical.Location = new Point(0, 37);
            btnVertical.Margin = new Padding(2);
            btnVertical.Name = "btnVertical";
            btnVertical.Size = new Size(198, 34);
            btnVertical.TabIndex = 6;
            btnVertical.Text = "Vertical";
            btnVertical.UseVisualStyleBackColor = false;
            btnVertical.Click += btnVertical_Click_1;
            // 
            // bntHorizontal
            // 
            bntHorizontal.AutoSize = true;
            bntHorizontal.BackColor = Color.Cornsilk;
            bntHorizontal.Dock = DockStyle.Top;
            bntHorizontal.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            bntHorizontal.ForeColor = SystemColors.ActiveCaptionText;
            bntHorizontal.Location = new Point(0, 0);
            bntHorizontal.Margin = new Padding(2);
            bntHorizontal.Name = "bntHorizontal";
            bntHorizontal.Size = new Size(198, 37);
            bntHorizontal.TabIndex = 5;
            bntHorizontal.Text = "Horizontal";
            bntHorizontal.UseVisualStyleBackColor = false;
            bntHorizontal.Click += bntHorizontal_Click_1;
            // 
            // btnDivisor
            // 
            btnDivisor.BackColor = Color.PaleGoldenrod;
            btnDivisor.Dock = DockStyle.Top;
            btnDivisor.Font = new Font("Microsoft Tai Le", 18.75F, FontStyle.Bold);
            btnDivisor.ForeColor = SystemColors.ActiveCaptionText;
            btnDivisor.Location = new Point(0, 393);
            btnDivisor.Margin = new Padding(2);
            btnDivisor.Name = "btnDivisor";
            btnDivisor.Size = new Size(198, 32);
            btnDivisor.TabIndex = 3;
            btnDivisor.Text = "Divisores";
            btnDivisor.TextAlign = ContentAlignment.TopCenter;
            btnDivisor.UseVisualStyleBackColor = false;
            btnDivisor.Click += btnDivisor_Click;
            // 
            // btnSilla
            // 
            btnSilla.BackColor = Color.PaleGoldenrod;
            btnSilla.Dock = DockStyle.Top;
            btnSilla.Font = new Font("Microsoft Tai Le", 18.75F, FontStyle.Bold);
            btnSilla.ForeColor = SystemColors.ActiveCaptionText;
            btnSilla.Location = new Point(0, 361);
            btnSilla.Margin = new Padding(2);
            btnSilla.Name = "btnSilla";
            btnSilla.Size = new Size(198, 32);
            btnSilla.TabIndex = 2;
            btnSilla.Text = "Silla Bar";
            btnSilla.TextAlign = ContentAlignment.TopCenter;
            btnSilla.UseVisualStyleBackColor = false;
            btnSilla.Click += btnSilla_Click_1;
            // 
            // panelMesa
            // 
            panelMesa.BackColor = Color.BlanchedAlmond;
            panelMesa.Controls.Add(panelMesa8);
            panelMesa.Controls.Add(btnMesa8);
            panelMesa.Controls.Add(panelMesa6);
            panelMesa.Controls.Add(btnMesa6);
            panelMesa.Controls.Add(panelMesa4);
            panelMesa.Controls.Add(btnMesa4);
            panelMesa.Controls.Add(panelMesa2);
            panelMesa.Controls.Add(btnMesa2);
            panelMesa.Dock = DockStyle.Top;
            panelMesa.Location = new Point(0, 32);
            panelMesa.Margin = new Padding(2);
            panelMesa.Name = "panelMesa";
            panelMesa.Size = new Size(198, 329);
            panelMesa.TabIndex = 1;
            // 
            // panelMesa8
            // 
            panelMesa8.Controls.Add(btnRec8);
            panelMesa8.Controls.Add(btnCir8);
            panelMesa8.Dock = DockStyle.Top;
            panelMesa8.Location = new Point(0, 283);
            panelMesa8.Margin = new Padding(2);
            panelMesa8.Name = "panelMesa8";
            panelMesa8.Size = new Size(198, 48);
            panelMesa8.TabIndex = 0;
            // 
            // btnRec8
            // 
            btnRec8.BackColor = Color.BlanchedAlmond;
            btnRec8.Dock = DockStyle.Top;
            btnRec8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRec8.ForeColor = SystemColors.ActiveCaptionText;
            btnRec8.Location = new Point(0, 25);
            btnRec8.Margin = new Padding(2);
            btnRec8.Name = "btnRec8";
            btnRec8.Size = new Size(198, 25);
            btnRec8.TabIndex = 4;
            btnRec8.Text = "Rectangular";
            btnRec8.UseVisualStyleBackColor = false;
            btnRec8.Click += btnRec8_Click;
            // 
            // btnCir8
            // 
            btnCir8.BackColor = Color.BlanchedAlmond;
            btnCir8.Dock = DockStyle.Top;
            btnCir8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCir8.ForeColor = SystemColors.ActiveCaptionText;
            btnCir8.Location = new Point(0, 0);
            btnCir8.Margin = new Padding(2);
            btnCir8.Name = "btnCir8";
            btnCir8.Size = new Size(198, 25);
            btnCir8.TabIndex = 3;
            btnCir8.Text = "Circular";
            btnCir8.UseVisualStyleBackColor = false;
            btnCir8.Click += btnCir8_Click;
            // 
            // btnMesa8
            // 
            btnMesa8.BackColor = Color.Cornsilk;
            btnMesa8.Dock = DockStyle.Top;
            btnMesa8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnMesa8.ForeColor = SystemColors.ActiveCaptionText;
            btnMesa8.Location = new Point(0, 252);
            btnMesa8.Margin = new Padding(2);
            btnMesa8.Name = "btnMesa8";
            btnMesa8.Size = new Size(198, 31);
            btnMesa8.TabIndex = 6;
            btnMesa8.Text = "Mesa para 8";
            btnMesa8.UseVisualStyleBackColor = false;
            btnMesa8.Click += btnMesa8_Click;
            // 
            // panelMesa6
            // 
            panelMesa6.Controls.Add(btnRec6);
            panelMesa6.Controls.Add(btnCir6);
            panelMesa6.Dock = DockStyle.Top;
            panelMesa6.Location = new Point(0, 199);
            panelMesa6.Margin = new Padding(2);
            panelMesa6.Name = "panelMesa6";
            panelMesa6.Size = new Size(198, 53);
            panelMesa6.TabIndex = 5;
            // 
            // btnRec6
            // 
            btnRec6.BackColor = Color.BlanchedAlmond;
            btnRec6.Dock = DockStyle.Top;
            btnRec6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRec6.ForeColor = SystemColors.ActiveCaptionText;
            btnRec6.Location = new Point(0, 25);
            btnRec6.Margin = new Padding(2);
            btnRec6.Name = "btnRec6";
            btnRec6.Size = new Size(198, 25);
            btnRec6.TabIndex = 3;
            btnRec6.Text = "Rectangular";
            btnRec6.UseVisualStyleBackColor = false;
            btnRec6.Click += btnRec6_Click;
            // 
            // btnCir6
            // 
            btnCir6.BackColor = Color.BlanchedAlmond;
            btnCir6.Dock = DockStyle.Top;
            btnCir6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCir6.ForeColor = SystemColors.ActiveCaptionText;
            btnCir6.Location = new Point(0, 0);
            btnCir6.Margin = new Padding(2);
            btnCir6.Name = "btnCir6";
            btnCir6.Size = new Size(198, 25);
            btnCir6.TabIndex = 2;
            btnCir6.Text = "Circular";
            btnCir6.UseVisualStyleBackColor = false;
            btnCir6.Click += btnCir6_Click;
            // 
            // btnMesa6
            // 
            btnMesa6.BackColor = Color.Cornsilk;
            btnMesa6.Dock = DockStyle.Top;
            btnMesa6.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnMesa6.ForeColor = SystemColors.ActiveCaptionText;
            btnMesa6.Location = new Point(0, 168);
            btnMesa6.Margin = new Padding(2);
            btnMesa6.Name = "btnMesa6";
            btnMesa6.Size = new Size(198, 31);
            btnMesa6.TabIndex = 4;
            btnMesa6.Text = "Mesa para 6";
            btnMesa6.UseVisualStyleBackColor = false;
            btnMesa6.Click += btnMesa6_Click;
            // 
            // panelMesa4
            // 
            panelMesa4.Controls.Add(btnRec4);
            panelMesa4.Controls.Add(bntCir4);
            panelMesa4.Dock = DockStyle.Top;
            panelMesa4.Location = new Point(0, 116);
            panelMesa4.Margin = new Padding(2);
            panelMesa4.Name = "panelMesa4";
            panelMesa4.Size = new Size(198, 52);
            panelMesa4.TabIndex = 3;
            // 
            // btnRec4
            // 
            btnRec4.BackColor = Color.BlanchedAlmond;
            btnRec4.Dock = DockStyle.Top;
            btnRec4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRec4.ForeColor = SystemColors.ActiveCaptionText;
            btnRec4.Location = new Point(0, 25);
            btnRec4.Margin = new Padding(2);
            btnRec4.Name = "btnRec4";
            btnRec4.Size = new Size(198, 25);
            btnRec4.TabIndex = 2;
            btnRec4.Text = "Rectangular";
            btnRec4.UseVisualStyleBackColor = false;
            btnRec4.Click += btnRec4_Click;
            // 
            // bntCir4
            // 
            bntCir4.BackColor = Color.BlanchedAlmond;
            bntCir4.Dock = DockStyle.Top;
            bntCir4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            bntCir4.ForeColor = SystemColors.ActiveCaptionText;
            bntCir4.Location = new Point(0, 0);
            bntCir4.Margin = new Padding(2);
            bntCir4.Name = "bntCir4";
            bntCir4.Size = new Size(198, 25);
            bntCir4.TabIndex = 1;
            bntCir4.Text = "Circular";
            bntCir4.UseVisualStyleBackColor = false;
            bntCir4.Click += bntCir4_Click;
            // 
            // btnMesa4
            // 
            btnMesa4.BackColor = Color.Cornsilk;
            btnMesa4.Dock = DockStyle.Top;
            btnMesa4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnMesa4.ForeColor = SystemColors.ActiveCaptionText;
            btnMesa4.Location = new Point(0, 85);
            btnMesa4.Margin = new Padding(2);
            btnMesa4.Name = "btnMesa4";
            btnMesa4.Size = new Size(198, 31);
            btnMesa4.TabIndex = 2;
            btnMesa4.Text = "Mesa para 4";
            btnMesa4.UseVisualStyleBackColor = false;
            btnMesa4.Click += btnMesa4_Click;
            // 
            // panelMesa2
            // 
            panelMesa2.BorderStyle = BorderStyle.Fixed3D;
            panelMesa2.Controls.Add(btnRec2);
            panelMesa2.Controls.Add(bntCircular2);
            panelMesa2.Dock = DockStyle.Top;
            panelMesa2.Location = new Point(0, 31);
            panelMesa2.Margin = new Padding(2);
            panelMesa2.Name = "panelMesa2";
            panelMesa2.Size = new Size(198, 54);
            panelMesa2.TabIndex = 1;
            // 
            // btnRec2
            // 
            btnRec2.BackColor = Color.BlanchedAlmond;
            btnRec2.Dock = DockStyle.Top;
            btnRec2.FlatStyle = FlatStyle.Flat;
            btnRec2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRec2.ForeColor = SystemColors.ActiveCaptionText;
            btnRec2.Location = new Point(0, 25);
            btnRec2.Margin = new Padding(2);
            btnRec2.Name = "btnRec2";
            btnRec2.Size = new Size(194, 25);
            btnRec2.TabIndex = 1;
            btnRec2.Text = "Rectangular";
            btnRec2.UseVisualStyleBackColor = false;
            btnRec2.Click += btnRec2_Click;
            // 
            // bntCircular2
            // 
            bntCircular2.BackColor = Color.BlanchedAlmond;
            bntCircular2.Dock = DockStyle.Top;
            bntCircular2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            bntCircular2.ForeColor = SystemColors.ActiveCaptionText;
            bntCircular2.Location = new Point(0, 0);
            bntCircular2.Margin = new Padding(2);
            bntCircular2.Name = "bntCircular2";
            bntCircular2.Size = new Size(194, 25);
            bntCircular2.TabIndex = 0;
            bntCircular2.Text = "Circular";
            bntCircular2.UseVisualStyleBackColor = false;
            bntCircular2.Click += bntCircular2_Click;
            // 
            // btnMesa2
            // 
            btnMesa2.BackColor = Color.Cornsilk;
            btnMesa2.Dock = DockStyle.Top;
            btnMesa2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnMesa2.ForeColor = SystemColors.ActiveCaptionText;
            btnMesa2.Location = new Point(0, 0);
            btnMesa2.Margin = new Padding(2);
            btnMesa2.Name = "btnMesa2";
            btnMesa2.Size = new Size(198, 31);
            btnMesa2.TabIndex = 0;
            btnMesa2.Text = "Mesa para 2";
            btnMesa2.UseVisualStyleBackColor = false;
            btnMesa2.Click += btnMesa2_Click;
            // 
            // btnMesa
            // 
            btnMesa.BackColor = Color.PaleGoldenrod;
            btnMesa.Dock = DockStyle.Top;
            btnMesa.Font = new Font("Microsoft Tai Le", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMesa.ForeColor = SystemColors.ActiveCaptionText;
            btnMesa.ImageAlign = ContentAlignment.TopRight;
            btnMesa.Location = new Point(0, 0);
            btnMesa.Margin = new Padding(2);
            btnMesa.Name = "btnMesa";
            btnMesa.Size = new Size(198, 32);
            btnMesa.TabIndex = 0;
            btnMesa.Text = "Mesa";
            btnMesa.TextAlign = ContentAlignment.TopCenter;
            btnMesa.UseVisualStyleBackColor = false;
            btnMesa.Click += btnMesa_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 36);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(41, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 0;
            label1.Text = "Herramientas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDiseño
            // 
            panelDiseño.BackColor = Color.Transparent;
            panelDiseño.BackgroundImage = Properties.Resources.bar;
            panelDiseño.Controls.Add(propertyGrid1);
            panelDiseño.Controls.Add(miGrilla);
            panelDiseño.Dock = DockStyle.Fill;
            panelDiseño.ForeColor = SystemColors.ControlText;
            panelDiseño.Location = new Point(200, 24);
            panelDiseño.Name = "panelDiseño";
            panelDiseño.Size = new Size(1170, 703);
            panelDiseño.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Right;
            propertyGrid1.Location = new Point(970, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(200, 703);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.Visible = false;
            // 
            // miGrilla
            // 
            miGrilla.BackColor = Color.Transparent;
            miGrilla.BackgroundImage = Properties.Resources.bar;
            miGrilla.Dock = DockStyle.Fill;
            miGrilla.Location = new Point(0, 0);
            miGrilla.Name = "miGrilla";
            miGrilla.Size = new Size(1170, 703);
            miGrilla.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bar;
            ClientSize = new Size(1370, 749);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelDivisor.ResumeLayout(false);
            panelDivisor.PerformLayout();
            panelMesa.ResumeLayout(false);
            panelMesa8.ResumeLayout(false);
            panelMesa6.ResumeLayout(false);
            panelMesa4.ResumeLayout(false);
            panelMesa2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private MiGrilla miGrilla;
        private Panel panel1;
        private Label label1;
        private Button btnDeshacer;
        private Panel panel2;
        private Button btnMesa;
        private Panel panelDivisor;
        private Button btnDivisor;
        private Button btnSilla;
        private Panel panelMesa;
        private Button btnMesa2;
        private Panel panelMesa2;
        private Panel panelMesa4;
        private Button btnMesa4;
        private Button bntCircular2;
        private Button btnRec4;
        private Button bntCir4;
        private Button btnRec2;
        private Button btnVertical;
        private Button bntHorizontal;
        private Button btnMesa6;
        private Panel panelMesa6;
        private Button btnCir6;
        private Button btnRec6;
        private Button btnMesa8;
        private Panel panelMesa8;
        private Button btnRec8;
        private Button btnCir8;
        private System.Windows.Forms.Timer timer1;
    }
}
