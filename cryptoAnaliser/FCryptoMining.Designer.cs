namespace cyptoAnaliser
{
    partial class FCryptoMining
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSelectApp = new System.Windows.Forms.Button();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.btnSelectScript = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.cryptocurrenciesDataSet = new cyptoAnaliser.CryptocurrenciesDataSet();
            this.valuteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valuteTableAdapter = new cyptoAnaliser.CryptocurrenciesDataSetTableAdapters.ValuteTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cryptocurrenciesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectApp
            // 
            this.btnSelectApp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectApp.Location = new System.Drawing.Point(147, 39);
            this.btnSelectApp.Name = "btnSelectApp";
            this.btnSelectApp.Size = new System.Drawing.Size(75, 20);
            this.btnSelectApp.TabIndex = 0;
            this.btnSelectApp.Text = "Select";
            this.btnSelectApp.UseVisualStyleBackColor = true;
            this.btnSelectApp.Click += new System.EventHandler(this.btnSelectApp_Click);
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(13, 38);
            this.txtApp.Name = "txtApp";
            this.txtApp.ReadOnly = true;
            this.txtApp.Size = new System.Drawing.Size(128, 20);
            this.txtApp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "application file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "script file path:";
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(13, 102);
            this.txtScript.Name = "txtScript";
            this.txtScript.ReadOnly = true;
            this.txtScript.Size = new System.Drawing.Size(128, 20);
            this.txtScript.TabIndex = 4;
            // 
            // btnSelectScript
            // 
            this.btnSelectScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectScript.Location = new System.Drawing.Point(147, 103);
            this.btnSelectScript.Name = "btnSelectScript";
            this.btnSelectScript.Size = new System.Drawing.Size(75, 20);
            this.btnSelectScript.TabIndex = 3;
            this.btnSelectScript.Text = "Select";
            this.btnSelectScript.UseVisualStyleBackColor = true;
            this.btnSelectScript.Click += new System.EventHandler(this.btnSelectScript_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(15, 229);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 20);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnSelectScript);
            this.panel1.Controls.Add(this.btnSelectApp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtApp);
            this.panel1.Controls.Add(this.txtScript);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 147);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 57);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "crypto to mine:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.valuteBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "name";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHelp.Location = new System.Drawing.Point(177, 229);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 20);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStop.Location = new System.Drawing.Point(96, 229);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 20);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cryptocurrenciesDataSet
            // 
            this.cryptocurrenciesDataSet.DataSetName = "CryptocurrenciesDataSet";
            this.cryptocurrenciesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // valuteBindingSource
            // 
            this.valuteBindingSource.DataMember = "Valute";
            this.valuteBindingSource.DataSource = this.cryptocurrenciesDataSet;
            // 
            // valuteTableAdapter
            // 
            this.valuteTableAdapter.ClearBeforeFill = true;
            // 
            // FCryptoMining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FCryptoMining";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCryptoMining";
            this.Load += new System.EventHandler(this.FCryptoMining_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cryptocurrenciesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectApp;
        private System.Windows.Forms.TextBox txtApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Button btnSelectScript;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnStop;
        private CryptocurrenciesDataSet cryptocurrenciesDataSet;
        private System.Windows.Forms.BindingSource valuteBindingSource;
        private CryptocurrenciesDataSetTableAdapters.ValuteTableAdapter valuteTableAdapter;
    }
}