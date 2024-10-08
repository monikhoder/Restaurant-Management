
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
    public partial class CategoryViewForm : Form
    {
        public CategoryViewForm()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadCategories();
        }

       

        private void CategoryViewForm_Load(object sender, EventArgs e)
        {
            loadCategories();
        }
        private void loadCategories()
        {
            dgvCategoriesList.Rows.Clear();

            // Get the search text and convert it to lower for case-insensitive search
            string searchText = txtSearch.Text.ToLower();

            // Use LINQ to filter the categories based on partial match
            var filteredCategories = MainClass.db.Categories
                .Where(category => category.CategoryName.ToLower().Contains(searchText))
                .ToList();

            

            foreach (Category category in filteredCategories)
            {
                dgvCategoriesList.Rows.Add(
                 
                    category.CategoryId.ToString(),
                    category.CategoryName,
                    category.Created.ToString(),
                    category.Updated.ToString()
                );
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            CategoryAdd sampleAdd = new CategoryAdd();
            sampleAdd.ShowDialog();
            loadCategories();
        }

        private void dgvCategoriesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(dgvCategoriesList.CurrentRow.Cells[0].Value);
            string Name = dgvCategoriesList.CurrentRow.Cells[1].Value.ToString();
            if (dgvCategoriesList.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                CategoryAdd update = new CategoryAdd();
                update.txtName.Text = Name;
                update.lblHeader.Text = "Update Category Name";
                update.CategoryId = Id;
                update.ShowDialog();
                loadCategories();
            }
            else if (dgvCategoriesList.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                var category = MainClass.db.Categories.FirstOrDefault(c => c.CategoryId == Id);
                if (category != null)
                {
                    // Show a confirmation dialog
                    var confirmResult = MessageBox.Show(
                        $"Are you sure you want to delete {Name} from category?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    // If the user clicks "Yes", proceed with the delete
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Remove the entity
                        MainClass.db.Categories.Remove(category);

                        // Save changes to commit the deletion
                        MainClass.db.SaveChanges();

                       // MessageBox.Show("Category deleted successfully.");
                        loadCategories();
                    }
                }
            }
        }
    }
}
