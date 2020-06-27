namespace lab5
{
    partial class DriveForm
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
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.NowSpeedLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(123, 258);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(19, 13);
            this.speedLabel.TabIndex = 0;
            this.speedLabel.Text = "50";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.LargeChange = 10;
            this.speedTrackBar.Location = new System.Drawing.Point(13, 186);
            this.speedTrackBar.Maximum = 120;
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(580, 45);
            this.speedTrackBar.TabIndex = 1;
            this.speedTrackBar.Value = 50;
            this.speedTrackBar.Scroll += new System.EventHandler(this.SpeedTrackBar_Scroll);
            // 
            // NowSpeedLabel
            // 
            this.NowSpeedLabel.AutoSize = true;
            this.NowSpeedLabel.Location = new System.Drawing.Point(12, 258);
            this.NowSpeedLabel.Name = "NowSpeedLabel";
            this.NowSpeedLabel.Size = new System.Drawing.Size(105, 13);
            this.NowSpeedLabel.TabIndex = 2;
            this.NowSpeedLabel.Text = "Текущее значение:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Скорость";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пройдено:";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(76, 9);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(13, 13);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "0";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(425, 245);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 280);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NowSpeedLabel);
            this.Controls.Add(this.speedTrackBar);
            this.Controls.Add(this.speedLabel);
            this.Name = "DriveForm";
            this.Text = "Тестирование";
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label NowSpeedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button startButton;
    }
}

