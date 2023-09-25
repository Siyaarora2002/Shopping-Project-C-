
namespace Client
{
    partial class purchaseForm
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
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usertextBox = new System.Windows.Forms.TextBox();
            this.headingLabel = new System.Windows.Forms.Label();
            this.purchaseLabel = new System.Windows.Forms.Label();
            this.purchaseBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chosenLabel = new System.Windows.Forms.Label();
            this.chosenTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.AllowUserToOrderColumns = true;
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.qty});
            this.productsDataGridView.Enabled = false;
            this.productsDataGridView.Location = new System.Drawing.Point(35, 49);
            this.productsDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.RowHeadersWidth = 51;
            this.productsDataGridView.Size = new System.Drawing.Size(303, 161);
            this.productsDataGridView.TabIndex = 1;
            // 
            // name
            // 
            this.name.HeaderText = "Product Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 125;
            // 
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 125;
            // 
            // usertextBox
            // 
            this.usertextBox.Location = new System.Drawing.Point(151, 260);
            this.usertextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(185, 22);
            this.usertextBox.TabIndex = 2;
            this.usertextBox.TextChanged += new System.EventHandler(this.usertextBox_TextChanged);
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.headingLabel.Location = new System.Drawing.Point(128, 11);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(109, 29);
            this.headingLabel.TabIndex = 3;
            this.headingLabel.Text = "Inventory";
            // 
            // purchaseLabel
            // 
            this.purchaseLabel.AutoSize = true;
            this.purchaseLabel.Location = new System.Drawing.Point(22, 260);
            this.purchaseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.purchaseLabel.Name = "purchaseLabel";
            this.purchaseLabel.Size = new System.Drawing.Size(121, 17);
            this.purchaseLabel.TabIndex = 4;
            this.purchaseLabel.Text = "Choose a Product";
            // 
            // purchaseBtn
            // 
            this.purchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.purchaseBtn.Location = new System.Drawing.Point(39, 518);
            this.purchaseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.purchaseBtn.Name = "purchaseBtn";
            this.purchaseBtn.Size = new System.Drawing.Size(299, 111);
            this.purchaseBtn.TabIndex = 5;
            this.purchaseBtn.Text = "Purchase";
            this.purchaseBtn.UseVisualStyleBackColor = true;
            this.purchaseBtn.Click += new System.EventHandler(this.purchaseBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 143);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(11, 10);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chosenLabel
            // 
            this.chosenLabel.AutoSize = true;
            this.chosenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chosenLabel.Location = new System.Drawing.Point(48, 303);
            this.chosenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chosenLabel.Name = "chosenLabel";
            this.chosenLabel.Size = new System.Drawing.Size(74, 25);
            this.chosenLabel.TabIndex = 7;
            this.chosenLabel.Text = "Choice";
            // 
            // chosenTextBox
            // 
            this.chosenTextBox.Enabled = false;
            this.chosenTextBox.Location = new System.Drawing.Point(53, 332);
            this.chosenTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chosenTextBox.Multiline = true;
            this.chosenTextBox.Name = "chosenTextBox";
            this.chosenTextBox.Size = new System.Drawing.Size(283, 132);
            this.chosenTextBox.TabIndex = 8;
            // 
            // purchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 655);
            this.Controls.Add(this.chosenTextBox);
            this.Controls.Add(this.chosenLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.purchaseBtn);
            this.Controls.Add(this.purchaseLabel);
            this.Controls.Add(this.headingLabel);
            this.Controls.Add(this.usertextBox);
            this.Controls.Add(this.productsDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "purchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy lots of Fruits!";
            this.Load += new System.EventHandler(this.purchaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.TextBox usertextBox;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label purchaseLabel;
        private System.Windows.Forms.Button purchaseBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label chosenLabel;
        private System.Windows.Forms.TextBox chosenTextBox;
    }
}