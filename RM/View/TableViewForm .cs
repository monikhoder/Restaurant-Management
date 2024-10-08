
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
    public partial class TableViewForm : Form
    {
        public TableViewForm()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           loadTables();
        }
        private void loadTables()
        {
            dgvTableList.Rows.Clear();

            // Get the search text and convert it to lower for case-insensitive search
            string searchText = txtSearch.Text.ToLower();

            // Use LINQ to filter the categories based on partial match
            var filteredTable = MainClass.db.Tables
                .Where(t => t.TableName.ToLower().Contains(searchText))
                .ToList();



            foreach (Table table in filteredTable)
            {
                dgvTableList.Rows.Add(

                    table.TableId.ToString(),
                    table.TableName,
                    table.Created.ToString(),
                    table.Updated.ToString()
                );

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TableAdd add = new TableAdd();
            add.ShowDialog();
            loadTables();
           
        }

        private void TableViewForm_Load(object sender, EventArgs e)
        {
            loadTables();
        }

        private void dgvTableList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(dgvTableList.CurrentRow.Cells[0].Value);
            string Name = dgvTableList.CurrentRow.Cells[1].Value.ToString();
            if (dgvTableList.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                TableAdd update = new TableAdd();
                update.txtName.Text = Name;
                update.lblHeader.Text = "Update Category Name";
                update.TableId = Id;
                update.ShowDialog();
                loadTables();
            }
            else if (dgvTableList.CurrentCell.OwningColumn.Name == "dgvDelete")
            {

                Guna2MessageDialog confirm = new Guna2MessageDialog();
                confirm.Icon = MessageDialogIcon.Question;
                confirm.Buttons = MessageDialogButtons.YesNo;
                confirm.Style = MessageDialogStyle.Light;
                confirm.Parent = Form.ActiveForm;
                confirm.Text = $"Are you sure you want to delete {Name} from table?";

                //ConfirmMessage.Parent.StartPosition = FormStartPosition.CenterParent;
                if (confirm.Show() == DialogResult.Yes)
                {
                    var table = MainClass.db.Tables.FirstOrDefault(c => c.TableId == Id);
                    MainClass.db.Tables.Remove(table);
                    MainClass.db.SaveChanges();
                    loadTables();
                }

            }
        }
    }
}
