
namespace DataBaseOP
{
    partial class RealizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealizationForm));
            this.dataGridViewRealizations = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRealizations)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRealizations
            // 
            this.dataGridViewRealizations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridViewRealizations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRealizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRealizations.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewRealizations.Name = "dataGridViewRealizations";
            this.dataGridViewRealizations.Size = new System.Drawing.Size(800, 423);
            this.dataGridViewRealizations.TabIndex = 0;
            this.dataGridViewRealizations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRealizations_CellContentClick);
            this.dataGridViewRealizations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRealizations_CellValueChanged);
            this.dataGridViewRealizations.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewRealizations_EditingControlShowing);
            this.dataGridViewRealizations.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewRealizations_UserAddedRow);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuStrip.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(133, 23);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт в excel";
            this.экспортВExcelToolStripMenuItem.Click += new System.EventHandler(this.экспортВExcelToolStripMenuItem_Click);
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // RealizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewRealizations);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "RealizationForm";
            this.Text = "Реализация";
            this.Load += new System.EventHandler(this.RealizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRealizations)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRealizations;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}