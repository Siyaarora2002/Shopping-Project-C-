using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class purchaseForm : Form
    {
        DataGridView m_recentsTableHandle;
        DataGridView m_productsTableHandle;
        public purchaseForm()
        {
            InitializeComponent();
        }

        public purchaseForm(DataGridView productsTable, DataGridView recentsTable)
        {
            InitializeComponent();
            m_productsTableHandle = productsTable;
            m_recentsTableHandle = recentsTable;
        }

        private void purchaseForm_Load(object sender, EventArgs e)
        {
            State.UpdateProductsTable(productsDataGridView);
        }

        private void usertextBox_TextChanged(object sender, EventArgs e)
        {
            chosenTextBox.Text = string.Join("\r\n", State.PRODUCTS
                .Select(data => data.Item1)
                .Where(data => data.Contains(usertextBox.Text))
                ).ToUpper();
            if (chosenTextBox.Text.Length == 0)
                chosenTextBox.Text = "CUSTOM_CHOICE";
        }
        async private void purchaseBtn_Click(object sender, EventArgs e)
        {
            if (chosenTextBox.Text.Split('\r', '\n').Length > 1)
            {
                MessageBox.Show("You may purchase one Product at a time!");
                return;
            }
            string paramToSend = "CUSTOM_CHOICE\r\n" == chosenTextBox.Text ? usertextBox.Text.ToLower() : chosenTextBox.Text.Trim('\n', '\r').ToLower();
            string response = serverAPI.PURCHASE_TRANSACTION(paramToSend);

            if(response == "NOT_AVAILABLE")
            {
                MessageBox.Show("Out of stock");
                return;
            }


            if (response == "NOT_VALID")
            {
                MessageBox.Show("That product does not exist. Consider using our filter.");
                return;
            }

            if (response == "NOT_CONNECTED")
            {
                MessageBox.Show("You are not Logged in. Please Login again.");
                this.Close();
                return;
            }

            MessageBox.Show(response);
            // before closing update the products list and recents
            State.UpdateProductsTable(m_productsTableHandle);
            await State.UpdateRecentsTable(m_recentsTableHandle);
            this.Close();
        }
    }
}
