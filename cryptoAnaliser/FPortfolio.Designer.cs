namespace cyptoAnaliser
{
    partial class FPortfolio
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.portfolioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cryptocurrenciesDataSet1 = new cyptoAnaliser.CryptocurrenciesDataSet1();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajInvesticijoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.možnostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portfolioTableAdapter = new cyptoAnaliser.CryptocurrenciesDataSet1TableAdapters.PortfolioTableAdapter();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valutaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.investicijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vrednost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitProcent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zapriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cryptocurrenciesDataSet1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.datumDataGridViewTextBoxColumn,
            this.valutaDataGridViewTextBoxColumn,
            this.kolicinaDataGridViewTextBoxColumn,
            this.investicijaDataGridViewTextBoxColumn,
            this.Vrednost,
            this.Profit,
            this.ProfitProcent});
            this.dataGridView1.DataSource = this.portfolioBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(539, 214);
            this.dataGridView1.TabIndex = 0;
            // 
            // portfolioBindingSource
            // 
            this.portfolioBindingSource.DataMember = "Portfolio";
            this.portfolioBindingSource.DataSource = this.cryptocurrenciesDataSet1;
            // 
            // cryptocurrenciesDataSet1
            // 
            this.cryptocurrenciesDataSet1.DataSetName = "CryptocurrenciesDataSet1";
            this.cryptocurrenciesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajInvesticijoToolStripMenuItem,
            this.možnostiToolStripMenuItem,
            this.zapriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajInvesticijoToolStripMenuItem
            // 
            this.dodajInvesticijoToolStripMenuItem.Name = "dodajInvesticijoToolStripMenuItem";
            this.dodajInvesticijoToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.dodajInvesticijoToolStripMenuItem.Text = "Add asset";
            this.dodajInvesticijoToolStripMenuItem.Click += new System.EventHandler(this.dodajInvesticijoToolStripMenuItem_Click);
            // 
            // možnostiToolStripMenuItem
            // 
            this.možnostiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.možnostiToolStripMenuItem.Name = "možnostiToolStripMenuItem";
            this.možnostiToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.možnostiToolStripMenuItem.Text = "Options";
            // 
            // portfolioTableAdapter
            // 
            this.portfolioTableAdapter.ClearBeforeFill = true;
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datumDataGridViewTextBoxColumn
            // 
            this.datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            this.datumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valutaDataGridViewTextBoxColumn
            // 
            this.valutaDataGridViewTextBoxColumn.DataPropertyName = "Valuta";
            this.valutaDataGridViewTextBoxColumn.HeaderText = "Valuta";
            this.valutaDataGridViewTextBoxColumn.Name = "valutaDataGridViewTextBoxColumn";
            this.valutaDataGridViewTextBoxColumn.ReadOnly = true;
            this.valutaDataGridViewTextBoxColumn.Width = 50;
            // 
            // kolicinaDataGridViewTextBoxColumn
            // 
            this.kolicinaDataGridViewTextBoxColumn.DataPropertyName = "Kolicina";
            this.kolicinaDataGridViewTextBoxColumn.HeaderText = "Kolicina";
            this.kolicinaDataGridViewTextBoxColumn.Name = "kolicinaDataGridViewTextBoxColumn";
            this.kolicinaDataGridViewTextBoxColumn.ReadOnly = true;
            this.kolicinaDataGridViewTextBoxColumn.Width = 65;
            // 
            // investicijaDataGridViewTextBoxColumn
            // 
            this.investicijaDataGridViewTextBoxColumn.DataPropertyName = "Investicija";
            this.investicijaDataGridViewTextBoxColumn.HeaderText = "Investicija";
            this.investicijaDataGridViewTextBoxColumn.Name = "investicijaDataGridViewTextBoxColumn";
            this.investicijaDataGridViewTextBoxColumn.ReadOnly = true;
            this.investicijaDataGridViewTextBoxColumn.Width = 65;
            // 
            // Vrednost
            // 
            this.Vrednost.HeaderText = "Vrednost";
            this.Vrednost.Name = "Vrednost";
            this.Vrednost.ReadOnly = true;
            this.Vrednost.Width = 65;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit USD";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.Width = 65;
            // 
            // ProfitProcent
            // 
            this.ProfitProcent.HeaderText = "Profit %";
            this.ProfitProcent.Name = "ProfitProcent";
            this.ProfitProcent.ReadOnly = true;
            this.ProfitProcent.Width = 65;
            // 
            // zapriToolStripMenuItem
            // 
            this.zapriToolStripMenuItem.Name = "zapriToolStripMenuItem";
            this.zapriToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.zapriToolStripMenuItem.Text = "Zapri";
            this.zapriToolStripMenuItem.Click += new System.EventHandler(this.zapriToolStripMenuItem_Click);
            // 
            // FPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 238);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FPortfolio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPortfolio";
            this.Load += new System.EventHandler(this.FPortfolio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cryptocurrenciesDataSet1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajInvesticijoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem možnostiToolStripMenuItem;
        private CryptocurrenciesDataSet1 cryptocurrenciesDataSet1;
        private System.Windows.Forms.BindingSource portfolioBindingSource;
        private CryptocurrenciesDataSet1TableAdapters.PortfolioTableAdapter portfolioTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valutaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn investicijaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vrednost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitProcent;
        private System.Windows.Forms.ToolStripMenuItem zapriToolStripMenuItem;
    }
}