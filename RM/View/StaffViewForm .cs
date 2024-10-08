
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.View
{
    public partial class StaffViewForm : Form
    {
        public StaffViewForm()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadStaff();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
           StaffAdd add = new StaffAdd();
            add.ShowDialog();
           
        }

        private void StaffViewForm_Load(object sender, EventArgs e)
        {
            loadStaff();
        }
        private void loadStaff()
        {
            dgvStaffList.Rows.Clear();

            // Get the search text and convert it to lower for case-insensitive search
            string searchText = txtSearch.Text.ToLower();

            // Use LINQ to filter the categories based on partial match
            var filteredTable = MainClass.db.users
                .Where(u => u.uName.ToLower().Contains(searchText))
                .ToList();



            foreach (user users in filteredTable)
            {
                dgvStaffList.Rows.Add(

                    users.userID.ToString(),
                    users.uName.ToString(),
                    users.uRole.ToString(),
                    users.uPhone.ToString(),
                    users.created.ToShortDateString(),
                    users.updated.ToShortDateString()
                );

            }

        }
    }
}
