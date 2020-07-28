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
using System.Diagnostics;

namespace cyptoAnaliser
{
    public partial class FCryptoMining : Form
    {
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GEP\Desktop\N1\C#\cyptoAnaliser\cyptoAnaliser\Cryptocurrencies.mdf;Integrated Security=True;Connect Timeout=30";

        public FCryptoMining()
        {
            InitializeComponent();
        }

        private void FCryptoMining_Load(object sender, EventArgs e)
        {
            NapolniCombox(ImenaValut());

        }
        public void NapolniCombox(List<string> list)
        {
            comboBox1.DataSource = list;
        }

        public List<string> ImenaValut()
        {
            List<string> list = new List<string>();
            using (SqlConnection conne = new SqlConnection(_connectionString))
            {
                conne.Open();
                string sql = "Select name From Valute";
                using(SqlCommand cmd = new SqlCommand(sql, conne))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                }
            }
            return list;
        }

        public bool pogojAplikacija()
        {
            bool obstaja = false;

            if (txtApp.Text != null)
                obstaja = true;

            return obstaja;          
        }

        public bool pogojScripta()
        {
            bool obstaja = false;

            if (txtApp.Text != null)
                obstaja = true;

            return obstaja;
        }

        private void btnSelectApp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select application to run script";
            ofd.Filter = ".exe File | *.exe";
            ofd.InitialDirectory = @"C:\";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                txtApp.Text = ofd.FileName;
            }

        }

        public string Path = "";
        private void btnSelectScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select script to run in app";
            ofd.Filter = ".bat File | *.bat";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtScript.Text = ofd.FileName;
                Path = ofd.FileName;

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (pogojAplikacija() && pogojScripta() == true)
            {
                RUNcmd(Path);
            }
            else { MessageBox.Show("We couldn't find any particular application to launch miner script!"); }
        }

        public void RUNcmd(string path)
        {
            //string filepath = @"C:\Users\GEP\Desktop\CRYPTO\RUN.bat";
            Process.Start("cmd.exe", "/K " + path);
            //System.Diagnostics.Process.Start("/K" + path);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you really want to close miner?", "Closing", MessageBoxButtons.YesNoCancel);
          
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First please select your application with whom you will mine crypto, then select your script file (*.bat) and press 'Start'");
        }
    }
}
