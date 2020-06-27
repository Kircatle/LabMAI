namespace lab6Fix
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
            this.components = new System.ComponentModel.Container();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.speedTrackBarLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.nameCarTextBox = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.nameCarLabel = new System.Windows.Forms.Label();
            this.acceptBox = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(6, 21);
            this.speedTrackBar.Maximum = 120;
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(619, 56);
            this.speedTrackBar.TabIndex = 0;
            this.speedTrackBar.Value = 1;
            this.speedTrackBar.Scroll += new System.EventHandler(this.SpeedTrackBar_Scroll);
            // 
            // speedTrackBarLabel
            // 
            this.speedTrackBarLabel.AutoSize = true;
            this.speedTrackBarLabel.Location = new System.Drawing.Point(20, 77);
            this.speedTrackBarLabel.Name = "speedTrackBarLabel";
            this.speedTrackBarLabel.Size = new System.Drawing.Size(85, 17);
            this.speedTrackBarLabel.TabIndex = 1;
            this.speedTrackBarLabel.Text = "Скорость: 1";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(713, 415);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(632, 415);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // nameCarTextBox
            // 
            this.nameCarTextBox.Location = new System.Drawing.Point(631, 40);
            this.nameCarTextBox.Name = "nameCarTextBox";
            this.nameCarTextBox.Size = new System.Drawing.Size(100, 22);
            this.nameCarTextBox.TabIndex = 5;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.nameCarLabel);
            this.groupBox.Controls.Add(this.acceptBox);
            this.groupBox.Controls.Add(this.nameCarTextBox);
            this.groupBox.Controls.Add(this.speedTrackBar);
            this.groupBox.Controls.Add(this.speedTrackBarLabel);
            this.groupBox.Location = new System.Drawing.Point(21, 276);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(767, 100);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            // 
            // nameCarLabel
            // 
            this.nameCarLabel.AutoSize = true;
            this.nameCarLabel.Location = new System.Drawing.Point(628, 21);
            this.nameCarLabel.Name = "nameCarLabel";
            this.nameCarLabel.Size = new System.Drawing.Size(130, 17);
            this.nameCarLabel.TabIndex = 7;
            this.nameCarLabel.Text = "Название машины";
            // 
            // acceptBox
            // 
            this.acceptBox.Location = new System.Drawing.Point(649, 68);
            this.acceptBox.Name = "acceptBox";
            this.acceptBox.Size = new System.Drawing.Size(75, 26);
            this.acceptBox.TabIndex = 6;
            this.acceptBox.Text = "Считать";
            this.acceptBox.UseVisualStyleBackColor = true;
            this.acceptBox.Click += new System.EventHandler(this.AcceptBox_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(688, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(27, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(310, 68);
            this.listBox1.TabIndex = 8;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(620, 15);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(58, 17);
            this.timeLabel.TabIndex = 9;
            this.timeLabel.Text = "Таймер";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Тестирование машин";
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label speedTrackBarLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox nameCarTextBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label nameCarLabel;
        private System.Windows.Forms.Button acceptBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label timeLabel;
    }
}

