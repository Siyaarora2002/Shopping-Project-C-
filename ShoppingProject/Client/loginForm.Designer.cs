
namespace Client
{
    partial class loginForm
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
            this.accNoTextBox = new System.Windows.Forms.TextBox();
            this.hostIPTextBox = new System.Windows.Forms.TextBox();
            this.accountNoLabel = new System.Windows.Forms.Label();
            this.hostIPLabel = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.headingLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accNoTextBox
            // 
            this.accNoTextBox.Location = new System.Drawing.Point(204, 65);
            this.accNoTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accNoTextBox.Name = "accNoTextBox";
            this.accNoTextBox.Size = new System.Drawing.Size(211, 22);
            this.accNoTextBox.TabIndex = 0;
            // 
            // hostIPTextBox
            // 
            this.hostIPTextBox.Location = new System.Drawing.Point(204, 97);
            this.hostIPTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hostIPTextBox.Name = "hostIPTextBox";
            this.hostIPTextBox.Size = new System.Drawing.Size(211, 22);
            this.hostIPTextBox.TabIndex = 1;
            // 
            // accountNoLabel
            // 
            this.accountNoLabel.AutoSize = true;
            this.accountNoLabel.Location = new System.Drawing.Point(73, 65);
            this.accountNoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountNoLabel.Name = "accountNoLabel";
            this.accountNoLabel.Size = new System.Drawing.Size(81, 17);
            this.accountNoLabel.TabIndex = 2;
            this.accountNoLabel.Text = "Account No";
            // 
            // hostIPLabel
            // 
            this.hostIPLabel.AutoSize = true;
            this.hostIPLabel.Location = new System.Drawing.Point(73, 106);
            this.hostIPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hostIPLabel.Name = "hostIPLabel";
            this.hostIPLabel.Size = new System.Drawing.Size(109, 17);
            this.hostIPLabel.TabIndex = 3;
            this.hostIPLabel.Text = "IP Address/Host";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(316, 144);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(100, 28);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.Location = new System.Drawing.Point(16, 11);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(427, 25);
            this.headingLabel.TabIndex = 5;
            this.headingLabel.Text = "Welcome, to the simple client/server application.";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(16, 171);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(124, 17);
            this.authorLabel.TabIndex = 6;
            this.authorLabel.Text = "Author: Siya Arora";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 198);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.headingLabel);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.hostIPLabel);
            this.Controls.Add(this.accountNoLabel);
            this.Controls.Add(this.hostIPTextBox);
            this.Controls.Add(this.accNoTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accNoTextBox;
        private System.Windows.Forms.TextBox hostIPTextBox;
        private System.Windows.Forms.Label accountNoLabel;
        private System.Windows.Forms.Label hostIPLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label authorLabel;
    }
}

