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

    public partial class Users : UserControl
    {
        bool editing = false;
        EcoTrackContext dbc;
        public Users(EcoTrackContext ctx)
        {
            dbc = ctx;
            InitializeComponent();
            Helper.GenTableColumns(
                new string[] { "Id", "Username", "Full Name", "Phone", "Role", "Balance" },
                new string[] { "Id", "Username", "FullName", "Phone", "Role", "Balance" },
                table1
            );
            roles.DataSource = new string[] { "customer", "officer", "admin" };
            roleFilters.DataSource = new string[] { "all", "customer", "officer", "admin" };
            roleFilters.SelectedIndex = 0;
            RefreshData();
            if(dbc.currUser.Role == "officer")
            {
                roles.SelectedIndex = 0;
                roleFilters.SelectedIndex = 1;
                roleFilters.Enabled = false;
                roles.Hide();
                roleLb.Hide();
                password.Hide();
                passwordLb.Hide();
            }
        }

        public void RefreshData(string src = "")
        {
            var query = dbc.Users.AsQueryable();
            
            if(src.Trim() != "")
            {
                query = query.Where(u => u.Username.Contains(src) || u.FullName.Contains(src));
            }
            if(dbc.currUser.Role == "officer")
            {
                table1.DataSource = query.Where(u => u.Role == "customer").ToList();
                return;
            }
            if(roleFilters.SelectedIndex == 0)
            {
                table1.DataSource = query.ToList();
            } else
            {
                table1.DataSource = query.Where(u => u.Role == roleFilters.SelectedItem.ToString()).ToList();
            }
        }

        private User GetSelected()
        {
            return table1.SelectedRows[0].DataBoundItem as User;
        }

        private void onCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            actionPanel.Show();
        }

        private void onInsertClicked(object sender, EventArgs e)
        {
            editing = false;
            passwordLb.Show();
            password.Show();
            actionPanel.Hide();
            saveNCancel.Show();
        }

        private void onSave(object sender, EventArgs e)
        {
            if(username.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if (fullName.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if(!Regex.IsMatch(phone.Text, @"^\+?\d+$"))
            {
                MessageBox.Show("Phone Number not valid.");
                return;
            }
            if(password.Text.Length < 6 && editing == false)
            {
                MessageBox.Show("Password must have 6 characters or more.");
                return;
            }
            if(roles.SelectedIndex < 0)
            {
                MessageBox.Show("Role not valid.");
                return;
            }
            if (editing)
            {
                if (GetSelected() == null) {
                    onCancel(null, null);
                    return;
                }
                var user = dbc.Users.Find(GetSelected().Id);
                if (dbc.Users.Any(u => u.Username == username.Text && u.Id != user.Id))
                {
                    MessageBox.Show("Username has been used.");
                    return;
                }
                user.Username = username.Text;
                if(password.Text != "")
                {
                    user.Password = Main.hash(password.Text);
                }
                user.FullName = fullName.Text;
                user.Phone = phone.Text;
                user.Role = roles.SelectedItem.ToString();
            } else
            {
                if(dbc.Users.Any(u => u.Username == username.Text))
                {
                    MessageBox.Show("Username has been used.");
                    return;
                }
                dbc.Users.Add(new User
                {
                    Username = username.Text,
                    Password = Main.hash(password.Text),
                    FullName = fullName.Text,
                    Phone = phone.Text,
                    Role = roles.SelectedItem.ToString(),
                });
            }
            dbc.SaveChanges();
            RefreshData();
            onCancel(null, null);
        }

        private void onCancel(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
            if (dbc.currUser.Role == "officer")
            {
                password.Hide();
                passwordLb.Hide();
            }
            phone.Text = "";
            fullName.Text = "";
            roles.SelectedIndex = -1;
            saveNCancel.Hide();
            editing = false;
            actionPanel.Hide();
        }

        private void onEdit(object sender, EventArgs e)
        {
            var user = GetSelected();
            if (dbc.currUser.Role == "officer")
            {
                password.Hide();
                passwordLb.Hide();
            }
            username.Text = user.Username;
            fullName.Text = user.FullName;
            phone.Text = user.Phone;
            roles.SelectedItem = user.Role;
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
            if (MessageBox.Show($"Are you sure want to delete {entity.FullName}?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
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
