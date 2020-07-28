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
    public partial class FPortfolio : Form
    {
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public FPortfolio()
        {
            InitializeComponent();
        }

        private void dodajInvesticijoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDodajAsset f1 = new FDodajAsset();
            f1.Show();
        }

        private void FPortfolio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cryptocurrenciesDataSet1.Portfolio' table. You can move, or remove it, as needed.
            this.portfolioTableAdapter.Fill(this.cryptocurrenciesDataSet1.Portfolio);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                //pridobimo vse informacije, ki jih potrebujemo za izračun vrednosti in profita
                double cena = ValutaCena(row.Cells[2].Value.ToString());
                double enote = Convert.ToDouble(row.Cells[3].Value.ToString());
                double investicija = Convert.ToDouble(row.Cells[4].Value.ToString());
                //preračunamo vrednot, profit v$ in profit v %
                row.Cells[5].Value = Math.Round(cena * enote, 2) + " $"; //Vrednost
                row.Cells[6].Value = Math.Round(cena * enote - investicija, 2) + " $"; //profit v $
                row.Cells[7].Value = Math.Round((cena * enote - investicija) / investicija * 100, 2) + " %"; // profit v %

                //če je vrednost večja od nič jo pobarvamo zeleno
                if (cena * enote - investicija > 0)
                {
                    row.Cells[6].Style.ForeColor = Color.Green;
                    row.Cells[7].Style.ForeColor = Color.Green;
                }
                //če je vrednost manjša od nič jo pobarvamo rdeče
                else if (cena * enote - investicija < 0)
                {
                    row.Cells[6].Style.ForeColor = Color.Red;
                    row.Cells[7].Style.ForeColor = Color.Red;


                }
                //skrijemo stolpca id in uporabnik id
                dataGridView1.Columns[0].Visible = false;
                
            }

            DesignGridView();
        }
        //metoda, ki nam vrne trenutno vrednost posamezne valute
        public double ValutaCena(string valuta)
        {
            SqlConnection SQLPovezava = new SqlConnection(_connectionString);
            SQLPovezava.Open();

            using (SqlCommand SQLUkaz = new SqlCommand())
            {
                SQLUkaz.Connection = SQLPovezava;
                SQLUkaz.Parameters.AddWithValue("@ssymbol", valuta);
                SQLUkaz.CommandText = "SELECT price_usd FROM Valute WHERE symbol=@ssymbol";

                string cena = SQLUkaz.ExecuteScalar().ToString();
                string output = cena.Replace('.', ',');

                double price = Convert.ToDouble(output);
                return price;
                
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.dataGridView1.Refresh();
        }

        public void osvezi()
        {
            // TODO: This line of code loads data into the 'cryptocurrenciesDataSet1.Portfolio' table. You can move, or remove it, as needed.
            this.portfolioTableAdapter.Fill(this.cryptocurrenciesDataSet1.Portfolio);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                //pridobimo vse informacije, ki jih potrebujemo za izračun vrednosti in profita
                double cena = ValutaCena(row.Cells[2].Value.ToString());
                double enote = Convert.ToDouble(row.Cells[3].Value.ToString());
                double investicija = Convert.ToDouble(row.Cells[4].Value.ToString());
                //preračunamo vrednot, profit v$ in profit v %
                row.Cells[5].Value = Math.Round(cena * enote, 2) + " $"; //Vrednost
                row.Cells[6].Value = Math.Round(cena * enote - investicija, 2) + " $"; //profit v $
                row.Cells[7].Value = Math.Round((cena * enote - investicija) / investicija * 100, 2) + " %"; // profit v %

                //če je vrednost večja od nič jo pobarvamo zeleno
                if (cena * enote - investicija > 0)
                {
                    row.Cells[6].Style.ForeColor = Color.Green;
                    row.Cells[7].Style.ForeColor = Color.Green;
                }
                //če je vrednost manjša od nič jo pobarvamo rdeče
                else if (cena * enote - investicija < 0)
                {
                    row.Cells[6].Style.ForeColor = Color.Red;
                    row.Cells[7].Style.ForeColor = Color.Red;


                }
                //skrijemo stolpca id in uporabnik id
                dataGridView1.Columns[0].Visible = false;

            }
        }

        public void DesignGridView()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void zapriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


        
}
