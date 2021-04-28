
namespace DataBaseOP
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.dataGridViewReportResult = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Calculate = new System.Windows.Forms.Button();
            this.dateTimePickerBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportResult)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewReportResult
            // 
            this.dataGridViewReportResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridViewReportResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReportResult.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewReportResult.Name = "dataGridViewReportResult";
            this.dataGridViewReportResult.Size = new System.Drawing.Size(1161, 614);
            this.dataGridViewReportResult.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImage = global::DataBaseOP.Properties.Resources.screen_tasc;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВExcelToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1185, 32);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // экспортВExcelToolStripMenuItem
            // 
            this.экспортВExcelToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.экспортВExcelToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт в excel";
            this.экспортВExcelToolStripMenuItem.Click += new System.EventHandler(this.экспортВExcelToolStripMenuItem_Click);
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.Color.Maroon;
            this.Calculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Calculate.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Calculate.Location = new System.Drawing.Point(653, 659);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(257, 47);
            this.Calculate.TabIndex = 2;
            this.Calculate.Text = "Вычислить";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // dateTimePickerBeginDate
            // 
            this.dateTimePickerBeginDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerBeginDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerBeginDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerBeginDate.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBeginDate.Location = new System.Drawing.Point(12, 658);
            this.dateTimePickerBeginDate.Name = "dateTimePickerBeginDate";
            this.dateTimePickerBeginDate.Size = new System.Drawing.Size(299, 44);
            this.dateTimePickerBeginDate.TabIndex = 3;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerEndDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerEndDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimePickerEndDate.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(317, 658);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(299, 44);
            this.dateTimePickerEndDate.TabIndex = 4;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Maroon;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.exit.Location = new System.Drawing.Point(916, 659);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(257, 47);
            this.exit.TabIndex = 5;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataBaseOP.Properties.Resources.screen_Rep;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1185, 718);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerBeginDate);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.dataGridViewReportResult);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report";
            this.Text = "Вычисление заработка за период";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportResult)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.DateTimePicker dateTimePickerBeginDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        public System.Windows.Forms.DataGridView dataGridViewReportResult;
    }
}