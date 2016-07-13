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
            MaximizeBox = false;
            //this.BackgroundImage = System.Drawing.Image.FromFile(Configuracion.RootFolder + "IMGS/FondoArmando2.jpg");
            this.Location = new Point(100, 100);
        }
        PictureBox[] pictures;
        int counter;
        Tarjetas tarje = new Tarjetas();
        List<Tarjetas> listTarjetas = new List<Tarjetas>();
        int x;
        private void Form1_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void Inicio()
        {
            counter = 60;
            x = 250;
            timer1.Interval = 1000;
            timer1.Start();
            lblTiempo.Text = counter.ToString();
            lblTiempo.ForeColor = Color.Black;
            listTarjetas = tarje.Traemelos();
            pictures = new PictureBox[listTarjetas.Count()];
            for (int i = 0; i < listTarjetas.Count(); i++)
            {
                pictures[i] = new PictureBox();
                pictures[i].Image = System.Drawing.Image.FromFile(Configuracion.RootFolder + listTarjetas[i].foto);
                pictures[i].AutoSize = true;
                pictures[i].BackColor = Color.Transparent;
                pictures[i].Location = new Point(x, 341);
                x = x + 80;
                this.Controls.Add(pictures[i]);
                

               // guiones[i].Name = i + splitSilaba[i].ToString();
                
                
            }
            
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
