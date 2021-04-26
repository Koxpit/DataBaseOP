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
            this.TwoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Worker
            // 
            this.Worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Worker.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Worker.BackgroundImage")));
            this.Worker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Worker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Worker.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Worker.Location = new System.Drawing.Point(13, 381);
            this.Worker.Name = "Worker";
            this.Worker.Size = new System.Drawing.Size(223, 101);
            this.Worker.TabIndex = 0;
            this.Worker.Text = "Рабочие";
            this.Worker.UseVisualStyleBackColor = false;
            this.Worker.Click += new System.EventHandler(this.Worker_Click);
            // 
            // Position
            // 
            this.Position.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Position.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Position.BackgroundImage")));
            this.Position.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Position.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Position.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Position.Location = new System.Drawing.Point(13, 274);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(223, 101);
            this.Position.TabIndex = 1;
            this.Position.Text = "Должность";
            this.Position.UseVisualStyleBackColor = false;
            this.Position.Click += new System.EventHandler(this.Position_Click);
            // 
            // Trademark
            // 
            this.Trademark.BackColor = System.Drawing.Color.Maroon;
            this.Trademark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Trademark.BackgroundImage")));
            this.Trademark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Trademark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Trademark.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Trademark.Location = new System.Drawing.Point(242, 274);
            this.Trademark.Name = "Trademark";
            this.Trademark.Size = new System.Drawing.Size(223, 101);
            this.Trademark.TabIndex = 2;
            this.Trademark.Text = "Бренд";
            this.Trademark.UseVisualStyleBackColor = false;
            this.Trademark.Click += new System.EventHandler(this.Trademark_Click);
            // 
            // Product
            // 
            this.Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Product.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Product.BackgroundImage")));
            this.Product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Product.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Product.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Product.Location = new System.Drawing.Point(242, 381);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(223, 101);
            this.Product.TabIndex = 3;
            this.Product.Text = "Продукт";
            this.Product.UseVisualStyleBackColor = false;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // Realization
            // 
            this.Realization.BackColor = System.Drawing.Color.Maroon;
            this.Realization.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Realization.BackgroundImage")));
            this.Realization.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Realization.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Realization.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Realization.Location = new System.Drawing.Point(471, 274);
            this.Realization.Name = "Realization";
            this.Realization.Size = new System.Drawing.Size(223, 101);
            this.Realization.TabIndex = 4;
            this.Realization.Text = "Реализация";
            this.Realization.UseVisualStyleBackColor = false;
            this.Realization.Click += new System.EventHandler(this.Realization_Click);
            // 
            // Supplier
            // 
            this.Supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Supplier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Supplier.BackgroundImage")));
            this.Supplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Supplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Supplier.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Supplier.Location = new System.Drawing.Point(471, 381);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(223, 101);
            this.Supplier.TabIndex = 5;
            this.Supplier.Text = "Поставщик";
            this.Supplier.UseVisualStyleBackColor = false;
            this.Supplier.Click += new System.EventHandler(this.Supplier_Click);
            // 
            // Category
            // 
            this.Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Category.BackgroundImage = global::DataBaseOP.Properties.Resources.buttons_PNG51;
            this.Category.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Category.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Category.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Category.Location = new System.Drawing.Point(700, 274);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(223, 101);
            this.Category.TabIndex = 6;
            this.Category.Text = "Категория";
            this.Category.UseVisualStyleBackColor = false;
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Maroon;
            this.menuStrip1.BackgroundImage = global::DataBaseOP.Properties.Resources.tekstura_tasc;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OneToolStripMenuItem,
            this.TwoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 32);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OneToolStripMenuItem
            // 
            this.OneToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OneToolStripMenuItem.Name = "OneToolStripMenuItem";
            this.OneToolStripMenuItem.Size = new System.Drawing.Size(173, 28);
            this.OneToolStripMenuItem.Text = "Отчёт за период";
            this.OneToolStripMenuItem.Click += new System.EventHandler(this.OneToolStripMenuItem_Click);
            // 
            // TwoToolStripMenuItem
            // 
            this.TwoToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TwoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TwoToolStripMenuItem.Name = "TwoToolStripMenuItem";
            this.TwoToolStripMenuItem.Size = new System.Drawing.Size(151, 28);
            this.TwoToolStripMenuItem.Text = "О Программе";
            this.TwoToolStripMenuItem.Click += new System.EventHandler(this.TwoToolStripMenuItem_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exit.BackgroundImage = global::DataBaseOP.Properties.Resources.buttons_PNG51;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.SystemColors.MenuText;
            this.exit.Location = new System.Drawing.Point(700, 381);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(223, 101);
            this.exit.TabIndex = 8;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(43, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(834, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "База данных для предприятия оптовой торговли";
            // 
            // DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::DataBaseOP.Properties.Resources.tecstura3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 490);
            this.Controls.Add(this.label1);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных ОТ";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem TwoToolStripMenuItem;
    }
}

