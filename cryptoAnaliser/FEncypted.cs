using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace cyptoAnaliser
{
    public partial class FEncypted : Form
    {
        public FEncypted()
        {
            InitializeComponent();
            NapolniAlgoritme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the password in the 'Password box', select your encrypted alghorithm and click 'Generate' to generate encypted passcode.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = comboBox1.SelectedItem.ToString();
            string pass = txtPass.Text;
            switch (value)
            {
                
                case "SHA-256":                
                    ReturnEncryptedValueSHA256(pass);
                    break;
                case "SHA-512":
                    ReturnEncryptedValueSHA512(pass); 
                    break;
                case "SHA1":
                    ReturnEncryptedValueSHA1(pass);
                    break;
                
            }
        }

        public void NapolniAlgoritme()
        {
            comboBox1.Items.Add("SHA-256");
            comboBox1.Items.Add("SHA-512");
            comboBox1.Items.Add("SHA1");
        }

        public void ReturnEncryptedValueSHA256(string password)
        {
            txtEncode.Text = SHA.GenerateSHA256String(password);
        }
        public void ReturnEncryptedValueSHA512(string password)
        {
            txtEncode.Text = SHA.GenerateSHA512String(password);
        }
        public void ReturnEncryptedValueSHA1(string password)
        {
            txtEncode.Text = SHA.Hash(password);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtEncode.Text);
        }
    }
}
