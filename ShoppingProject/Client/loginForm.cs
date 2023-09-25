using System;
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

    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        private void loginForm_Load(object sender, EventArgs e)
        {
            hostIPTextBox.Text = State.HOST_IP = "127.0.0.1";
            State.HOST_PORT = 55055;
        }

        // we should attempt to connect to the server
        async private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // ensure that account number is a valid number
                if (!Int32.TryParse(accNoTextBox.Text, out State.ACCOUNT_NUMBER))
                {
                    MessageBox.Show("Invalid Account Number. Please Try Again!");
                    return;
                }

                string response = await serverAPI.Connect();

                if (response == "CONNECT_ERROR")
                {
                    MessageBox.Show("The client's connection attempt is unsuccessful. The account_no is not valid.");
                    return;
                }

                if (response == "CONNECTION_EXISTS")
                {
                    MessageBox.Show("You're already logged in!");
                    productsForm open = new productsForm();
                    open.Show();
                    return;
                }

                MessageBox.Show(response);
                // if we made it here we can open the next window
                State.ACCOUNT_NAME = response.Split(':')[1];
                State.LOGGED_IN = true;
                productsForm form = new productsForm();
                form.Show();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}

