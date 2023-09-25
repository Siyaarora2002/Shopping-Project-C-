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
    public partial class ordersForm : Form
    {
        public ordersForm()
        {
            InitializeComponent();
        }

        async private void ordersForm_Load(object sender, EventArgs e)
        {
            string response = await State.UpdateOrdersTable(ordersDataGridView);

            if (response == "NOT_CONNECTED")
            {
                MessageBox.Show("Cannot fetch orders without an active login.");
                this.Close();
                return;
            }

            if (response == "NOT_AVAILABLE")
            {
                MessageBox.Show("There are no client orders to view.");
                this.Close();
                return;
            }
        }
    }
}
