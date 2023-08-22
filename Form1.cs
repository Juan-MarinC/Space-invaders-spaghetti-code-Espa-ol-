using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Space_War
{
    public partial class Form1 : Form
    {
        //Creacion de las varialbes que seran utilizadas con las Picturebox (Naves enemigas, Jugador, Puntuacion y Disparos)
        bool Irderecha, Irizquierda;
        int VelocidadJugador = 12;
        int VelocidadEnemigo = 5;
        int Puntos = 0;
        int TiempoDisEnemigo = 300;

        PictureBox[] NavesInvasorasArray; // creacion de Array que ocuparemos mas abajo para insertar las naves enemigas

        bool Disparar;
        bool GameOver;





        public Form1()
        {
            InitializeComponent();
            gameSetup();// una vez se inicie este "form"
        }

        private void EventoContadorJuego(object sender, EventArgs e) // creacion del ciclo de disparo tanto de los enemigos como el del jugador principal
        {

            TxPuntos.Text = "Puntuacion:" + Puntos;

            if (Irizquierda)
            {
                Jugador.Left -= VelocidadJugador;
            }

            if (Irderecha)
            {
                Jugador.Left += VelocidadEnemigo;
            }


            TiempoDisEnemigo -= 10; // se establece el tiempo en el cual los disparos de las naves enemigos saldran de la parte superior

            if (TiempoDisEnemigo < 1)
            {
                TiempoDisEnemigo = 300;
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

                    if (x.Bounds.IntersectsWith(Jugador.Bounds)) // si nuestro cañon es tocado por las naves se mostrara este mensaje
                    {
                        gameOver("Has sido invadido");
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

                    if (x.Bounds.IntersectsWith(Jugador.Bounds))
                    {
                        this.Controls.Remove(x);
                        gameOver("Has sido asesinado por los disparos de los invasores.");
                    }
                }


            }

            if (Puntos > 14) //Si los puntos son iguales a 14 la velocidad de los enemigos aumenta
            {
                VelocidadEnemigo = 12;
            }

            if (Puntos == NavesInvasorasArray.Length)
            {
                gameOver("Has abatido todas las naves, !Felicitaciones¡");
            }

            if (Puntos == NavesInvasorasArray.Length)
            {
                // Realizar acciones necesarias antes de pasar al siguiente nivel

                Nivel2 nivel2Form = new Nivel2(); // Crear una instancia del formulario Nivel2
                nivel2Form.Show(); // Mostrar el formulario Nivel2

                this.Hide(); // Ocultar el formulario actual (Nivel1)
            }

        }



        private void TeclaAbajo(object sender, KeyEventArgs e) //Este ciclo sirve para una vez pulsado la tecla de izquierda y derecha nuestro cañon se diriga hacia el lugar de la tecla presionada
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

        private void TeclaArriba(object sender, KeyEventArgs e)//Asigancion de ciclo para que al presionar el espacio nuestro cañon dispare
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
            if (e.KeyCode == Keys.Enter && GameOver == true)//Asignacion de la tecla enter para reiniciar el juego y volver a empezar de 0
            {
                removeAll();
                gameSetup();
            }
        }

        private void NavesInvasoras()
        {
            NavesInvasorasArray = new PictureBox[21]; // Asigancion del lugar de reaparicion de las naves invasoras por medio del Array previamente creado
            int izquierda = 0;
            for (int i = 0; i < NavesInvasorasArray.Length; i++)
            {
                NavesInvasorasArray[i] = new PictureBox();
                NavesInvasorasArray[i].Size = new Size(50, 40);
                NavesInvasorasArray[i].Image = Properties.Resources.invader1;
                NavesInvasorasArray[i].Top = 5;
                NavesInvasorasArray[i].Tag = "invasores";
                NavesInvasorasArray[i].Left = izquierda;
                NavesInvasorasArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(NavesInvasorasArray[i]);
                izquierda = izquierda - 80;


            }
        }






        private void gameSetup() //Metodo que una vez invocado se inicie el juego y reaparezcan las naves 
        {
            TxPuntos.Text = "Puntuacion: 0 ";
            Puntos = 0;
            GameOver = false;

            TiempoDisEnemigo = 300;
            VelocidadEnemigo = 5;
            Disparar = false;

            NavesInvasoras();
            ContadorJuego.Start();

        }
        private void gameOver(string mensaje) // si nuestro cañon es abatido este metodo sera inicializado y nos dejara un mensaje junto a nuestra puntuacion final
        {
            GameOver = true;
            ContadorJuego.Stop();
            TxPuntos.Text = "Puntuacion: " + Puntos + " " + mensaje;
        }
        private void removeAll() //Para remover todo una vez es puesto en marcha de nuevo
        {
            foreach (PictureBox i in NavesInvasorasArray)
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
            bullet.Left = Jugador.Left + Jugador.Width / 2;


            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = Jugador.Top - 20;
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