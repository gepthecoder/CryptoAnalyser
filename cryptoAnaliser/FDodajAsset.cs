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

namespace cyptoAnaliser
{
    public partial class FDodajAsset : Form
    {
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public FDodajAsset()
        {
            InitializeComponent();
            List<string> values = VrniImenaValut();
            comboCrypto.DataSource = values;
        }

        public List<string> VrniImenaValut()
        {
            List<string> valute = new List<string>();
            using (SqlConnection conne = new SqlConnection(_connectionString))
            {
                conne.Open();
                string sql = "Select * From Valute";
                using(SqlCommand cmd = new SqlCommand(sql,conne))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            valute.Add(reader.GetValue(3).ToString());
                        }
                    }
                }
            }
            return valute;

        }

        //metoda, ki preveri, če je količina večja od nič in vrne error provider če ni
        bool PreveriKolicino()
        {
            double kol = 0;
            try
            {
                kol = Convert.ToDouble(txtAmount.Text);
            }
            catch
            {
                errorProvider1.SetError(txtAmount, "Wrong amount input!");
                return false;
            }
            if (kol < 0)
            {
                errorProvider1.SetError(txtAmount, "Amount must be bigger than 0!!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtAmount, "");
                return true;
            }
        }
        //metoda, ki preveri, če je investicija večja od nič in vrne error provider če ni
        bool PreveriInvesticijo()
        {
            double inv = 0;
            try
            {
                inv = Convert.ToDouble(txtInvestment.Text);
            }
            catch
            {
                errorProvider1.SetError(txtInvestment, "Wrong investment input!");
                return false;
            }
            if (inv < 0)
            {
                errorProvider1.SetError(txtInvestment, "The investment must be bigger then 0!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtInvestment, "");
                return true;
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            PreveriKolicino();
        }

        private void txtInvestment_Validating(object sender, CancelEventArgs e)
        {
            PreveriInvesticijo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Shrani();

        }

        public void Shrani()
        {
            try
            {
                string sql = "Insert Into Portfolio (Valuta,Kolicina,Investicija,Datum) VALUES (@valuta,@kolicina,@investicija,@datum)";
                using (SqlConnection conne = new SqlConnection(_connectionString))
                {
                    
                    using(SqlCommand cmd = new SqlCommand(sql,conne))
                    {
                        cmd.Parameters.AddWithValue("@valuta", comboCrypto.Text);
                        cmd.Parameters.AddWithValue("@kolicina", double.Parse(txtAmount.Text));
                        cmd.Parameters.AddWithValue("@investicija", double.Parse(txtInvestment.Text));
                        cmd.Parameters.AddWithValue("@datum", Convert.ToDateTime(dateTimePicker1.Value));

                        conne.Open();
                        int result = cmd.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }

                }
            }
            catch (Exception) { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FConverter f1 = new FConverter();
            f1.Show();
        }
    }
}
