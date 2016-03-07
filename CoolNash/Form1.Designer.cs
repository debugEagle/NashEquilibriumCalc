namespace CoolNash
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
            this.label1 = new System.Windows.Forms.Label();
            this.NashButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SBstack = new System.Windows.Forms.TextBox();
            this.BBstack = new System.Windows.Forms.TextBox();
            this.SBbox = new System.Windows.Forms.TextBox();
            this.BBbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IterNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // NashButton
            // 
            this.NashButton.Location = new System.Drawing.Point(12, 12);
            this.NashButton.Name = "NashButton";
            this.NashButton.Size = new System.Drawing.Size(89, 53);
            this.NashButton.TabIndex = 2;
            this.NashButton.Text = "Calculate Nash";
            this.NashButton.UseVisualStyleBackColor = true;
            this.NashButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 187);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(199, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // SBstack
            // 
            this.SBstack.Location = new System.Drawing.Point(162, 12);
            this.SBstack.Name = "SBstack";
            this.SBstack.Size = new System.Drawing.Size(61, 20);
            this.SBstack.TabIndex = 4;
            this.SBstack.Text = "300";
            // 
            // BBstack
            // 
            this.BBstack.Location = new System.Drawing.Point(162, 38);
            this.BBstack.Name = "BBstack";
            this.BBstack.Size = new System.Drawing.Size(61, 20);
            this.BBstack.TabIndex = 5;
            this.BBstack.Text = "300";
            // 
            // SBbox
            // 
            this.SBbox.Location = new System.Drawing.Point(294, 12);
            this.SBbox.Name = "SBbox";
            this.SBbox.Size = new System.Drawing.Size(61, 20);
            this.SBbox.TabIndex = 6;
            this.SBbox.Text = "20";
            // 
            // BBbox
            // 
            this.BBbox.Location = new System.Drawing.Point(294, 38);
            this.BBbox.Name = "BBbox";
            this.BBbox.Size = new System.Drawing.Size(61, 20);
            this.BBbox.TabIndex = 7;
            this.BBbox.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SB stack:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "BB stack:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SB:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "BB:";
            // 
            // IterNumber
            // 
            this.IterNumber.Location = new System.Drawing.Point(393, 31);
            this.IterNumber.Name = "IterNumber";
            this.IterNumber.Size = new System.Drawing.Size(61, 20);
            this.IterNumber.TabIndex = 12;
            this.IterNumber.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "number of iterations:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 210);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IterNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BBbox);
            this.Controls.Add(this.SBbox);
            this.Controls.Add(this.BBstack);
            this.Controls.Add(this.SBstack);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.NashButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Nash Calculator by Taras Petruk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NashButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox SBstack;
        private System.Windows.Forms.TextBox BBstack;
        private System.Windows.Forms.TextBox SBbox;
        private System.Windows.Forms.TextBox BBbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IterNumber;
        private System.Windows.Forms.Label label6;
    }
}

