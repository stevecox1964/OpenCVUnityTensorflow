namespace WinFormProject
{
    partial class Form1
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
            this.pictureBoxInputImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxTFOutput = new System.Windows.Forms.TextBox();
            this.btnPInvoke = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInputImage
            // 
            this.pictureBoxInputImage.Location = new System.Drawing.Point(9, 61);
            this.pictureBoxInputImage.Name = "pictureBoxInputImage";
            this.pictureBoxInputImage.Size = new System.Drawing.Size(288, 212);
            this.pictureBoxInputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxInputImage.TabIndex = 3;
            this.pictureBoxInputImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Outout";
            // 
            // txtBoxTFOutput
            // 
            this.txtBoxTFOutput.Location = new System.Drawing.Point(303, 61);
            this.txtBoxTFOutput.Multiline = true;
            this.txtBoxTFOutput.Name = "txtBoxTFOutput";
            this.txtBoxTFOutput.Size = new System.Drawing.Size(291, 212);
            this.txtBoxTFOutput.TabIndex = 15;
            // 
            // btnPInvoke
            // 
            this.btnPInvoke.Location = new System.Drawing.Point(12, 12);
            this.btnPInvoke.Name = "btnPInvoke";
            this.btnPInvoke.Size = new System.Drawing.Size(113, 23);
            this.btnPInvoke.TabIndex = 16;
            this.btnPInvoke.Text = "Object Detect";
            this.btnPInvoke.UseVisualStyleBackColor = true;
            this.btnPInvoke.Click += new System.EventHandler(this.btnPInvoke_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 331);
            this.Controls.Add(this.btnPInvoke);
            this.Controls.Add(this.txtBoxTFOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxInputImage);
            this.Name = "Form1";
            this.Text = "DeepLab";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxInputImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxTFOutput;
        private System.Windows.Forms.Button btnPInvoke;
    }
}

