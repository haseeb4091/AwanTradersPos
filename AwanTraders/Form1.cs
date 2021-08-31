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
namespace AwanTraders
{
   
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount a = new CreateAccount();
            a.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from accounts where Email = @a and Password = @b";
            cmd.Parameters.AddWithValue("@a", Email.Text);
            cmd.Parameters.AddWithValue("@b", Password.Text);

            SqlDataAdapter a = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            a.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                mainpage m = new mainpage();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check your password and username");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = connection.c;
            con.Open();

        }
    }
}
