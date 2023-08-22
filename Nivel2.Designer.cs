namespace Space_War
{
    partial class Nivel2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Jugador1 = new PictureBox();
            TxPuntos1 = new Label();
            ContadorJuego1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Jugador1).BeginInit();
            SuspendLayout();
            // 
            // Jugador1
            // 
            Jugador1.Image = Properties.Resources.Green_Tunk1;
            Jugador1.Location = new Point(313, 485);
            Jugador1.Name = "Jugador1";
            Jugador1.Size = new Size(51, 62);
            Jugador1.SizeMode = PictureBoxSizeMode.CenterImage;
            Jugador1.TabIndex = 0;
            Jugador1.TabStop = false;
            // 
            // TxPuntos1
            // 
            TxPuntos1.AutoSize = true;
            TxPuntos1.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TxPuntos1.ForeColor = SystemColors.ControlLightLight;
            TxPuntos1.Location = new Point(12, 573);
            TxPuntos1.Name = "TxPuntos1";
            TxPuntos1.Size = new Size(74, 21);
            TxPuntos1.TabIndex = 1;
            TxPuntos1.Text = "Puntos: 0";
            // 
            // ContadorJuego1
            // 
            ContadorJuego1.Interval = 20;
            ContadorJuego1.Tick += ContadorMainJuego;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(696, 573);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 2;
            label1.Text = "Nivel 2";
            // 
            // Nivel2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(765, 603);
            Controls.Add(label1);
            Controls.Add(TxPuntos1);
            Controls.Add(Jugador1);
            Name = "Nivel2";
            Text = "Nivel2";
            KeyDown += TeclaAbajo1;
            KeyUp += TeclaArriba1;
            ((System.ComponentModel.ISupportInitialize)Jugador1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Jugador1;
        private Label TxPuntos1;
        private System.Windows.Forms.Timer ContadorJuego1;
        private Label label1;
    }
}