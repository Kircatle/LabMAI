namespace lab4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.затратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сайтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выручкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сайтToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.прибыльToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данToolStripMenuItem,
            this.прибыльToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // данToolStripMenuItem
            // 
            this.данToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.затратыToolStripMenuItem,
            this.выручкаToolStripMenuItem});
            this.данToolStripMenuItem.Name = "данToolStripMenuItem";
            this.данToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.данToolStripMenuItem.Text = "Информация о сайте";
            // 
            // затратыToolStripMenuItem
            // 
            this.затратыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сайтToolStripMenuItem,
            this.данныеToolStripMenuItem});
            this.затратыToolStripMenuItem.Name = "затратыToolStripMenuItem";
            this.затратыToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.затратыToolStripMenuItem.Text = "Выручка";
            // 
            // сайтToolStripMenuItem
            // 
            this.сайтToolStripMenuItem.Name = "сайтToolStripMenuItem";
            this.сайтToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.сайтToolStripMenuItem.Text = "Сайт";
            this.сайтToolStripMenuItem.Click += new System.EventHandler(this.СайтToolStripMenuItem_Click);
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.данныеToolStripMenuItem.Text = "Данные";
            this.данныеToolStripMenuItem.Click += new System.EventHandler(this.ДанныеToolStripMenuItem_Click);
            // 
            // выручкаToolStripMenuItem
            // 
            this.выручкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сайтToolStripMenuItem1,
            this.данныеToolStripMenuItem1});
            this.выручкаToolStripMenuItem.Name = "выручкаToolStripMenuItem";
            this.выручкаToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.выручкаToolStripMenuItem.Text = "Затраты";
            // 
            // сайтToolStripMenuItem1
            // 
            this.сайтToolStripMenuItem1.Name = "сайтToolStripMenuItem1";
            this.сайтToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.сайтToolStripMenuItem1.Text = "Сайт";
            this.сайтToolStripMenuItem1.Click += new System.EventHandler(this.СайтToolStripMenuItem_Click);
            // 
            // данныеToolStripMenuItem1
            // 
            this.данныеToolStripMenuItem1.Name = "данныеToolStripMenuItem1";
            this.данныеToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.данныеToolStripMenuItem1.Text = "Данные";
            this.данныеToolStripMenuItem1.Click += new System.EventHandler(this.ДанныеToolStripMenuItem1_Click);
            // 
            // прибыльToolStripMenuItem
            // 
            this.прибыльToolStripMenuItem.Name = "прибыльToolStripMenuItem";
            this.прибыльToolStripMenuItem.Size = new System.Drawing.Size(88, 26);
            this.прибыльToolStripMenuItem.Text = "Прибыль";
            this.прибыльToolStripMenuItem.Click += new System.EventHandler(this.ПрибыльToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(67, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(474, 261);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(501, 80);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(483, 261);
            this.dataGridView2.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(996, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "Название сайта";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 370);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Доходность сайтов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem данToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem затратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выручкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прибыльToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сайтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сайтToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

