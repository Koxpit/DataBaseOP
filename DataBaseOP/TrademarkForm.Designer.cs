
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrademarkForm));
            this.dataGridViewTrademarks = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrademarks)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTrademarks
            // 
            this.dataGridViewTrademarks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridViewTrademarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrademarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrademarks.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewTrademarks.Name = "dataGridViewTrademarks";
            this.dataGridViewTrademarks.Size = new System.Drawing.Size(800, 423);
            this.dataGridViewTrademarks.TabIndex = 0;
            this.dataGridViewTrademarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTrademarks_CellContentClick);
            this.dataGridViewTrademarks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTrademarks_CellValueChanged);
            this.dataGridViewTrademarks.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewTrademarks_EditingControlShowing);
            this.dataGridViewTrademarks.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewTrademarks_UserAddedRow);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВExcelToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // экспортВExcelToolStripMenuItem
            // 
            this.экспортВExcelToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(133, 23);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт в excel";
            this.экспортВExcelToolStripMenuItem.Click += new System.EventHandler(this.экспортВExcelToolStripMenuItem_Click);
            // 
            // TrademarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewTrademarks);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TrademarkForm";
            this.Text = "Бренд";
            this.Load += new System.EventHandler(this.TrademarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrademarks)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTrademarks;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
    }
}