using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace cyptoAnaliser
{
    public partial class FMarket : Form
    {
        BindingList<coin> Currencies = new BindingList<coin>();
        BindingList<coin> favoritesList = new BindingList<coin>();
        public string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";
        public bool izvaja = false;
        public FMarket()
        {
            InitializeComponent();

            CheckBox1.FalseValue = false;
            CheckBox1.TrueValue = true;

        }

        public static BindingList<T> CeneDownload<T>() where T : new()
        {
            using (var w = new WebClient())
            {
                string url = "https://api.coinmarketcap.com/v1/ticker/?limit=0";
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<BindingList<T>>(json_data) : new BindingList<T>();
            }
        }

        public void FunctionsForMarketCap()
        {
            IzbrisiVseValute();
            Currencies.Clear();

            Currencies = CeneDownload<coin>();
            UpdateTabelaValute();            
            ValuteDataGridView.DataSource = Currencies;
            OblikujCene();
            DesignGrid();
            NastaviFalse();

        }

        public void FunctionsForFavorites()
        {            
            DesignGridFavorite();
            OblikujCeneFavorite();
        }

        public void PrikaziFavorite()
        {
            SqlConnection conne = new SqlConnection(_connectionString);
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Favorites", conne);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            gridFavorite.DataSource = dt;

        }
       
        public void SetFalseValueToCheckBoxes(DataTable dt)
        {
            foreach(DataRow item in dt.Rows)
            {
                int n = ValuteDataGridView.Rows.Add();
                ValuteDataGridView.Rows[n].Cells[0].Value = false;
            }

        }

        private void FMarket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cryptocurrenciesDataSet3.Favorites' table. You can move, or remove it, as needed.
            PrikaziFavorite();
            FunctionsForFavorites();
            FunctionsForMarketCap();
            ShowPricesOnDashboard();
            ShowPercentChange();          
                                 
        }




        public void UpdateTabelaValute()
        {
            try
            {
                SqlConnection conne = new SqlConnection(_connectionString);
                conne.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conne;
                    for (int i = 0; i < Currencies.Count; i++)
                    {
                        coin novi = Currencies[i];
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@val", novi.id ?? DBNull.Value.ToString()); //vrne levi segment v kolikor ni prazen drugače desnega ??
                        cmd.Parameters.AddWithValue("@name", novi.name ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@symbol", novi.symbol ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@rank", novi.rank ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@price_usd", novi.price_usd ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@price_btc", novi.price_btc ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@_24h_volume_usd", novi._24h_volume_usd ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@market_cap_usd", novi.market_cap_usd ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@available_supply", novi.available_supply ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@total_supply", novi.total_supply ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@max_supply", novi.max_supply ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_1h", novi.percent_change_1h ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_24h", novi.percent_change_24h ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_7d", novi.percent_change_7d ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@last_updated", novi.last_updated ?? DBNull.Value.ToString());

                        cmd.CommandText = "INSERT INTO Valute VALUES (@val,@name,@symbol,@rank,@price_usd,@price_btc,@_24h_volume_usd,@market_cap_usd,@available_supply,@total_supply,@max_supply,@percent_change_1h,@percent_change_24h,@percent_change_7d,@last_updated)";
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception) { }

        }

        

        public void ShowSelectedCoins()
        {
            SqlConnection conne = new SqlConnection(_connectionString);
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Favorites", conne);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            gridFavorite.DataSource = dt;

        }

        public void IzbrisiVseValute()
        {
            SqlConnection SQLPovezava = new SqlConnection(_connectionString);
            SQLPovezava.Open();

            using (SqlCommand SQLUkaz = new SqlCommand())
            {
                SQLUkaz.Connection = SQLPovezava;
                SQLUkaz.CommandText = "DELETE FROM Valute";
            }
            SQLPovezava.Close();
        }

        public void OblikujCene()
        {
            ValuteDataGridView.Columns[1].Visible = false;
            ValuteDataGridView.Columns[0].Visible = false;
            ValuteDataGridView.Columns[6].Visible = false;
            ValuteDataGridView.Columns[7].Visible = false;
            ValuteDataGridView.Columns[10].Visible = false;
            ValuteDataGridView.Columns[15].Visible = false;
            ValuteDataGridView.Columns[4].DisplayIndex = 1 ;
            ValuteDataGridView.Columns[4].HeaderText = "#";
            ValuteDataGridView.Columns[4].Width = 55;
            ValuteDataGridView.Columns[12].Width = 70;
            ValuteDataGridView.Columns[13].Width = 70;
            ValuteDataGridView.Columns[14].Width = 70;
            ValuteDataGridView.Columns[2].Width = 175;
            ValuteDataGridView.Columns[3].Width = 80;
            ValuteDataGridView.Columns[11].Width = 125;
            ValuteDataGridView.Columns[9].Width = 125;
            ValuteDataGridView.Columns[8].Width = 125;
            ValuteDataGridView.Columns[12].DisplayIndex = 8;
            ValuteDataGridView.Columns[12].HeaderText = "% 1h";
            ValuteDataGridView.Columns[13].DisplayIndex = 9;
            ValuteDataGridView.Columns[13].HeaderText = "% 24h";
            ValuteDataGridView.Columns[14].DisplayIndex = 10;
            ValuteDataGridView.Columns[14].HeaderText = "% 7d";
            ValuteDataGridView.Columns[16].DisplayIndex = 0;
            


            foreach (DataGridViewRow Myrow in ValuteDataGridView.Rows)
            {
                try
                {
                    double ch1h = Convert.ToDouble(Myrow.Cells[12].Value.ToString());
                    double ch1d = Convert.ToDouble(Myrow.Cells[13].Value.ToString());
                    double ch7d = Convert.ToDouble(Myrow.Cells[14].Value.ToString());
                    if (ch1h < 0)
                    {
                        Myrow.Cells[12].Style.ForeColor = Color.Red;
                    }
                    else if (ch1h > 0)
                    {
                        Myrow.Cells[12].Style.ForeColor = Color.Green;
                    }
                    if (ch1d < 0)
                    {
                        Myrow.Cells[13].Style.ForeColor = Color.Red;
                    }
                    else if (ch1d > 0)
                    {
                        Myrow.Cells[13].Style.ForeColor = Color.Green;
                    }
                    if (ch7d < 0)
                    {
                        Myrow.Cells[14].Style.ForeColor = Color.Red;
                    }
                    else if (ch7d > 0)
                    {
                        Myrow.Cells[14].Style.ForeColor = Color.Green;
                    }
                }
                catch { continue; }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (panelCoinMarketCap.Visible == true)
            {
                panelCoinMarketCap.Visible = false;
            }
            panelDASHBOARD.Visible = true;
        }

        BindingList<coin> searchResult = new BindingList<coin>();

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        public void DesignGrid()
        {

            ValuteDataGridView.BorderStyle = BorderStyle.None;
            ValuteDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            ValuteDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ValuteDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            ValuteDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ValuteDataGridView.BackgroundColor = Color.White;

            ValuteDataGridView.EnableHeadersVisualStyles = false;
            ValuteDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ValuteDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(19, 54, 58);
            ValuteDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public void DesignGridFavorite()
        {

            gridFavorite.BorderStyle = BorderStyle.None;
            gridFavorite.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            gridFavorite.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridFavorite.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            gridFavorite.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            gridFavorite.BackgroundColor = Color.White;

            gridFavorite.EnableHeadersVisualStyles = false;
            gridFavorite.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridFavorite.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(19, 54, 58);
            gridFavorite.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void button1_Click_1(object sender, EventArgs e) //dashboard
        {
            StartAnimation(progressBar1);
            ShowPricesOnDashboard();
            PrikaziFavorite();
            DesignGridFavorite();
            StopAnimation(progressBar1);

            if (panelCoinMarketCap.Visible == true)
            {
                panelCoinMarketCap.Visible = false;
            }
            panelDASHBOARD.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FPortfolio f1 = new FPortfolio();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FConverter f1 = new FConverter();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FEncypted f1 = new FEncypted();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FCryptoMining f1 = new FCryptoMining();
            f1.Show();
        }

        
        public void AnimationControl(ProgressBar progressbar, bool loading)
        {
           while(loading != false)
            {
                progressBar1.PerformStep();
            }
           if(loading != true)
            {
                progressBar1.Value = 0;
            }
                           
        }

        public void StartAnimation(ProgressBar progressbar)
        {
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                progressbar.Value = i;
                progressbar.Update();
            }
        }

        public void StopAnimation(ProgressBar progresbar)
        {
            progresbar.Value = 0;
            progresbar.Update();
        }

        private void button6_Click(object sender, EventArgs e) //coinmarketcap
        {
            StartAnimation(progressBar1);
            FunctionsForMarketCap();
            StopAnimation(progressBar1);

            if (panelDASHBOARD.Visible == true)
            {
                panelDASHBOARD.Visible = false;
            }
            panelCoinMarketCap.Visible = true;
                      
                        
            
        }

        public void ShowPricesOnDashboard()
        {
            lblBTC.Text = coinPrice("BTC") + " $";
            lblETH.Text = coinPrice("ETH") + " $";
            lblLTC.Text = coinPrice("LTC") + " $";
            lblPundi.Text = coinPrice("NPXS") + " $";
            lblXMR.Text = coinPrice("XMR") + " $";
            lblDASH.Text = coinPrice("DASH") + " $";
        }

        public void ShowPercentChange()
        {
           
            string btc = coinPercentChanged("BTC");
            btc.Replace('.', ',');
            double BTC = Convert.ToDouble(btc);
            if(BTC < 0)
            {
                colorRED(lblBTCprocent);
                lblBTCprocent.Text = btc + "%";
            }
            else
            {
                colorGreen(lblBTCprocent);
                lblBTCprocent.Text = btc + "%";
            }


            string eth = coinPercentChanged("ETH");
            eth.Replace('.', ',');
            double ETH = Convert.ToDouble(eth);
            if(ETH < 0)
            {
                colorRED(lblETHprocent);
                lblETHprocent.Text = eth + "%";
            }
            else
            {
                colorGreen(lblETHprocent);
                lblETHprocent.Text = eth + "%";
            }

            string ltc = coinPercentChanged("LTC");
            ltc.Replace('.', ',');
            double LTC = Convert.ToDouble(ltc);
            if(LTC < 0)
            {
                colorRED(lblLTCprocent);
                lblLTCprocent.Text = ltc + "%";
            }
            else
            {
                colorGreen(lblLTCprocent);
                lblLTCprocent.Text = ltc + "%";
            }

            string pundi = coinPercentChanged("NPXS");
            pundi.Replace('.', ',');
            double PUNDI = Convert.ToDouble(pundi);
            if(PUNDI < 0)
            {
                colorRED(lblPUNDIprocent);
                lblPUNDIprocent.Text = pundi + "%";
            }
            else
            {
                colorGreen(lblPUNDIprocent);
                lblPUNDIprocent.Text = pundi + "%";
            }

            string dash = coinPercentChanged("DASH");
            dash.Replace('.', ',');
            double DASH = Convert.ToDouble(dash);
            if(DASH < 0)
            {
                colorRED(lblDASHprocent);
                lblDASHprocent.Text = dash + "%";
            }
            else
            {
                colorGreen(lblDASHprocent);
                lblDASHprocent.Text = dash + "%";
            }

            string xmr = coinPercentChanged("XMR");
            xmr.Replace('.', ',');
            double XMR = Convert.ToDouble(xmr);
            if(XMR < 0)
            {
                colorRED(lblXMRprocent);
                lblXMRprocent.Text = xmr + "%";
            }
            else
            {
                colorGreen(lblXMRprocent);
                lblXMRprocent.Text = xmr + "%";
            }
        }


        public string coinPrice(string symbol)
        {
            string price = "";

            string sql = "Select price_usd From Valute Where symbol=@Symbol";
            using (SqlConnection conne = new SqlConnection(_connectionString))
            {
                conne.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conne))
                {
                    cmd.Parameters.AddWithValue("@Symbol", symbol);
                    cmd.CommandTimeout = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                      
                        while (reader.Read())
                        {                            
                            price = reader[0].ToString();
                           
                        }
                    }
                }
            }

            return price.Substring(0,6);
        }

        public void colorRED(Label l)
        {
            l.ForeColor = Color.DarkRed;
        }
        public void colorGreen(Label l)
        {
            l.ForeColor = Color.Green;
        }

        public string coinPercentChanged(string symbol)
        {
            string percent = "";

            string sql = "Select percent_change_24h From Valute Where symbol=@Symbol";
            using (SqlConnection conne = new SqlConnection(_connectionString))
            {
                conne.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conne))
                {
                    cmd.Parameters.AddWithValue("@Symbol", symbol);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            percent = reader[0].ToString();                          

                        }
                    }
                }

                return percent;
            }
        }

        

        private void button7_Click(object sender, EventArgs e) //Favorites
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("#");
            dt.Columns.Add("name");
            dt.Columns.Add("symbol");
            dt.Columns.Add("usd_price");
            dt.Columns.Add("%1h");
            dt.Columns.Add("%24h");
            dt.Columns.Add("%7d");
            dt.Columns.Add("market_cap");
            dt.Columns.Add("available_supply");
            dt.Columns.Add("max_supply");


            foreach (DataGridViewRow row in ValuteDataGridView.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[16].Value);
                if (isSelected)
                {
                    //dt.Rows.Add(row.Cells[4].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[5].Value, row.Cells[12].Value, row.Cells[13].Value, row.Cells[14].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value);
                    WriteToDBfavorites(row.Cells[4].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString(), row.Cells[14].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
                }
            }
            MessageBox.Show("Added to your favorites!");
            gridFavorite.DataSource = dt;

            OblikujCeneFavorite();
            DesignGridFavorite();
        }

        public void WriteToDBfavorites(string rank, string name, string symb, string price, string change1h, string change24h, string change7d, string marketcap, string available, string max)
        {
          
            try
            {
                SqlConnection conne = new SqlConnection(_connectionString);
                conne.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conne;
                   
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@rank", rank ?? DBNull.Value.ToString()); //vrne levi segment v kolikor ni prazen drugače desnega ??
                        cmd.Parameters.AddWithValue("@name",name ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@symbol", symb ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@price_usd", price ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_1h", change1h ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_24h", change24h ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@percent_change_7d", change7d ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@market_cap_usd", marketcap ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@available_supply", available ?? DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@max_supply", max ?? DBNull.Value.ToString());
                        

                        cmd.CommandText = "INSERT INTO Favorites VALUES (@rank,@name,@symbol,@price_usd,@percent_change_1h,@percent_change_24h,@percent_change_7d,@market_cap_usd,@available_supply,@max_supply)";
                        cmd.ExecuteNonQuery();

                    
                }
              
            }

            catch (Exception) { }

            MessageBox.Show("Saved To Your Favorites! :)");
        
    }

        public void OblikujCeneFavorite()
        {

            gridFavorite.Columns[0].Width = 50;
            gridFavorite.Columns[4].Width = 70;
            gridFavorite.Columns[5].Width = 70;
            gridFavorite.Columns[6].Width = 70;
            gridFavorite.Columns[9].Width = 200;
            gridFavorite.Columns[2].Width = 90;
            gridFavorite.Columns[7].Width = 130;
            gridFavorite.Columns[8].Width = 130;



            foreach (DataGridViewRow Myrow in gridFavorite.Rows)
            {
                try
                {
                    double ch1h = Convert.ToDouble(Myrow.Cells[4].Value.ToString());
                    double ch1d = Convert.ToDouble(Myrow.Cells[5].Value.ToString());
                    double ch7d = Convert.ToDouble(Myrow.Cells[6].Value.ToString());
                    if (ch1h < 0)
                    {
                        Myrow.Cells[4].Style.ForeColor = Color.Red;
                    }
                    else if (ch1h > 0)
                    {
                        Myrow.Cells[4].Style.ForeColor = Color.Green;
                    }
                    if (ch1d < 0)
                    {
                        Myrow.Cells[5].Style.ForeColor = Color.Red;
                    }
                    else if (ch1d > 0)
                    {
                        Myrow.Cells[5].Style.ForeColor = Color.Green;
                    }
                    if (ch7d < 0)
                    {
                        Myrow.Cells[6].Style.ForeColor = Color.Red;
                    }
                    else if (ch7d > 0)
                    {
                        Myrow.Cells[6].Style.ForeColor = Color.Green;
                    }
                }
                catch { continue; }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(1000);
            //    backgroundWorker1.ReportProgress(i);
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //circularProgressBar1.Value = e.ProgressPercentage;
        }

       

        private void ValuteDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }



        public void NastaviFalse()
        {
            for(int i = 0; i <= ValuteDataGridView.Rows.Count-1; i++)
            {
                ValuteDataGridView.Rows[i].Cells[16].Value = false;
            }
        }
        private void ValuteDataGridView_MouseClick(object sender, MouseEventArgs e)
        {         
            ValuteDataGridView.SelectedRows[0].Cells[16].Value = true;
                       
        }     

        private void ValuteDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ValuteDataGridView.SelectedRows[0].Cells[16].Value = false;
        }

        private void button8_Click(object sender, EventArgs e) //refresh favorites
        {
            PrikaziFavorite();
            FunctionsForFavorites();
        }
    }
}
