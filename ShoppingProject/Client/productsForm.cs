using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class productsForm : Form
    {
        ArrayList productsList;
        public productsForm()
        {
            InitializeComponent();
        }

        private void productsForm_Load(object sender, EventArgs e)
        {
            userInfoLabel.Text = $"Username:<{State.ACCOUNT_NAME}> Account Number: {State.ACCOUNT_NUMBER}";
            // retrieve product data
            getProducts();
        }

        async private void getProducts()
        {
            if (await serverAPI.GET_PRODUCTS() == "NOT_CONNECTED")
            {
                MessageBox.Show("Cannot fetch products without an active login.");
                return;
            }
            State.UpdateProductsTable(productsDataGridView);
        }
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            if (State.LOGGED_IN)
            {
                serverAPI.Disconnect();
                State.LOGGED_IN = false;
                MessageBox.Show("Logging out from Server.");
                this.Close();
                return;
            }

            MessageBox.Show("You're already Logged Out.");

        }

        private void productsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (State.LOGGED_IN)
            {
                serverAPI.Disconnect();
            }
        }

        private void purchaseBtn_Click(object sender, EventArgs e)
        {
            purchaseForm form = new purchaseForm(productsDataGridView, recentsDataGridView);
            form.Show();
        }

        private void viewOrdersBtn_Click(object sender, EventArgs e)
        {
            ordersForm form = new ordersForm();
            form.Show();
        }

        async private void updateBtn_Click(object sender, EventArgs e)
        {
            State.UpdateProductsTable(productsDataGridView);
            await State.UpdateRecentsTable(recentsDataGridView);
        }
    }
}
