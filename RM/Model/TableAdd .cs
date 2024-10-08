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
    public partial class TableAdd : Form
    {
        public int TableId = 0;
        public TableAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text != "" && TableId == 0 )
            {
                Table t = new Table();
                t.TableName = txtName.Text;
                t.Created = DateTime.Now;
                t.Updated = DateTime.Now;
                MainClass.db.Tables.Add(t);
                MainClass.db.SaveChanges();
                TableId = 0;
                this.Close();
            }else if (TableId != 0)
            {
                var table =  MainClass.db.Tables.FirstOrDefault(t => t.TableId == TableId);
                if(txtName.Text != "")
                {
                    table.TableName = txtName.Text;
                    table.Updated = DateTime.Now;
                    MainClass.db.SaveChanges();
                    TableId = 0;
                    this.Close();

                }

            }
            else
            {
                Guna2MessageDialog alert = new Guna2MessageDialog();
                alert.Icon = MessageDialogIcon.Error;
                alert.Text = "Please enter table name";
                alert.Style = MessageDialogStyle.Light;
                alert.Parent = this;
                alert.Show();
               
            }
        }
    }
}

