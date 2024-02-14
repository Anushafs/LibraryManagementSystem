using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryManagementSystem
{
    public partial class LibrarianForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=FS-23-13\SQLEXPRESS;Initial Catalog=MyLibrarydb;Integrated Security=True");
        public LibrarianForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            conn.Open();
            string query = "Select * from LibrarianTbl";
            SqlDataAdapter da = new SqlDataAdapter(query,conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            LibrarianDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (LibId.Text == "" || LibName.Text == "" || LibPassword.Text == "" || Libphone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into LibrarianTbl Values("+LibId.Text+",'"+LibName.Text+"','"+LibPassword.Text+"','"+Libphone.Text+"')",conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Librarian Added Successfully");
                conn.Close();
                populate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (LibId.Text == "")
            {
                MessageBox.Show("Enter the Librarian Id");
            }
            else
            {
                conn.Open();
                string query = "delete from LibrarianTbl where LibId = " + LibId.Text + ";";
                SqlCommand cmd= new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Librarian Successfully deleted");
                conn.Close();
                populate();
            }
        }

        private void LibrarianDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LibId.Text = LibrarianDGV.SelectedRows[0].Cells[0].Value.ToString();
            LibName.Text = LibrarianDGV.SelectedRows[0].Cells[1].Value.ToString();
            LibPassword.Text = LibrarianDGV.SelectedRows[0].Cells[2].Value.ToString();
            Libphone.Text = LibrarianDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LibId.Text == "" || LibName.Text == "" || LibPassword.Text == "" || Libphone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                string query = "update LibrarianTbl set LibName='" + LibName.Text + "',LibPassword='" + LibPassword.Text + "',LibPhone='" + Libphone.Text + "' where LibId=" + LibId.Text + ";";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Librarian Updated Successfully");
                conn.Close();
                populate();
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
