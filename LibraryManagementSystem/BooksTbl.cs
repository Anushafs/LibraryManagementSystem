using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BooksTbl : Form
    {
        public BooksTbl()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=FS-23-13\SQLEXPRESS;Initial Catalog=MyLibrarydb;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BooksTbl_Load(object sender, EventArgs e)
        {

        }
        public void populate()
        {
            conn.Open();
            string query = "Select * from BookTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            BooksDGV.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BookName.Text == "" || Author.Text == "" || Publisher.Text == "" || Price.Text == "" || Quantity.Text == "" || BookId.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                string query = "update BookTbl set BookName='" + BookName.Text + "',Author='" + Author.Text + "',Publisher='" + Publisher.Text + "', Price='"+Price.Text+ "',Quantity='"+Quantity.Text+"' where BookNum=" + BookId.Text + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Updated Successfully");
                conn.Close();
                populate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BookName.Text == "" || Author.Text == "" || Publisher.Text == "" || Price.Text == "" || Quantity.Text=="" || BookId.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into BookTbl Values(" + BookId.Text + ",'"+BookName.Text+"','" + Author.Text + "','" + Publisher.Text + "'," + Price.Text + "," + Quantity.Text + ")", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Books Added Successfully");
                conn.Close();
                populate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BookId.Text == "")
            {
                MessageBox.Show("Enter the BookId");
            }
            else
            {
                conn.Open();
                string query = "delete from BookTbl where BookNum = " + BookId.Text + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Successfully deleted");
                conn.Close();
                populate();
            }
        }

        private void BooksDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookId.Text = BooksDGV.SelectedRows[0].Cells[0].Value.ToString();
            BookName.Text = BooksDGV.SelectedRows[0].Cells[1].Value.ToString();
            Author.Text = BooksDGV.SelectedRows[0].Cells[2].Value.ToString();
            Publisher.Text = BooksDGV.SelectedRows[0].Cells[3].Value.ToString();
            Price.Text = BooksDGV.SelectedRows[0].Cells[4].Value.ToString();
            Quantity.Text = BooksDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
