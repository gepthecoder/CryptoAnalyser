using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace cyptoAnaliser
{
    public partial class FMeni : Form
    {
        public string _connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public FMeni()
        {
            InitializeComponent();
            PopulateGrid();
            NastaviFalse();

            checkBox.FalseValue = false;
            checkBox.TrueValue = true;
        }

        private async void button1_Click(object sender, EventArgs e) //coinmarket
        {
            // start the waiting animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // simply start and await the loading task
            button1.Enabled = false;
            await Task.Run(() => LoadExcel());

            FMarket f1 = new FMarket();
            f1.Show();
            // re-enable things
            button1.Enabled = true;
            progressBar1.Visible = false;
        }
        private void LoadExcel()
        {
            // some work takes 5 sec
            Thread.Sleep(5000);
        }

        private void button2_Click(object sender, EventArgs e) //portfolio
        {
            // start the waiting animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // simply start and await the loading task
            button2.Enabled = false;
            FPortfolio f1 = new FPortfolio();
            f1.Show();

            // re-enable things
            button1.Enabled = true;
            progressBar1.Visible = false;
        }

        private void btnLEFT_Click(object sender, EventArgs e)
        {
            if (panelRight.Visible == true)
                panelRight.Visible = false;
            panelLeft.Visible = true;
        }

        private void FMeni_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cryptocurrenciesDataSet2.Valute' table. You can move, or remove it, as needed.
            this.valuteTableAdapter.Fill(this.cryptocurrenciesDataSet2.Valute);
            panelLeft.Visible = false;
            panelRight.Visible = false;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (panelLeft.Visible == true)
                panelLeft.Visible = false;
            panelRight.Visible = true;
        }

        public void StartAnimation()
        {
            for(int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 101; i++)
                {
                    Thread.Sleep(10);
                    circularProgressBar1.Value = i;
                    circularProgressBar1.Update();
                }
                circularProgressBar1.Value = 0;
            }           
        }
        private void btnRUN_Click(object sender, EventArgs e)
        {
            StartAnimation();
            //loop(8);
        }

        public void loop(int i)
        {
            for(int m = 0; m < i; m++)
            {
                txtResult.Text += cmdResult();
            }
        }

        public string cmdResult()
        {
            string result = "";
            string query = txtcmd.Text;

            using(SqlConnection conne = new SqlConnection(_connection))
            {
                using(SqlCommand cmd = new SqlCommand(query, conne))
                {
                    conne.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for(int i = 0; i < 4; i++)
                            {
                                result += reader[i];
                            }
                            
                        }
                    }
                }
            }
            return result;
        }

        public void PopulateGrid()
        {
            SqlConnection conne = new SqlConnection(_connection);
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Valute", conne);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        

        public void NastaviFalse()
        {
            for (int i = 0; i <= dataGridView1.Rows.Count-1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = false;
            }
        }

        public void Odklukaj()
        {
            if (dataGridView1.SelectedRows[0].Cells[0].Value == checkBox.TrueValue)
                    dataGridView1.SelectedRows[0].Cells[0].Value = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            dataGridView1.SelectedRows[0].Cells[0].Value = true;
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0].Cells[0].Value = false;
        }
    }
}
