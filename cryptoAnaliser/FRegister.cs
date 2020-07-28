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
using System.IO;

namespace cyptoAnaliser
{
    public partial class FRegister : Form
    {
        public string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public static string naslovSlike = "";


        public FRegister()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                //spremenljivka ki nam pove, če je uporabnik vsa polja izpolnil
                bool vsaPolja = true;

                if (txt_name.Text == "" || txt_lastname.Text == "" || txt_email.Text == "" || txt_username.Text == "" || txt_password1.Text == "" || txt_password2.Text == "" || checkBox1.Checked == false)
                {
                    MessageBox.Show("Make sure that you have fulfilled all the needed information!");
                    DialogResult = DialogResult.Retry;
                    vsaPolja = false;
                }
                else if (vsaPolja == true)
                {
                    PreveriValidnostUsername();
                    PreveriValidnostGesel();
                    SaveUserToDatabase();
                    MessageBox.Show("Thanks for your registration " + txt_name.Text + " " + txt_lastname.Text + "\nNow You can continue with login.");
                    MessageBox.Show("Please write down your generated Token:  " + GenerateToken(txt_username.Text) + " \nIf you want to reset your password you will need your token value!");
                    this.Close();
                    FLogin f1 = new FLogin();
                    f1.Show();
                    
                    
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        public void PreveriValidnostGesel()
        {
            if(txt_password1.Text != txt_password2.Text)
            {
                MessageBox.Show("Your password doesn't match! Please check again!");
                txt_password1.Text = "";
                txt_password2.Text = "";
            }
            else { }
        }

        public void PreveriValidnostUsername()
        {
            SqlConnection povezava = new SqlConnection(_connectionString);
            povezava.Open();
            bool obstaja = false;
            //če uporabnik obstaja vrnemo obstaja = true
            using (SqlCommand sql = new SqlCommand())
            {
                sql.Connection = povezava;
                sql.Parameters.Add(new SqlParameter("@upIme", txt_username.Text));
                sql.CommandText = "Select Count(*) from Users where username=@upIme";
                if (System.Convert.ToInt32(sql.ExecuteScalar()) == 1) //preverimo ali uporabnik s tem imenom že obstaja
                    obstaja = true;
            }
            //Če uporabnik že obstaja to povemo uporabniku, in dialogResult nastavimo na Retry
            if (obstaja)
            {
                MessageBox.Show("User with this username already exist, please choose a new one!");
                DialogResult = DialogResult.Retry;
                txt_username.Clear();
                txt_password1.Clear();
                txt_password2.Clear();
            }
        }

        public void SetUpUser()
        {
            login trenutni = new login();
            trenutni.Name = txt_name.Text;
            trenutni.Lastname = txt_lastname.Text;
            trenutni.Email = txt_email.Text;
            trenutni.Username = txt_username.Text;
            trenutni.Password = txt_password1.Text;

        }

        public void SaveUserToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                byte[] slika = null;
                FileStream fs = new FileStream(naslovSlike, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                slika = br.ReadBytes((int)fs.Length); //branje binarnih podatkob iz file streama, kjer se nahaja kompleksen niz
                String query = "INSERT INTO Users (username,password,email,firstname,lastname,token,image) VALUES (@user,@pass,@mail,@firstn,@lastn,@tokeen,@img)";

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        command.Parameters.AddWithValue("@user", txt_username.Text);
                        command.Parameters.AddWithValue("@pass", txt_password1.Text);
                        command.Parameters.AddWithValue("@mail", txt_email.Text);
                        command.Parameters.AddWithValue("@firstn", txt_name.Text);
                        command.Parameters.AddWithValue("@lastn", txt_lastname.Text);
                        command.Parameters.AddWithValue("@tokeen", GenerateToken(txt_username.Text));
                        command.Parameters.Add(new SqlParameter("@img", slika));
                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("We found a problem with saving data to sql database!");
                    }
                }
                catch (Exception x) { MessageBox.Show(x.Message); }

            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open profile photo.";
                dlg.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    naslovSlike = dlg.FileName.ToString();
                    pictureBox3.ImageLocation = naslovSlike;
                    pictureBox3.Image = new Bitmap(dlg.FileName);
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txt_password1.UseSystemPasswordChar = false;
            txt_password2.UseSystemPasswordChar = false;
        }

        public string GenerateToken(string username)
        {
            string token = "";

            token = SHA.Hash(username);

            return token;
            
        }
    }
}
