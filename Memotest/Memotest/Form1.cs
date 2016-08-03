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
        PictureBox[] fondos;
        int counter;
        Tarjetas tarje = new Tarjetas();
        List<Tarjetas> listTarjetas = new List<Tarjetas>();
        int x,y, ParejaActual, primerI, s,j;
        int CantClick=0;
        Random random = new Random();
        List<int> listint = new List<int>();
        List<int> posRandom = new List<int>();
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
            s = 150;
            j = 150;
            timer1.Interval = 1000;
            timer1.Start();
            lblTiempo.Text = counter.ToString();
            lblTiempo.ForeColor = Color.Black;
            listTarjetas = tarje.Traemelos();
            pictures = new PictureBox[listTarjetas.Count()];
            fondos = new PictureBox[listTarjetas.Count()];
            for (int i2 = 0; i2 < listTarjetas.Count(); i2++)
            {
                fondos[i2] = new PictureBox();
                fondos[i2].Image = System.Drawing.Image.FromFile(Configuracion.RootFolder + "tarjAtras.jpg");
                fondos[i2].AutoSize = true;
            
                fondos[i2].BackColor = Color.Transparent;
                fondos[i2].Click += new EventHandler(fondos_Click);
                fondos[i2].Name = listTarjetas[i2].id.ToString();
                fondos[i2].BringToFront();
                //posRandom.Add(y);
             
               
                if (i2 >= 0 && i2 < 6)
                {
                    
                    fondos[i2].Location = new Point(s, 94);
                    s = fondos[i2].Right + 55;
                }
                if (i2 >= 6 && i2 < listTarjetas.Count())
                {

                   
                    fondos[i2].Location = new Point(j, 340);
                      j = fondos[i2].Right + 55;
                }
                this.Controls.Add(fondos[i2]);
            }
            for (int i = 0; i < listTarjetas.Count(); i++)
             {

                PictureBox estaPic = new PictureBox();
                estaPic.Image = System.Drawing.Image.FromFile(Configuracion.RootFolder + listTarjetas[i].foto);
                estaPic.AutoSize = true;
                estaPic.Click += new EventHandler(pictures_Click);
                estaPic.BackColor = Color.Transparent;
                estaPic.SendToBack();
                estaPic.Name = listTarjetas[i].id.ToString();
                posRandom.Add(x);
                if (i >= 0 && i < 6)
                 {

                    estaPic.Location = new Point(x, 94);
                    
                     x = estaPic.Right + 55;
                     
                 }
                 if (i >= 6 && i < listTarjetas.Count())
                 {
                    estaPic.Location = new Point(y, 340);
                     
                     y = estaPic.Right + 55;
                     
                }
                this.Controls.Add(estaPic);
                pictures[i]= estaPic;
            }
            /* 

                  for (int iDesorden = 0; iDesorden < listTarjetas.Count(); iDesorden++)
                  {
                      int randomNumber = random.Next(0, listTarjetas.Count());
                      while (listint.Contains(randomNumber))
                      {
                          randomNumber = random.Next(0, listTarjetas.Count());
                      }
                      listint.Add(randomNumber);
                      pictures[iDesorden].Location = new Point(posRandom[randomNumber], 165);
                      vector[iDesorden] = pala.palabra[randomNumber].ToString();
                      nueva = nueva + vector[iDesorden].ToString();
                      if (iDesorden == (pala.cantLetras - 1) && pala.palabra == nueva)
                      {
                          iDesorden = -1;
                          listint.Clear();
                          nueva = "";
                      }
                  }
 */


            
        }
        protected void pictures_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic =null;
            /*for (int i = 0; i < listTarjetas.Count(); i++)
            {
                if (pic != null && pic.Name == pictures[i].Name)
                {
                    if (CantClick == 0)
                    {
                        ParejaActual = listTarjetas[i].pareja;
                        CantClick = 1;
                        primerI = i;
                    }
                    else if (CantClick == 1)
                    {
                        if (ParejaActual == listTarjetas[i].pareja)
                        {
                            MessageBox.Show("hola");
                            CantClick = 0;
                            fondos[primerI].Visible = true;
                            fondos[i].Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("puto");
                            CantClick = 0;
                            fondos[primerI].Visible = true;
                            fondos[i].Visible = true;
                        }
                    }

                }
            }*/
        }

        PictureBox picAnterior;
        PictureBox img;
        PictureBox imgAnterior;
            protected void fondos_Click(object sender, EventArgs e)
            {
            var pic = sender as PictureBox;
            img = pictures.FirstOrDefault(p => p.Name==pic.Name);            
            for (int i = 0; i < listTarjetas.Count(); i++)
            {
                if (pic != null && pic.Name == fondos[i].Name)
                {
                    if (CantClick == 0)
                    {
                        ParejaActual = listTarjetas[i].pareja;
                        CantClick = 1;
                        primerI = i;
                        picAnterior = pic;
                        imgAnterior = img;
                        pic.Visible = false;

                    }
                    else if (CantClick == 1)
                    {
                        pic.Visible = false;
                        if (ParejaActual == listTarjetas[i].pareja)
                        {
                            CantClick = 0;
                            img.Visible=false;                            
                            imgAnterior.Visible=false;
                            Application.DoEvents();
                            //MessageBox.Show("Si");
                        }
                        else
                        {
                            //MessageBox.Show("No");
                            CantClick = 0;
                            pic.Visible = true;
                            picAnterior.Visible = true;                                                       
                        }
                    }

                }
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
