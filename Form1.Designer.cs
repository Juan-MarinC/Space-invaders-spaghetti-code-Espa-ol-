namespace Space_War
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
            TxPuntos = new Label();
            ContadorJuego = new System.Windows.Forms.Timer(components);
            Jugador = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Jugador).BeginInit();
            SuspendLayout();
            // 
            // TxPuntos
            // 
            TxPuntos.AutoSize = true;
            TxPuntos.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TxPuntos.ForeColor = Color.White;
            TxPuntos.Location = new Point(3, 573);
            TxPuntos.Name = "TxPuntos";
            TxPuntos.Size = new Size(74, 21);
            TxPuntos.TabIndex = 1;
            TxPuntos.Text = "Puntos: 0";
            // 
            // ContadorJuego
            // 
            ContadorJuego.Interval = 20;
            ContadorJuego.Tick += EventoContadorJuego;
            // 
            // Jugador
            // 
            Jugador.Image = Properties.Resources.Green_Tunk;
            Jugador.Location = new Point(272, 478);
            Jugador.Name = "Jugador";
            Jugador.Size = new Size(47, 62);
            Jugador.SizeMode = PictureBoxSizeMode.CenterImage;
            Jugador.TabIndex = 2;
            Jugador.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(666, 573);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 3;
            label1.Text = "Nivel 1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(732, 603);
            Controls.Add(label1);
            Controls.Add(Jugador);
            Controls.Add(TxPuntos);
            Name = "Form1";
            Text = "Form1";
            KeyDown += TeclaAbajo;
            KeyUp += TeclaArriba;
            ((System.ComponentModel.ISupportInitialize)Jugador).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label TxPuntos;
        private System.Windows.Forms.Timer ContadorJuego;
        private PictureBox Jugador;
        private Label label1;
    }
}