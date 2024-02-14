using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=FS-23-13\SQLEXPRESS;Initial Catalog=MyLibrarydb;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
            
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            conn.Open();
            string query = "Select * from StudentTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "" || StdName.Text == "" || StdDep.Text == "" || StdSem.Text =="" || StdPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentTbl Values(" + StdId.Text + ",'" + StdName.Text + "','" + StdDep.Text + "','" + StdSem.Text + "','" + StdPhone.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added Successfully");
                conn.Close();
                populate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "" || StdName.Text == "" || StdDep.Text == "" || StdSem.Text == "" || StdPhone.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                string query = "update StudentTbl set StdName='" + StdName.Text + "',StdDep='" + StdDep.Text + "',StdPhone='" + StdPhone.Text + "' where StdId=" + StdId.Text + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Updated Successfully");
                conn.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StdId.Text == "")
            {
                MessageBox.Show("Enter the Student Id");
            }
            else
            {
                conn.Open();
                string query = "delete from StudentTbl where StdId = " + StdId.Text + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Successfully deleted");
                conn.Close();
                populate();
            }
        }
    }
}
