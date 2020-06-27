namespace lab5
{
    partial class ChooseFactoryForm
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
            this.carRadioButton = new System.Windows.Forms.RadioButton();
            this.truckRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // carRadioButton
            // 
            this.carRadioButton.AutoSize = true;
            this.carRadioButton.Location = new System.Drawing.Point(9, 46);
            this.carRadioButton.Name = "carRadioButton";
            this.carRadioButton.Size = new System.Drawing.Size(138, 17);
            this.carRadioButton.TabIndex = 0;
            this.carRadioButton.TabStop = true;
            this.carRadioButton.Text = "Легковой автомобиль";
            this.carRadioButton.UseVisualStyleBackColor = true;
            this.carRadioButton.CheckedChanged += new System.EventHandler(this.CarRadioButton_CheckedChanged);
            // 
            // truckRadioButton
            // 
            this.truckRadioButton.AutoSize = true;
            this.truckRadioButton.Location = new System.Drawing.Point(9, 69);
            this.truckRadioButton.Name = "truckRadioButton";
            this.truckRadioButton.Size = new System.Drawing.Size(72, 17);
            this.truckRadioButton.TabIndex = 1;
            this.truckRadioButton.TabStop = true;
            this.truckRadioButton.Text = "Грузовик";
            this.truckRadioButton.UseVisualStyleBackColor = true;
            this.truckRadioButton.CheckedChanged += new System.EventHandler(this.TruckRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип транспорта:";
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(12, 108);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 3;
            this.chooseButton.Text = "Выбор";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // ChooseFactoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 157);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.truckRadioButton);
            this.Controls.Add(this.carRadioButton);
            this.Name = "ChooseFactoryForm";
            this.Text = "Транспорт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton carRadioButton;
        private System.Windows.Forms.RadioButton truckRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseButton;
    }
}