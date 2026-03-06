using EcoTrackDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EcoTrackDesktop.Views
{

    public partial class Categories : UserControl
    {
        bool editing = false;
        EcoTrackContext dbc;
        public Categories(EcoTrackContext ctx)
        {
            dbc = ctx;
            InitializeComponent();
            Helper.GenTableColumns(
                new string[] { "Id", "Name", "PricePerKg" },
                new string[] { "Id", "Name", "PricePerKg" },
                table1
            );
            RefreshData();
        }

        public void RefreshData(string src = "")
        {
            var query = dbc.Categories.AsQueryable();
            if(src.Trim() != "")
            {
                query = query.Where(u => u.Name.Contains(src) || u.PricePerKg.ToString().Contains(src));
            }
            table1.DataSource = query.ToList();
        }

        private Category GetSelected()
        {
            return table1.SelectedRows[0].DataBoundItem as Category;
        }

        private void onCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            actionPanel.Show();
        }

        private void onInsertClicked(object sender, EventArgs e)
        {
            editing = false;
            actionPanel.Hide();
            saveNCancel.Show();
        }

        private void onSave(object sender, EventArgs e)
        {
            
            if(categoryName.Text.Trim() == "")
            {
                MessageBox.Show("Name can't be empty.");
                return;
            }
            if(!Decimal.TryParse(pricePerKG.Text, out decimal priceDecimal))
            {
                MessageBox.Show("Price not valid.");
                return;
            }
            if(priceDecimal < 1m)
            {
                MessageBox.Show("Price not valid.");
                return;
            }
            if (editing)
            {
                if (GetSelected() == null) {
                    onCancel(null, null);
                    return;
                }
                var user = dbc.Categories.Find(GetSelected().Id);
                user.Name = categoryName.Text;
                user.PricePerKg = priceDecimal;
            } else
            {
                dbc.Categories.Add(new Category
                {
                    Name = categoryName.Text,
                    PricePerKg = priceDecimal
                });
            }
            dbc.SaveChanges();
            RefreshData();
            onCancel(null, null);
        }

        private void onCancel(object sender, EventArgs e)
        {
            categoryName.Text = "";
            pricePerKG.Text = "";
            saveNCancel.Hide();
            editing = false;
            actionPanel.Hide();
        }

        private void onEdit(object sender, EventArgs e)
        {
            var entity = GetSelected();
            categoryName.Text = entity.Name;
            pricePerKG.Text = entity.PricePerKg.ToString();
            editing = true;
            saveNCancel.Show();
        }

        private void onDelete(object sender, EventArgs e)
        {
            if (GetSelected() == null)
            {
                onCancel(null, null);
                return;
            }
            var entity = GetSelected();
            if (MessageBox.Show($"Are you sure want to delete {entity.Name}?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            dbc.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            dbc.SaveChanges();
            RefreshData();
        }

        private void onTrySearch(object sender, EventArgs e)
        {
            RefreshData(search.Text);
        }

        private void onFilterChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
