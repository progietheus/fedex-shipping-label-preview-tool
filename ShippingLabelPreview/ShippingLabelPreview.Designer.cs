namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_convert = new System.Windows.Forms.Button();
            this.lbl_manual = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_manual = new System.Windows.Forms.TextBox();
            this.radio_peripheral = new System.Windows.Forms.RadioButton();
            this.radio_manual = new System.Windows.Forms.RadioButton();
            this.pnl_manual = new System.Windows.Forms.Panel();
            this.pnl_peripheral = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_peripheral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_manual.SuspendLayout();
            this.pnl_peripheral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(375, 501);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(87, 31);
            this.btn_print.TabIndex = 0;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(337, 44);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(107, 50);
            this.btn_convert.TabIndex = 3;
            this.btn_convert.Text = "Convert to Image";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_manual
            // 
            this.lbl_manual.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_manual.Location = new System.Drawing.Point(3, 3);
            this.lbl_manual.Name = "lbl_manual";
            this.lbl_manual.Size = new System.Drawing.Size(441, 38);
            this.lbl_manual.TabIndex = 4;
            this.lbl_manual.Text = "Convert Fedex Label from Base64 to Image";
            this.lbl_manual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 310);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txt_manual
            // 
            this.txt_manual.Location = new System.Drawing.Point(3, 44);
            this.txt_manual.Multiline = true;
            this.txt_manual.Name = "txt_manual";
            this.txt_manual.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_manual.Size = new System.Drawing.Size(328, 50);
            this.txt_manual.TabIndex = 2;
            // 
            // radio_peripheral
            // 
            this.radio_peripheral.AutoSize = true;
            this.radio_peripheral.Checked = true;
            this.radio_peripheral.Location = new System.Drawing.Point(15, 13);
            this.radio_peripheral.Name = "radio_peripheral";
            this.radio_peripheral.Size = new System.Drawing.Size(101, 17);
            this.radio_peripheral.TabIndex = 5;
            this.radio_peripheral.TabStop = true;
            this.radio_peripheral.Text = "Peripheral Label";
            this.radio_peripheral.UseVisualStyleBackColor = true;
            this.radio_peripheral.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radio_manual
            // 
            this.radio_manual.AutoSize = true;
            this.radio_manual.Location = new System.Drawing.Point(122, 12);
            this.radio_manual.Name = "radio_manual";
            this.radio_manual.Size = new System.Drawing.Size(172, 17);
            this.radio_manual.TabIndex = 6;
            this.radio_manual.Text = "Fedex Label (Base64 to Image)";
            this.radio_manual.UseVisualStyleBackColor = true;
            this.radio_manual.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // pnl_manual
            // 
            this.pnl_manual.Controls.Add(this.txt_manual);
            this.pnl_manual.Controls.Add(this.lbl_manual);
            this.pnl_manual.Controls.Add(this.btn_convert);
            this.pnl_manual.Location = new System.Drawing.Point(15, 37);
            this.pnl_manual.Name = "pnl_manual";
            this.pnl_manual.Size = new System.Drawing.Size(447, 97);
            this.pnl_manual.TabIndex = 7;
            this.pnl_manual.Visible = false;
            // 
            // pnl_peripheral
            // 
            this.pnl_peripheral.Controls.Add(this.dataGridView1);
            this.pnl_peripheral.Controls.Add(this.lbl_peripheral);
            this.pnl_peripheral.Location = new System.Drawing.Point(12, 37);
            this.pnl_peripheral.Name = "pnl_peripheral";
            this.pnl_peripheral.Size = new System.Drawing.Size(451, 142);
            this.pnl_peripheral.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Qty});
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 104);
            this.dataGridView1.TabIndex = 7;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.HeaderText = "Name";
            this.Item.Name = "Item";
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // lbl_peripheral
            // 
            this.lbl_peripheral.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_peripheral.Location = new System.Drawing.Point(3, 3);
            this.lbl_peripheral.Name = "lbl_peripheral";
            this.lbl_peripheral.Size = new System.Drawing.Size(441, 28);
            this.lbl_peripheral.TabIndex = 6;
            this.lbl_peripheral.Text = "Print Peripheral Label";
            this.lbl_peripheral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 544);
            this.Controls.Add(this.pnl_peripheral);
            this.Controls.Add(this.radio_manual);
            this.Controls.Add(this.radio_peripheral);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnl_manual);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(491, 583);
            this.MinimumSize = new System.Drawing.Size(491, 583);
            this.Name = "Form1";
            this.Text = "Fedex Label Viewer & Printer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_manual.ResumeLayout(false);
            this.pnl_manual.PerformLayout();
            this.pnl_peripheral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Label lbl_manual;
        private System.Windows.Forms.TextBox txt_manual;
        private System.Windows.Forms.RadioButton radio_peripheral;
        private System.Windows.Forms.RadioButton radio_manual;
        private System.Windows.Forms.Panel pnl_manual;
        private System.Windows.Forms.Panel pnl_peripheral;
        private System.Windows.Forms.Label lbl_peripheral;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
    }
}

