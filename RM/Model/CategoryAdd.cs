﻿using Guna.UI2.WinForms;
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
    public partial class CategoryAdd : Form
    {
        public int CategoryId = 0;
        public CategoryAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text != "" && CategoryId == 0 )
            {
                Category category = new Category();
                category.CategoryName = txtName.Text;
                category.Created = DateTime.Now;
                category.Updated = DateTime.Now;
                MainClass.db.Categories.Add(category);
                MainClass.db.SaveChanges();
                CategoryId = 0;
                this.Close();
            }else if (CategoryId != 0)
            {
                var category =  MainClass.db.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
                if(txtName.Text != "")
                {
                    category.CategoryName = txtName.Text;
                    category.Updated = DateTime.Now;
                    MainClass.db.SaveChanges();
                    CategoryId = 0;
                    this.Close();

                }

            }
            else
            {
                Guna2MessageDialog alert = new Guna2MessageDialog();
                alert.Icon = MessageDialogIcon.Error;
                alert.Style = MessageDialogStyle.Light;
                alert.Text = "Please enter Category name";
                alert .Parent = this;
                alert.Show();
                
            }
        }
    }
}

