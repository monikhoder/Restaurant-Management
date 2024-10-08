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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblLoginName.Text = $"Wellcome : {MainClass.USER}";
            AddControls(new HomeForm());
        }
        public void AddControls(Form form)
        {
            CenterPanel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            CenterPanel.Controls.Add(form);
            form.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new HomeForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
           AddControls(new View.CategoryViewForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //AddControls(new View.ProductViewForm());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new View.TableViewForm());
        }
    }
}
