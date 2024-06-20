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
            panelGeneral = new Panel();
            panelBotones = new Panel();
            btnSilla = new Button();
            panelDivisor = new Panel();
            btnVertical = new Button();
            bntHorizontal = new Button();
            btnDivisor = new Button();
            panelMesa = new Panel();
            panelMesa8 = new Panel();
            btn8Rectangular = new Button();
            btn8Circular = new Button();
            bntMesa8 = new Button();
            panelMesa6 = new Panel();
            btn6Rectangular = new Button();
            btn6Circular = new Button();
            btnMesa6 = new Button();
            panelMesa4 = new Panel();
            btn4Rectangular = new Button();
            btn4Circular = new Button();
            btnMesa4 = new Button();
            panelMesa2 = new Panel();
            btn2Rectangular = new Button();
            btnCircular2 = new Button();
            btnMesa2 = new Button();
            btnMesa = new Button();
            deshacer = new Button();
            panelTitulo = new Panel();
            groupBox1 = new GroupBox();
            panelGeneral.SuspendLayout();
            panelBotones.SuspendLayout();
            panelDivisor.SuspendLayout();
            panelMesa.SuspendLayout();
            panelMesa8.SuspendLayout();
            panelMesa6.SuspendLayout();
            panelMesa4.SuspendLayout();
            panelMesa2.SuspendLayout();
            SuspendLayout();
            // 
            // panelGeneral
            // 
            panelGeneral.BackColor = Color.MediumPurple;
            panelGeneral.Controls.Add(panelBotones);
            panelGeneral.Controls.Add(deshacer);
            panelGeneral.Controls.Add(panelTitulo);
            panelGeneral.Dock = DockStyle.Left;
            panelGeneral.Location = new Point(0, 0);
            panelGeneral.Margin = new Padding(2, 2, 2, 2);
            panelGeneral.Name = "panelGeneral";
            panelGeneral.Size = new Size(161, 597);
            panelGeneral.TabIndex = 0;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(btnSilla);
            panelBotones.Controls.Add(panelDivisor);
            panelBotones.Controls.Add(btnDivisor);
            panelBotones.Controls.Add(panelMesa);
            panelBotones.Controls.Add(btnMesa);
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Location = new Point(0, 35);
            panelBotones.Margin = new Padding(2, 2, 2, 2);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(161, 514);
            panelBotones.TabIndex = 2;
            // 
            // btnSilla
            // 
            btnSilla.BackColor = SystemColors.ActiveCaption;
            btnSilla.Dock = DockStyle.Top;
            btnSilla.Location = new Point(0, 414);
            btnSilla.Margin = new Padding(2, 2, 2, 2);
            btnSilla.Name = "btnSilla";
            btnSilla.Size = new Size(161, 35);
            btnSilla.TabIndex = 3;
            btnSilla.Text = "SILLA";
            btnSilla.UseVisualStyleBackColor = false;
            btnSilla.Click += btnSilla_Click;
            // 
            // panelDivisor
            // 
            panelDivisor.BackColor = SystemColors.ActiveCaption;
            panelDivisor.Controls.Add(btnVertical);
            panelDivisor.Controls.Add(bntHorizontal);
            panelDivisor.Dock = DockStyle.Top;
            panelDivisor.Location = new Point(0, 357);
            panelDivisor.Margin = new Padding(2, 2, 2, 2);
            panelDivisor.Name = "panelDivisor";
            panelDivisor.Size = new Size(161, 57);
            panelDivisor.TabIndex = 4;
            // 
            // btnVertical
            // 
            btnVertical.BackColor = Color.DarkGray;
            btnVertical.Dock = DockStyle.Top;
            btnVertical.Location = new Point(0, 28);
            btnVertical.Margin = new Padding(2, 2, 2, 2);
            btnVertical.Name = "btnVertical";
            btnVertical.Size = new Size(161, 28);
            btnVertical.TabIndex = 8;
            btnVertical.Text = "Vertical";
            btnVertical.UseVisualStyleBackColor = false;
            btnVertical.Click += btnVertical_Click;
            // 
            // bntHorizontal
            // 
            bntHorizontal.BackColor = Color.DarkGray;
            bntHorizontal.Dock = DockStyle.Top;
            bntHorizontal.Location = new Point(0, 0);
            bntHorizontal.Margin = new Padding(2, 2, 2, 2);
            bntHorizontal.Name = "bntHorizontal";
            bntHorizontal.Size = new Size(161, 28);
            bntHorizontal.TabIndex = 7;
            bntHorizontal.Text = "Horizontal";
            bntHorizontal.UseVisualStyleBackColor = false;
            bntHorizontal.Click += bntHorizontal_Click;
            // 
            // btnDivisor
            // 
            btnDivisor.BackColor = SystemColors.ActiveCaption;
            btnDivisor.Dock = DockStyle.Top;
            btnDivisor.Location = new Point(0, 322);
            btnDivisor.Margin = new Padding(2, 2, 2, 2);
            btnDivisor.Name = "btnDivisor";
            btnDivisor.Size = new Size(161, 35);
            btnDivisor.TabIndex = 3;
            btnDivisor.Text = "DIVISOR";
            btnDivisor.UseVisualStyleBackColor = false;
            btnDivisor.Click += btnDivisor_Click;
            // 
            // panelMesa
            // 
            panelMesa.BackColor = SystemColors.ActiveCaption;
            panelMesa.Controls.Add(panelMesa8);
            panelMesa.Controls.Add(bntMesa8);
            panelMesa.Controls.Add(panelMesa6);
            panelMesa.Controls.Add(btnMesa6);
            panelMesa.Controls.Add(panelMesa4);
            panelMesa.Controls.Add(btnMesa4);
            panelMesa.Controls.Add(panelMesa2);
            panelMesa.Controls.Add(btnMesa2);
            panelMesa.Dock = DockStyle.Top;
            panelMesa.Location = new Point(0, 35);
            panelMesa.Margin = new Padding(2, 2, 2, 2);
            panelMesa.Name = "panelMesa";
            panelMesa.Size = new Size(161, 287);
            panelMesa.TabIndex = 2;
            // 
            // panelMesa8
            // 
            panelMesa8.BackColor = SystemColors.ActiveBorder;
            panelMesa8.Controls.Add(btn8Rectangular);
            panelMesa8.Controls.Add(btn8Circular);
            panelMesa8.Dock = DockStyle.Top;
            panelMesa8.Location = new Point(0, 240);
            panelMesa8.Margin = new Padding(2, 2, 2, 2);
            panelMesa8.Name = "panelMesa8";
            panelMesa8.Size = new Size(161, 45);
            panelMesa8.TabIndex = 7;
            // 
            // btn8Rectangular
            // 
            btn8Rectangular.Dock = DockStyle.Top;
            btn8Rectangular.Location = new Point(0, 21);
            btn8Rectangular.Margin = new Padding(2, 2, 2, 2);
            btn8Rectangular.Name = "btn8Rectangular";
            btn8Rectangular.Size = new Size(161, 21);
            btn8Rectangular.TabIndex = 4;
            btn8Rectangular.Text = "Rectangular";
            btn8Rectangular.UseVisualStyleBackColor = true;
            btn8Rectangular.Click += btn8Rectangular_Click;
            // 
            // btn8Circular
            // 
            btn8Circular.Dock = DockStyle.Top;
            btn8Circular.Location = new Point(0, 0);
            btn8Circular.Margin = new Padding(2, 2, 2, 2);
            btn8Circular.Name = "btn8Circular";
            btn8Circular.Size = new Size(161, 21);
            btn8Circular.TabIndex = 3;
            btn8Circular.Text = "Circular";
            btn8Circular.UseVisualStyleBackColor = true;
            btn8Circular.Click += btn8Circular_Click;
            // 
            // bntMesa8
            // 
            bntMesa8.BackColor = Color.DarkGray;
            bntMesa8.Dock = DockStyle.Top;
            bntMesa8.Location = new Point(0, 212);
            bntMesa8.Margin = new Padding(2, 2, 2, 2);
            bntMesa8.Name = "bntMesa8";
            bntMesa8.Size = new Size(161, 28);
            bntMesa8.TabIndex = 6;
            bntMesa8.Text = "Mesa para 8";
            bntMesa8.UseVisualStyleBackColor = false;
            bntMesa8.Click += bntMesa8_Click;
            // 
            // panelMesa6
            // 
            panelMesa6.BackColor = SystemColors.ActiveBorder;
            panelMesa6.Controls.Add(btn6Rectangular);
            panelMesa6.Controls.Add(btn6Circular);
            panelMesa6.Dock = DockStyle.Top;
            panelMesa6.Location = new Point(0, 171);
            panelMesa6.Margin = new Padding(2, 2, 2, 2);
            panelMesa6.Name = "panelMesa6";
            panelMesa6.Size = new Size(161, 41);
            panelMesa6.TabIndex = 5;
            // 
            // btn6Rectangular
            // 
            btn6Rectangular.Dock = DockStyle.Top;
            btn6Rectangular.Location = new Point(0, 21);
            btn6Rectangular.Margin = new Padding(2, 2, 2, 2);
            btn6Rectangular.Name = "btn6Rectangular";
            btn6Rectangular.Size = new Size(161, 21);
            btn6Rectangular.TabIndex = 3;
            btn6Rectangular.Text = "Rectangular";
            btn6Rectangular.UseVisualStyleBackColor = true;
            btn6Rectangular.Click += btn6Rectangular_Click;
            // 
            // btn6Circular
            // 
            btn6Circular.Dock = DockStyle.Top;
            btn6Circular.Location = new Point(0, 0);
            btn6Circular.Margin = new Padding(2, 2, 2, 2);
            btn6Circular.Name = "btn6Circular";
            btn6Circular.Size = new Size(161, 21);
            btn6Circular.TabIndex = 2;
            btn6Circular.Text = "Circular";
            btn6Circular.UseVisualStyleBackColor = true;
            btn6Circular.Click += btn6Circular_Click;
            // 
            // btnMesa6
            // 
            btnMesa6.BackColor = Color.DarkGray;
            btnMesa6.Dock = DockStyle.Top;
            btnMesa6.Location = new Point(0, 143);
            btnMesa6.Margin = new Padding(2, 2, 2, 2);
            btnMesa6.Name = "btnMesa6";
            btnMesa6.Size = new Size(161, 28);
            btnMesa6.TabIndex = 4;
            btnMesa6.Text = "Mesa para 6";
            btnMesa6.UseVisualStyleBackColor = false;
            btnMesa6.Click += btnMesa6_Click;
            // 
            // panelMesa4
            // 
            panelMesa4.BackColor = SystemColors.ActiveBorder;
            panelMesa4.Controls.Add(btn4Rectangular);
            panelMesa4.Controls.Add(btn4Circular);
            panelMesa4.Dock = DockStyle.Top;
            panelMesa4.Location = new Point(0, 100);
            panelMesa4.Margin = new Padding(2, 2, 2, 2);
            panelMesa4.Name = "panelMesa4";
            panelMesa4.Size = new Size(161, 43);
            panelMesa4.TabIndex = 3;
            // 
            // btn4Rectangular
            // 
            btn4Rectangular.Dock = DockStyle.Top;
            btn4Rectangular.Location = new Point(0, 21);
            btn4Rectangular.Margin = new Padding(2, 2, 2, 2);
            btn4Rectangular.Name = "btn4Rectangular";
            btn4Rectangular.Size = new Size(161, 21);
            btn4Rectangular.TabIndex = 2;
            btn4Rectangular.Text = "Rectangular";
            btn4Rectangular.UseVisualStyleBackColor = true;
            btn4Rectangular.Click += btn4Rectangular_Click;
            // 
            // btn4Circular
            // 
            btn4Circular.Dock = DockStyle.Top;
            btn4Circular.Location = new Point(0, 0);
            btn4Circular.Margin = new Padding(2, 2, 2, 2);
            btn4Circular.Name = "btn4Circular";
            btn4Circular.Size = new Size(161, 21);
            btn4Circular.TabIndex = 1;
            btn4Circular.Text = "Circular";
            btn4Circular.UseVisualStyleBackColor = true;
            btn4Circular.Click += btn4Circular_Click;
            // 
            // btnMesa4
            // 
            btnMesa4.BackColor = Color.DarkGray;
            btnMesa4.Dock = DockStyle.Top;
            btnMesa4.Location = new Point(0, 72);
            btnMesa4.Margin = new Padding(2, 2, 2, 2);
            btnMesa4.Name = "btnMesa4";
            btnMesa4.Size = new Size(161, 28);
            btnMesa4.TabIndex = 2;
            btnMesa4.Text = "Mesa para 4";
            btnMesa4.UseVisualStyleBackColor = false;
            btnMesa4.Click += btnMesa4_Click;
            // 
            // panelMesa2
            // 
            panelMesa2.BackColor = SystemColors.ActiveBorder;
            panelMesa2.Controls.Add(btn2Rectangular);
            panelMesa2.Controls.Add(btnCircular2);
            panelMesa2.Dock = DockStyle.Top;
            panelMesa2.Location = new Point(0, 28);
            panelMesa2.Margin = new Padding(2, 2, 2, 2);
            panelMesa2.Name = "panelMesa2";
            panelMesa2.Size = new Size(161, 44);
            panelMesa2.TabIndex = 1;
            // 
            // btn2Rectangular
            // 
            btn2Rectangular.Dock = DockStyle.Top;
            btn2Rectangular.Location = new Point(0, 21);
            btn2Rectangular.Margin = new Padding(2, 2, 2, 2);
            btn2Rectangular.Name = "btn2Rectangular";
            btn2Rectangular.Size = new Size(161, 21);
            btn2Rectangular.TabIndex = 1;
            btn2Rectangular.Text = "Rectangular";
            btn2Rectangular.UseVisualStyleBackColor = true;
            btn2Rectangular.Click += btn2Rectangular_Click;
            // 
            // btnCircular2
            // 
            btnCircular2.Dock = DockStyle.Top;
            btnCircular2.Location = new Point(0, 0);
            btnCircular2.Margin = new Padding(2, 2, 2, 2);
            btnCircular2.Name = "btnCircular2";
            btnCircular2.Size = new Size(161, 21);
            btnCircular2.TabIndex = 0;
            btnCircular2.Text = "Circular";
            btnCircular2.UseVisualStyleBackColor = true;
            btnCircular2.Click += btnCircular2_Click;
            // 
            // btnMesa2
            // 
            btnMesa2.BackColor = Color.DarkGray;
            btnMesa2.Dock = DockStyle.Top;
            btnMesa2.Location = new Point(0, 0);
            btnMesa2.Margin = new Padding(2, 2, 2, 2);
            btnMesa2.Name = "btnMesa2";
            btnMesa2.Size = new Size(161, 28);
            btnMesa2.TabIndex = 0;
            btnMesa2.Text = "Mesa para 2";
            btnMesa2.UseVisualStyleBackColor = false;
            btnMesa2.Click += btnMesa2_Click;
            // 
            // btnMesa
            // 
            btnMesa.BackColor = SystemColors.ActiveCaption;
            btnMesa.Dock = DockStyle.Top;
            btnMesa.Location = new Point(0, 0);
            btnMesa.Margin = new Padding(2, 2, 2, 2);
            btnMesa.Name = "btnMesa";
            btnMesa.Size = new Size(161, 35);
            btnMesa.TabIndex = 1;
            btnMesa.Text = "MESA";
            btnMesa.UseVisualStyleBackColor = false;
            btnMesa.Click += btnMesa_Click;
            // 
            // deshacer
            // 
            deshacer.Dock = DockStyle.Bottom;
            deshacer.Location = new Point(0, 545);
            deshacer.Margin = new Padding(2, 2, 2, 2);
            deshacer.Name = "deshacer";
            deshacer.Size = new Size(161, 52);
            deshacer.TabIndex = 1;
            deshacer.Text = "Deshacer último";
            deshacer.UseVisualStyleBackColor = true;
            deshacer.Click += deshacer_Click;
            // 
            // panelTitulo
            // 
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Margin = new Padding(2, 2, 2, 2);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(161, 35);
            panelTitulo.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(161, 0);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(627, 597);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 597);
            Controls.Add(groupBox1);
            Controls.Add(panelGeneral);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            panelGeneral.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelDivisor.ResumeLayout(false);
            panelMesa.ResumeLayout(false);
            panelMesa8.ResumeLayout(false);
            panelMesa6.ResumeLayout(false);
            panelMesa4.ResumeLayout(false);
            panelMesa2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGeneral;
        private Panel panelBotones;
        private Button deshacer;
        private Panel panelTitulo;
        private Panel panelMesa;
        private Button btnMesa;
        private Button btnSilla;
        private Panel panelDivisor;
        private Button btnDivisor;
        private Panel panelMesa2;
        private Button btnMesa2;
        private Button btnMesa4;
        private Panel panelMesa6;
        private Button btnMesa6;
        private Panel panelMesa8;
        private Button bntMesa8;
        private Panel panelMesa4;
        private Button btnVertical;
        private Button bntHorizontal;
        private GroupBox groupBox1;
        private Button btnCircular2;
        private Button btn8Rectangular;
        private Button btn8Circular;
        private Button btn6Rectangular;
        private Button btn6Circular;
        private Button btn4Rectangular;
        private Button btn4Circular;
        private Button btn2Rectangular;
    }
}
