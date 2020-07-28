namespace cyptoAnaliser
{
    partial class FConverter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.comboBox1From = new System.Windows.Forms.ComboBox();
            this.comboBox2To = new System.Windows.Forms.ComboBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Adobe Devanagari", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(22, 33);
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFrom.Size = new System.Drawing.Size(96, 32);
            this.txtFrom.TabIndex = 2;
            // 
            // comboBox1From
            // 
            this.comboBox1From.FormattingEnabled = true;
            this.comboBox1From.Items.AddRange(new object[] {
            "USD",
            "BTC",
            "ETH",
            "LTC"});
            this.comboBox1From.Location = new System.Drawing.Point(22, 68);
            this.comboBox1From.Name = "comboBox1From";
            this.comboBox1From.Size = new System.Drawing.Size(59, 21);
            this.comboBox1From.TabIndex = 3;
            // 
            // comboBox2To
            // 
            this.comboBox2To.FormattingEnabled = true;
            this.comboBox2To.Items.AddRange(new object[] {
            "USD",
            "BTC",
            "ETH",
            "LTC"});
            this.comboBox2To.Location = new System.Drawing.Point(192, 68);
            this.comboBox2To.Name = "comboBox2To";
            this.comboBox2To.Size = new System.Drawing.Size(58, 21);
            this.comboBox2To.TabIndex = 4;
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Adobe Devanagari", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(192, 33);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTo.Size = new System.Drawing.Size(96, 32);
            this.txtTo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "=>";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 165);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.comboBox2To);
            this.Controls.Add(this.comboBox1From);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.ComboBox comboBox1From;
        private System.Windows.Forms.ComboBox comboBox2To;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}