using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=FS-23-13\SQLEXPRESS;Initial Catalog=MyLibrarydb;Integrated Security=True");

        private void FillStudent()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select StdId from StudentTbl", conn);
            SqlDataReader rdr;
            rdr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StdId", typeof(int));
            dt.Load(rdr);
            StdCb.ValueMember = "StdId";
            StdCb.DataSource = dt;
            conn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            FillStudent();
        }
    }
}
