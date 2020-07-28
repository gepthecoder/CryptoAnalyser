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
    public partial class FConverter : Form
    {
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public FConverter()
        {
            InitializeComponent();

        }

        public double Evaluation(double amount, double price)
        {
            double constant = 0;

            constant = amount / price;

            return constant;
        }

        public double EvaluationUSD(double amount, double price)
        {
            double constant = 0;

            constant = amount * price;

            return constant;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox2To.SelectedItem.ToString() == "USD")
                {
                    txtTo.Text = EvaluationUSD(GetAmount(), GetPrice()).ToString();
                }
                else { txtTo.Text = Evaluation(GetAmount(), GetPrice()).ToString(); }
                

            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public double GetPrice()
        {
            string symbol = GetSymbol();

            string x;
            double price;
            using (SqlConnection conne = new SqlConnection(_connectionString))
            {
                conne.Open();
              
                string sql = "Select price_usd From Valute Where symbol=@Symbol";
                using (SqlCommand cmd = new SqlCommand(sql, conne))
                {
                    cmd.Parameters.AddWithValue("@Symbol", symbol);
                    string value = (string)cmd.ExecuteScalar();
                    x = value.Replace('.', ',');
                    price = Convert.ToDouble(x);                       
                }                    
                               
            }
            return price;

        }

        public double GetAmount()
        {
            double d;
            string niz = txtFrom.Text;

            d = double.Parse(niz);

            return d;
        }

        public string GetSymbol()
        {
            string symbol = "";

            if(comboBox2To.SelectedItem.ToString() == "USD")
            {
                symbol = comboBox1From.SelectedItem.ToString();
            }
            else { symbol = comboBox2To.SelectedItem.ToString(); }

            return symbol;
        }
    }
}
