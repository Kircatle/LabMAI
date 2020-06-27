namespace lab8
{
    partial class BackFormcs
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
            this.redTrackPad = new System.Windows.Forms.TrackBar();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenTrackPad = new System.Windows.Forms.TrackBar();
            this.v = new System.Windows.Forms.Label();
            this.blueTrackPad = new System.Windows.Forms.TrackBar();
            this.blueLabel = new System.Windows.Forms.Label();
            this.changeBackButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackPad)).BeginInit();
            this.SuspendLayout();
            // 
            // redTrackPad
            // 
            this.redTrackPad.Location = new System.Drawing.Point(12, 38);
            this.redTrackPad.Maximum = 255;
            this.redTrackPad.Name = "redTrackPad";
            this.redTrackPad.Size = new System.Drawing.Size(600, 56);
            this.redTrackPad.TabIndex = 0;
            this.redTrackPad.Value = 1;
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(12, 18);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(34, 17);
            this.redLabel.TabIndex = 1;
            this.redLabel.Text = "Red";
            // 
            // greenTrackPad
            // 
            this.greenTrackPad.Location = new System.Drawing.Point(12, 122);
            this.greenTrackPad.Maximum = 255;
            this.greenTrackPad.Name = "greenTrackPad";
            this.greenTrackPad.Size = new System.Drawing.Size(600, 56);
            this.greenTrackPad.TabIndex = 2;
            this.greenTrackPad.Value = 1;
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(12, 97);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(48, 17);
            this.v.TabIndex = 3;
            this.v.Text = "Green";
            // 
            // blueTrackPad
            // 
            this.blueTrackPad.Location = new System.Drawing.Point(12, 199);
            this.blueTrackPad.Maximum = 255;
            this.blueTrackPad.Name = "blueTrackPad";
            this.blueTrackPad.Size = new System.Drawing.Size(600, 56);
            this.blueTrackPad.TabIndex = 4;
            this.blueTrackPad.Value = 1;
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(12, 179);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(36, 17);
            this.blueLabel.TabIndex = 5;
            this.blueLabel.Text = "Blue";
            // 
            // changeBackButton
            // 
            this.changeBackButton.Location = new System.Drawing.Point(702, 266);
            this.changeBackButton.Name = "changeBackButton";
            this.changeBackButton.Size = new System.Drawing.Size(86, 23);
            this.changeBackButton.TabIndex = 6;
            this.changeBackButton.Text = "изменить";
            this.changeBackButton.UseVisualStyleBackColor = true;
            this.changeBackButton.Click += new System.EventHandler(this.ChangeBackButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 266);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BackFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 310);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.changeBackButton);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.blueTrackPad);
            this.Controls.Add(this.v);
            this.Controls.Add(this.greenTrackPad);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.redTrackPad);
            this.Name = "BackFormcs";
            this.Text = "BackFormcs";
            this.Load += new System.EventHandler(this.BackFormcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redTrackPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackPad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar redTrackPad;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.TrackBar greenTrackPad;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.TrackBar blueTrackPad;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Button changeBackButton;
        private System.Windows.Forms.Button exitButton;
    }
}