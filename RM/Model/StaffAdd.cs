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

namespace RM
{
    public partial class StaffAdd : Form
    {
        public int StaffId = 0;
        public StaffAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Isvaliusername(txtUsername.Text) == true)
            {
                user users = new user();
                users.uName = txtName.Text;
                users.username = txtUsername.Text;
                users.uRole = comboRole.Text;
                users.uPhone = txtPhone.Text;
                users.upass = "123";
                users.created = DateTime.Now;
                users.updated = DateTime.Now;
                if (checkStatus.Checked == true)
                {
                    users.Status = 1;
                }
                else
                {
                    users.Status = 0;
                }
                MainClass.db.users.Add(users);
                MainClass.db.SaveChanges();
                this.Close();
            }else
            {
                Guna2MessageDialog alert = new Guna2MessageDialog();
                alert.Icon = MessageDialogIcon.Error;
                alert.Style = MessageDialogStyle.Light;
                alert.Text = "Username already exists";
                alert.Parent = this;
                alert.Show();
                txtUsername.Clear();
            }
            
        }
        private void checkField()
        {
            if (txtName.Text == "" || txtUsername.Text == "" || comboRole.Text == "" || txtPhone.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void StaffAdd_Load(object sender, EventArgs e)
        {
            checkField();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            checkField();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            checkField();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            checkField();
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkField();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }
        }
    }
}

