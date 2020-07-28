using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cyptoAnaliser
{
    public partial class FPozdrav : Form
    {
        public FPozdrav()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            FMeni f1 = new FMeni();
            this.Hide();
            f1.Show();
        }

        private void FPozdrav_MouseEnter(object sender, EventArgs e)
        {
          
        }
    }
}
