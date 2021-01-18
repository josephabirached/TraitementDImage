
namespace TraitementDimage
{
    partial class ThresholdPopup
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
            this.thresholdValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.high = new System.Windows.Forms.RadioButton();
            this.low = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(186, 56);
            this.thresholdValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(120, 20);
            this.thresholdValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter threshold values between 0 and 255";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // high
            // 
            this.high.AutoSize = true;
            this.high.Location = new System.Drawing.Point(130, 106);
            this.high.Name = "high";
            this.high.Size = new System.Drawing.Size(97, 17);
            this.high.TabIndex = 6;
            this.high.TabStop = true;
            this.high.Text = "Threshold High";
            this.high.UseVisualStyleBackColor = true;
            // 
            // low
            // 
            this.low.AutoSize = true;
            this.low.Location = new System.Drawing.Point(244, 106);
            this.low.Name = "low";
            this.low.Size = new System.Drawing.Size(95, 17);
            this.low.TabIndex = 7;
            this.low.TabStop = true;
            this.low.Text = "Threshold Low";
            this.low.UseVisualStyleBackColor = true;
            // 
            // ThresholdPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 230);
            this.Controls.Add(this.low);
            this.Controls.Add(this.high);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.thresholdValue);
            this.Name = "ThresholdPopup";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown thresholdValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton high;
        private System.Windows.Forms.RadioButton low;
    }
}