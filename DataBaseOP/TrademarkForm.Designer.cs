
namespace DataBaseOP
{
    partial class TrademarkForm
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
            this.dataGridViewTrademarks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrademarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTrademarks
            // 
            this.dataGridViewTrademarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrademarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrademarks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTrademarks.Name = "dataGridViewTrademarks";
            this.dataGridViewTrademarks.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewTrademarks.TabIndex = 0;
            // 
            // TrademarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewTrademarks);
            this.Name = "TrademarkForm";
            this.Text = "Бренд";
            this.Load += new System.EventHandler(this.TrademarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrademarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTrademarks;
    }
}