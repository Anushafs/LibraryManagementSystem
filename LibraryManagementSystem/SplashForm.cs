using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            //MyProgress = new ProgressBar();
        }
        int startpoint = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
          startpoint += 1;


            //if (MyProgress != null)

                MyProgress1.Value = startpoint;

            if (MyProgress1.Value == 100)
           {
               MyProgress1.Value = 0;
               timer1.Stop();
               LoginForm log = new LoginForm();
                log.Show();
               this.Hide();
                }

}
private void SplashForm_Load(object sender, EventArgs e)
{
    timer1.Start();
}


private void label6_Click(object sender, EventArgs e)
{

}

private void label5_Click(object sender, EventArgs e)
{

}

private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
{

}
    }
}
