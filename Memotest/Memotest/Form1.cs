using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memotest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            //MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            //this.BackgroundImage = System.Drawing.Image.FromFile(Configuracion.RootFolder + "IMGS/FondoArmando2.jpg");
           // this.Location = new Point(100, 100);
        }
        PictureBox[] pictures;
        int counter;
        Tarjetas tarje = new Tarjetas();
        List<Tarjetas> listTarjetas = new List<Tarjetas>();
        int x,y;
        Random random = new Random();
        List<int> listint = new List<int>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        //1382x744
        private void Inicio()
        {
            counter = 60;
            x = 150;
            y = 150;
            timer1.Interval = 1000;
            timer1.Start();
            lblTiempo.Text = counter.ToString();
            lblTiempo.ForeColor = Color.Black;
            listTarjetas = tarje.Traemelos();
            pictures = new PictureBox[listTarjetas.Count()];

            for (int i = 0; i < listTarjetas.Count(); i++)
            {
                if (i>= 0 &&i<5)
                {
                    pictures[i] = new PictureBox();
                    pictures[i].Image = System.Drawing.Image.FromFile(Configuracion.RootFolder + listTarjetas[i].foto);
                    pictures[i].AutoSize = true;
                    pictures[i].BackColor = Color.Transparent;
                    pictures[i].Location = new Point(x, 94);
                    x = pictures[i].Right + 20;

                    this.Controls.Add(pictures[i]);
                }
                if (i >= 5 && i < listTarjetas.Count())
                {
                    
                    pictures[i] = new PictureBox();
                    pictures[i].Image = System.Drawing.Image.FromFile(Configuracion.RootFolder + listTarjetas[i].foto);
                    pictures[i].AutoSize = true;
                    pictures[i].BackColor = Color.Transparent;
                    pictures[i].Location = new Point(y, 340);
                    y = pictures[i].Right+20;
                    this.Controls.Add(pictures[i]);

                }
                // guiones[i].Name = i + splitSilaba[i].ToString();


            }
            /* pictures[0] = pic0;
             pictures[1] = pic1;
             pictures[2] = pic2;
             pictures[3] = pic3;
             pictures[4] = pic4;
             pictures[5] = pic5;
             pictures[6] = pic6;
             pictures[7] = pic7;
             pictures[8] = pic8;
             pictures[9] = pic9;

             for (int iDesorden = 0; iDesorden < listTarjetas.Count(); iDesorden++)
             {
                 int randomNumber = random.Next(0, listTarjetas.Count());
                 while (listint.Contains(randomNumber))
                 {
                     randomNumber = random.Next(0, listTarjetas.Count());
                 }
                 listint.Add(randomNumber);
                 labels[iDesorden].Location = new Point(posRandom[randomNumber], 165);
                 vector[iDesorden] = pala.palabra[randomNumber].ToString();
                 nueva = nueva + vector[iDesorden].ToString();
                 if (iDesorden == (pala.cantLetras - 1) && pala.palabra == nueva)
                 {
                     iDesorden = -1;
                     listint.Clear();
                     nueva = "";
                 }
             }*/



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                CustomMessageForm mimsg = new CustomMessageForm("Perdiste");
                DialogResult result = mimsg.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Inicio();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            if (counter == 15)
                lblTiempo.ForeColor = Color.Red;
            lblTiempo.Text = counter.ToString();
        }
    }
}
