﻿namespace stardata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Commentary = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.EnterInf = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Commentary
            // 
            this.Commentary.Font = new System.Drawing.Font("Metropolis", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Commentary.Location = new System.Drawing.Point(247, 41);
            this.Commentary.Name = "Commentary";
            this.Commentary.Size = new System.Drawing.Size(1033, 652);
            this.Commentary.TabIndex = 0;
            this.Commentary.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Metropolis", 10.2F);
            this.button1.Location = new System.Drawing.Point(13, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create a new star";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // EnterInf
            // 
            this.EnterInf.Location = new System.Drawing.Point(24, 162);
            this.EnterInf.Name = "EnterInf";
            this.EnterInf.Size = new System.Drawing.Size(177, 34);
            this.EnterInf.TabIndex = 2;
            this.EnterInf.Text = "";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Metropolis", 10.2F);
            this.button2.Location = new System.Drawing.Point(13, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "GenXYZ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.EnterInf);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 720);
            this.panel2.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Metropolis", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(13, 663);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 45);
            this.button3.TabIndex = 7;
            this.button3.Text = "Shut Down";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Commentary);
            this.Font = new System.Drawing.Font("Metropolis Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "StarData";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Commentary;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox EnterInf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
    }
}
