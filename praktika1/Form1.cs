using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace praktika1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double Xcoor = 6371 * Math.Cos(40.45508056 * 3.14 / 180) * Math.Cos(50.06416667 * 3.14 / 180);
        public double Ycoor = 6371 * Math.Cos(40.45508056 * 3.14 / 180) * Math.Sin(50.06416667 * 3.14 / 180);
        void hidelabels()
        {
            var labels = Controls // or MyPanel.Controls etc. if labels are on panel
    .OfType<Label>()
    .Where(label => label.Name.StartsWith("label"));

            foreach (var label in labels)
                label.Visible = false;
        }

        void showlabels()
        {
            var labels = Controls // or MyPanel.Controls etc. if labels are on panel
    .OfType<Label>()
    .Where(label => label.Name.StartsWith("label"));

            foreach (var label in labels)
                label.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            hidelabels();
           
     
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            /* x1=x1+(x2-x1)*i/10;
             y1 = y1 + (y2 - y1) * i / 10;
             i++;
             pictureBox2.Location = new Point(x1,y1);
             */

            int a = pictureBox1.Location.X;
            int b = pictureBox1.Location.Y;
            int a1 = pictureBox2.Location.X;
            int b1 = pictureBox2.Location.Y;


            pictureBox1.Location = new Point(a + 3, b);

            

            
            pictureBox2.Location = new Point(a1 - 3, b1);

           

            if (a > 470)
            {
                System.IO.Stream str = Properties.Resources.takeoff;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Stop();
                timer1.Stop();
                timer2.Start();
                System.IO.Stream str1 = Properties.Resources.climb__cross;
                System.Media.SoundPlayer snd1 = new System.Media.SoundPlayer(str1);
                snd1.Play();
                
                
            }


            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int a1 = pictureBox2.Location.X;
            int b1 = pictureBox2.Location.Y;







            pictureBox2.Location = new Point(a1 - 3, b1);

         
            int ax = pictureBox1.Location.X;
            int bx = pictureBox1.Location.Y;


            pictureBox1.Location = new Point(ax + 3, bx - 2);

          if(ax > 540)
            {
                System.IO.Stream str1 = Properties.Resources.climb__cross;
                System.Media.SoundPlayer snd1 = new System.Media.SoundPlayer(str1);
                snd1.Stop();

                
                    System.IO.Stream str12 = Properties.Resources.Clear_of_conflict;
                    System.Media.SoundPlayer snd12 = new System.Media.SoundPlayer(str12);
                    snd12.Play();
                
                timer2.Stop();
                timer3.Start();
            }

          

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            /* System.IO.Stream str12 = Properties.Resources.descend;
            System.Media.SoundPlayer snd12 = new System.Media.SoundPlayer(str12);
            snd12.Play();
            */ 

            
           int a1 = pictureBox2.Location.X;
            int b1 = pictureBox2.Location.Y;

            int ax = pictureBox1.Location.X;
            int bx = pictureBox1.Location.Y;


          /*  if(ax > 590)
            {
                System.IO.Stream str12 = Properties.Resources.Clear_of_conflict;
                System.Media.SoundPlayer snd12 = new System.Media.SoundPlayer(str12);
                snd12.Stop();

              System.IO.Stream str123 = Properties.Resources.takeoff;
                System.Media.SoundPlayer snd123 = new System.Media.SoundPlayer(str123);
                snd123.Play();
                

            } */

            pictureBox2.Location = new Point(a1 - 3, b1);

            pictureBox1.Location = new Point(ax + 2 , bx);


         if ( a1 < 240)
            {
                pictureBox2.Visible = false;

            }
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;

            showlabels();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;
      
            hidelabels();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hidelabels();
       
       
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hidelabels();
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;

            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            System.IO.Stream str = Properties.Resources.takeoff;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();

            timer1.Start();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            double y = Convert.ToDouble(e.Location.Y) + Ycoor - 767 + pictureBox4.Width / 2;
            double x = Convert.ToDouble(e.Location.X) + Xcoor + pictureBox4.Height / 2;
            double coord = Math.Atan2(y, x);
            double coord2 = Math.Atan2(x, y);
            coord2 = coord2 * 180.0 / Math.PI;
            coord = coord * 180.0 / Math.PI;
            double minutes = (coord - Math.Floor(coord)) * 60.0;
            double seconds = (minutes - Math.Floor(minutes)) * 60.0;
            double minutes2 = (coord2 - Math.Floor(coord2)) * 60.0;
            double seconds2 = (minutes2 - Math.Floor(minutes2)) * 60.0;
            //int sec = (int)Math.Round(coord * 3600);
            //int deg = sec / 3600;
            //sec = Math.Abs(sec % 3600);
            //int min = sec / 60;
            //sec %= 60;
            //textBox1.Text =(Convert.ToDouble(pictureBox1.Location.X)+Xcoor).ToString()+" "+ (Convert.ToDouble(pictureBox1.Location.Y) + Ycoor-660).ToString();


            coorlabel.Text = "LATITUDE : " + Math.Round(coord, 0).ToString() + "°" + Math.Round(minutes, 0).ToString() + "''" + Math.Round(seconds, 0).ToString() + "'" + Environment.NewLine + "LONGTITUDE : " + Math.Round(coord2, 0).ToString() + "°" + Math.Round(minutes2, 0).ToString() + "''" + Math.Round(seconds2, 0).ToString() + "'";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
