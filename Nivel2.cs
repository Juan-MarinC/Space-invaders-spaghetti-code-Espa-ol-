using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public partial class Nivel2 : Form
    {

        //Creacion de las varialbes que seran utilizadas con las Picturebox (Naves enemigas, Jugador, Puntuacion y Disparos)
        bool Irderecha, Irizquierda;
        int VelocidadJugador = 14;
        int VelocidadEnemigo = 6;
        int Puntos = 0;
        int TiempoDisEnemigo = 350;

        PictureBox[] NavesInvasorasArray1; // creacion de Array que ocuparemos mas abajo para insertar las naves enemigas

        bool Disparar;
        bool GameOver1;




        public Nivel2()
        {
            InitializeComponent();
            gameSetup1();
        }

        private void ContadorMainJuego(object sender, EventArgs e)
        {
            TxPuntos1.Text = "Puntuacion:" + Puntos;

            if (Irizquierda)
            {
                Jugador1.Left -= VelocidadJugador;
            }

            if (Irderecha)
            {
                Jugador1.Left += VelocidadEnemigo;
            }


            TiempoDisEnemigo -= 10; // se establece el tiempo en el cual los disparos de las naves enemigos saldran de la parte superior

            if (TiempoDisEnemigo < 1)
            {
                TiempoDisEnemigo = 350;
                makeBullet("bulletE");

            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "invasores")
                {
                    x.Left += VelocidadEnemigo;

                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(Jugador1.Bounds)) // si nuestro cañon es tocado por las naves se mostrara este mensaje
                    {
                        gameOver1("Has sido invadido");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                Puntos += 1;
                                Disparar = false;
                            }
                        }

                    }
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;
                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        Disparar = false;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "bulletE")// Si nuestro cañon es alcanzado por los disparos enemigos se mostrara este mensaje
                {
                    x.Top += 20;

                    if (x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(Jugador1.Bounds))
                    {
                        this.Controls.Remove(x);
                        gameOver1("Has sido asesinado por los disparos de los invasores.");
                    }
                }


            }

            if (Puntos > 14) //Si los puntos son iguales a 14 la velocidad de los enemigos aumenta
            {
                VelocidadEnemigo = 12;
            }

            if (Puntos == NavesInvasorasArray1.Length)
            {
                gameOver1("Has abatido todas las naves, !Felicitaciones¡");
            }


        }

        private void TeclaAbajo1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Irizquierda = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                Irderecha = true;
            }

        }

        private void TeclaArriba1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Irizquierda = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Irderecha = false;
            }
            if (e.KeyCode == Keys.Space && Disparar == false)//Asignacion de la tecla espacio
            {
                Disparar = true;
                makeBullet("bullet");
            }
            if (e.KeyCode == Keys.Enter && GameOver1 == true)//Asignacion de la tecla enter para reiniciar el juego y volver a empezar de 0
            {
                removeAll1();
                gameSetup1();
            }
        }


        private void NavesInvasoras()
        {
            NavesInvasorasArray1 = new PictureBox[28]; // Asigancion del lugar de reaparicion de las naves invasoras por medio del Array previamente creado
            int izquierda = 0;
            for (int i = 0; i < NavesInvasorasArray1.Length; i++)
            {
                NavesInvasorasArray1[i] = new PictureBox();
                NavesInvasorasArray1[i].Size = new Size(50, 40);
                NavesInvasorasArray1[i].Image = Properties.Resources.invader3;
                NavesInvasorasArray1[i].Top = 5;
                NavesInvasorasArray1[i].Tag = "invasores";
                NavesInvasorasArray1[i].Left = izquierda;
                NavesInvasorasArray1[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(NavesInvasorasArray1[i]);
                izquierda = izquierda - 80;


            }
        }


        private void gameSetup1() //Metodo que una vez invocado se inicie el juego y reaparezcan las naves 
        {
            TxPuntos1.Text = "Puntuacion: 0 ";
            Puntos = 0;
            GameOver1 = false;

            TiempoDisEnemigo = 300;
            VelocidadEnemigo = 5;
            Disparar = false;

            NavesInvasoras();
            ContadorJuego1.Start();

        }
        private void gameOver1(string mensaje) // si nuestro cañon es abatido este metodo sera inicializado y nos dejara un mensaje junto a nuestra puntuacion final
        {
            GameOver1 = true;
            ContadorJuego1.Stop();
            TxPuntos1.Text = "Puntuacion: " + Puntos + " " + mensaje;
        }
        private void removeAll1() //Para remover todo una vez es puesto en marcha de nuevo
        {
            foreach (PictureBox i in NavesInvasorasArray1)
            {
                this.Controls.Remove(i);

            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "bulletE")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }



        private void makeBullet(string bulletTag) // creacion de los disparos por medio de la extraccion del picturebox "bullet" el cual le asignaremos los siguientes valores
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 25);
            bullet.Tag = bulletTag;
            bullet.Left = Jugador1.Left + Jugador1.Width / 2;


            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = Jugador1.Top - 20;
            }

            else if ((string)bullet.Tag == "bulletE")
            {
                bullet.Top = -100;

            }

            this.Controls.Add(bullet);
            bullet.BringToFront();




        }

    }

}














