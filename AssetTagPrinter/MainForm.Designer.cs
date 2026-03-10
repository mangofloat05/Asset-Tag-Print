namespace AssetTagPrinter
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewAssets;
        private System.Windows.Forms.Button btnPrint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewAssets = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssets
            // 
            this.dataGridViewAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssets.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAssets.Name = "dataGridViewAssets";
            this.dataGridViewAssets.Size = new System.Drawing.Size(776, 377);
            this.dataGridViewAssets.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 395);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(776, 43);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print All";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridViewAssets);
            this.Name = "MainForm";
            this.Text = "Asset Tag Printer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
