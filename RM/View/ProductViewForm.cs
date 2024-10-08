
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.View
{
    public partial class ProductViewForm : Form
    {
        public ProductViewForm()
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
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

         
        }
    }
}
