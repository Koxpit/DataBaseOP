
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
            this.dataGridViewRealizations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRealizations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRealizations
            // 
            this.dataGridViewRealizations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRealizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRealizations.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRealizations.Name = "dataGridViewRealizations";
            this.dataGridViewRealizations.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewRealizations.TabIndex = 0;
            this.dataGridViewRealizations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRealizations_CellContentClick);
            this.dataGridViewRealizations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRealizations_CellValueChanged);
            this.dataGridViewRealizations.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewRealizations_EditingControlShowing);
            this.dataGridViewRealizations.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewRealizations_UserAddedRow);
            // 
            // RealizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewRealizations);
            this.Name = "RealizationForm";
            this.Text = "Реализация";
            this.Load += new System.EventHandler(this.RealizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRealizations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRealizations;
    }
}