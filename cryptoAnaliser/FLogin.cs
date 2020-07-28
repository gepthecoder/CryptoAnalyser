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


namespace cyptoAnaliser
{
    public partial class FLogin : Form
    {
        public string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public static string _username = "";

        public FLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }



        private void FLogin_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void btn_Registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRegister n1 = new FRegister();
            n1.Show();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(txtUser.Text != "" || txtPass.Text != "")
            {
                SqlConnection dataConnection = new SqlConnection(_connectionString);
                dataConnection.Open(); //odpremo povezavo
                string poizvedba = "Select Count(*) from Users where username='" + txtUser.Text + "' and password='" + txtPass.Text + "'";
                using (SqlCommand dataCommand = new SqlCommand(poizvedba, dataConnection))
                {
                    if (System.Convert.ToInt32(dataCommand.ExecuteScalar()) == 1) //preverimo, če je bila poizvedba uspešna
                    {
                        _username = txtUser.Text;
                        this.Hide();//skrijemo prijavni obrazec
                        FMarket meni = new FMarket();  //nov objekt za glavni obrazec
                        meni.Show();

                    }
                    else
                    {
                        MessageBox.Show("Wrong password or username!!");
                        Ponastavi();
                    }
                }
            }
            else { MessageBox.Show("Please check your inputs!"); }
           
        }

        public void Ponastavi()
        {
            txtUser.Text = "Username";
            txtPass.Text = "Password";
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        private void txtUser_MouseEnter(object sender, EventArgs e)
        {
            lblUsername.Visible = true;
        }

        private void txtPass_MouseEnter(object sender, EventArgs e)
        {
            lblPassword.Visible = true;
        }
    }
}
 