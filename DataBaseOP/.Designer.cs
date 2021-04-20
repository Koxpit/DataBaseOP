namespace DataBaseOP
{
    partial class DataBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBase));
            this.Worker = new System.Windows.Forms.Button();
            this.Position = new System.Windows.Forms.Button();
            this.Trademark = new System.Windows.Forms.Button();
            this.Product = new System.Windows.Forms.Button();
            this.Realization = new System.Windows.Forms.Button();
            this.Supplier = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Worker
            // 
            this.Worker.Location = new System.Drawing.Point(12, 394);
            this.Worker.Name = "Worker";
            this.Worker.Size = new System.Drawing.Size(223, 101);
            this.Worker.TabIndex = 0;
            this.Worker.Text = "Рабочие";
            this.Worker.UseVisualStyleBackColor = true;
            this.Worker.Click += new System.EventHandler(this.Worker_Click);
            // 
            // Position
            // 
            this.Position.Location = new System.Drawing.Point(12, 287);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(223, 101);
            this.Position.TabIndex = 1;
            this.Position.Text = "Должность";
            this.Position.UseVisualStyleBackColor = true;
            this.Position.Click += new System.EventHandler(this.Position_Click);
            // 
            // Trademark
            // 
            this.Trademark.Location = new System.Drawing.Point(241, 287);
            this.Trademark.Name = "Trademark";
            this.Trademark.Size = new System.Drawing.Size(223, 101);
            this.Trademark.TabIndex = 2;
            this.Trademark.Text = "Бренд";
            this.Trademark.UseVisualStyleBackColor = true;
            this.Trademark.Click += new System.EventHandler(this.Trademark_Click);
            // 
            // Product
            // 
            this.Product.Location = new System.Drawing.Point(241, 394);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(223, 101);
            this.Product.TabIndex = 3;
            this.Product.Text = "Продукт";
            this.Product.UseVisualStyleBackColor = true;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // Realization
            // 
            this.Realization.Location = new System.Drawing.Point(470, 287);
            this.Realization.Name = "Realization";
            this.Realization.Size = new System.Drawing.Size(223, 101);
            this.Realization.TabIndex = 4;
            this.Realization.Text = "Реализация";
            this.Realization.UseVisualStyleBackColor = true;
            this.Realization.Click += new System.EventHandler(this.Realization_Click);
            // 
            // Supplier
            // 
            this.Supplier.Location = new System.Drawing.Point(470, 394);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(223, 101);
            this.Supplier.TabIndex = 5;
            this.Supplier.Text = "Поставщик";
            this.Supplier.UseVisualStyleBackColor = true;
            this.Supplier.Click += new System.EventHandler(this.Supplier_Click);
            // 
            // Category
            // 
            this.Category.Location = new System.Drawing.Point(699, 287);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(223, 101);
            this.Category.TabIndex = 6;
            this.Category.Text = "Категория";
            this.Category.UseVisualStyleBackColor = true;
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OneToolStripMenuItem
            // 
            this.OneToolStripMenuItem.Name = "OneToolStripMenuItem";
            this.OneToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.OneToolStripMenuItem.Text = "О Программе";
            this.OneToolStripMenuItem.Click += new System.EventHandler(this.OneToolStripMenuItem_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(699, 394);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(223, 101);
            this.exit.TabIndex = 8;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 502);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.Realization);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.Trademark);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.Worker);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBase";
            this.ShowInTaskbar = false;
            this.Text = "База данных ОП";
            this.Load += new System.EventHandler(this.DataBase_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Worker;
        private System.Windows.Forms.Button Position;
        private System.Windows.Forms.Button Trademark;
        private System.Windows.Forms.Button Product;
        private System.Windows.Forms.Button Realization;
        private System.Windows.Forms.Button Supplier;
        private System.Windows.Forms.Button Category;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OneToolStripMenuItem;
        private System.Windows.Forms.Button exit;
    }
}

