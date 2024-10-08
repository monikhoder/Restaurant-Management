using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txbUsername.Text == "" || txbUsername == null)
            {
                Guna2MessageDialog alert = new Guna2MessageDialog();
                alert.Icon = MessageDialogIcon.Error;
                alert.Text = "Username is required";
                alert.Style = MessageDialogStyle.Light;
                alert.Parent = this;
                alert.Show();
            }else if(txbPassword.Text == "" || txbPassword == null)
            {
                Guna2MessageDialog alert = new Guna2MessageDialog();
                alert.Icon = MessageDialogIcon.Error;
                alert.Text = "Password is required";
                alert.Style = MessageDialogStyle.Light;
                alert.Parent = this;
                alert.Show();
            }
            else
            {

                if (MainClass.Isvaliuser(txbUsername.Text, txbPassword.Text) == false)
                {
                    Guna2MessageDialog alert = new Guna2MessageDialog();
                    alert.Icon = MessageDialogIcon.Error;
                    alert.Text = "Invalid username or password";
                    alert.Style = MessageDialogStyle.Light;
                    alert.Parent = this;
                    alert.Show();
                    return;
                }
                else
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }

            }



        }
    }
}
