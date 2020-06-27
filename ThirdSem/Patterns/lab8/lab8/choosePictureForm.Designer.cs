namespace lab8
{
    partial class ChoosePictureForm
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.choosePictureButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 272);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(137, 27);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // choosePictureButton
            // 
            this.choosePictureButton.Location = new System.Drawing.Point(6, 150);
            this.choosePictureButton.Name = "choosePictureButton";
            this.choosePictureButton.Size = new System.Drawing.Size(147, 53);
            this.choosePictureButton.TabIndex = 1;
            this.choosePictureButton.Text = "Выбор изображения";
            this.choosePictureButton.UseVisualStyleBackColor = true;
            this.choosePictureButton.Click += new System.EventHandler(this.ChoosePictureButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(663, 150);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(147, 53);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Готово";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(6, 18);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(43, 17);
            this.pathLabel.TabIndex = 3;
            this.pathLabel.Text = "Путь:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.pathLabel);
            this.groupBox1.Controls.Add(this.choosePictureButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 209);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // ChoosePictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitButton);
            this.Name = "ChoosePictureForm";
            this.Text = "Выбор";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button choosePictureButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}