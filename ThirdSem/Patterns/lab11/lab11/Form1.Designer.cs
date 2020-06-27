namespace lab11
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cBox = new System.Windows.Forms.TextBox();
            this.commentBox = new System.Windows.Forms.RichTextBox();
            this.sqrBox = new System.Windows.Forms.TextBox();
            this.aBox = new System.Windows.Forms.TextBox();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.Label();
            this.countBox = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sBox = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(307, 320);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Внести квартиру в базу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cBox
            // 
            this.cBox.Location = new System.Drawing.Point(109, 105);
            this.cBox.Name = "cBox";
            this.cBox.Size = new System.Drawing.Size(179, 22);
            this.cBox.TabIndex = 3;
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(109, 161);
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(179, 162);
            this.commentBox.TabIndex = 4;
            this.commentBox.Text = "";
            // 
            // sqrBox
            // 
            this.sqrBox.Location = new System.Drawing.Point(109, 72);
            this.sqrBox.Name = "sqrBox";
            this.sqrBox.Size = new System.Drawing.Size(179, 22);
            this.sqrBox.TabIndex = 5;
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(109, 133);
            this.aBox.Name = "aBox";
            this.aBox.Size = new System.Drawing.Size(179, 22);
            this.aBox.TabIndex = 6;
            // 
            // cityBox
            // 
            this.cityBox.Location = new System.Drawing.Point(109, 16);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(179, 22);
            this.cityBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ageBox);
            this.groupBox1.Controls.Add(this.countBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cityBox);
            this.groupBox1.Controls.Add(this.commentBox);
            this.groupBox1.Controls.Add(this.aBox);
            this.groupBox1.Controls.Add(this.cBox);
            this.groupBox1.Controls.Add(this.sqrBox);
            this.groupBox1.Location = new System.Drawing.Point(683, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 406);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "комментарии";
            // 
            // ageBox
            // 
            this.ageBox.AutoSize = true;
            this.ageBox.Location = new System.Drawing.Point(300, 133);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(61, 17);
            this.ageBox.TabIndex = 11;
            this.ageBox.Text = "Русский";
            // 
            // countBox
            // 
            this.countBox.AutoSize = true;
            this.countBox.Location = new System.Drawing.Point(298, 105);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(89, 17);
            this.countBox.TabIndex = 10;
            this.countBox.Text = "Математика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Класс";
            // 
            // sBox
            // 
            this.sBox.AutoSize = true;
            this.sBox.Location = new System.Drawing.Point(294, 72);
            this.sBox.Name = "sBox";
            this.sBox.Size = new System.Drawing.Size(84, 17);
            this.sBox.TabIndex = 8;
            this.sBox.Text = "Английский";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(342, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(254, 96);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(342, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "Показать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(109, 44);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(179, 22);
            this.nameBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Имя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 430);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cBox;
        private System.Windows.Forms.RichTextBox commentBox;
        private System.Windows.Forms.TextBox sqrBox;
        private System.Windows.Forms.TextBox aBox;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ageBox;
        private System.Windows.Forms.Label countBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
    }
}

