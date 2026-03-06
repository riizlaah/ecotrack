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

    public partial class SellRecyclables : UserControl
    {
        bool editing = false;
        EcoTrackContext dbc;
        User selectedUser = null;
        public SellRecyclables(EcoTrackContext ctx)
        {
            dbc = ctx;
            InitializeComponent();
            listBox1.DisplayMember = "PhoneWName";
            categories.DisplayMember = "Name";
            categories.DataSource = dbc.Categories.ToList();
        }

        private void onTrySell(object sender, EventArgs e)
        {
            if(!Decimal.TryParse(weight.Text, out decimal weightDecimal))
            {
                MessageBox.Show("Weight not valid.");
                return;
            }
            if(weightDecimal < 0.00001m)
            {
                MessageBox.Show("Weight too small.");
                return;
            }
            if(categories.SelectedIndex == -1)
            {
                MessageBox.Show("Category not valid.");
                return;
            }
            if(selectedUser == null)
            {
                MessageBox.Show("Customer not selected.");
                return;
            }
            var totalPrice = weightDecimal * (categories.SelectedItem as Category).PricePerKg;
            dbc.Users.Find(selectedUser.Id).Balance += totalPrice;
            dbc.Transactions.Add(new Transaction
            {
                UserId = selectedUser.Id,
                CategoryId = (categories.SelectedItem as Category).Id,
                Weight = weightDecimal,
                TotalPrice = totalPrice,
                Date = DateTime.Now,
            });
            dbc.SaveChanges();
            weight.Text = "";
            phoneNum.Text = "";
            categories.SelectedIndex = -1;
            MessageBox.Show("Transaction success.");
        }

        private void onAddNewCust(object sender, EventArgs e)
        {
            var res = new AddCustomer(dbc).ShowDialog();
            if (res == DialogResult.OK)
            {
                phoneNum.Text = dbc.lastUserPhoneNum;
                selectedUser = dbc.Users.Where(u => u.Phone == dbc.lastUserPhoneNum).First();
                extraInfo.Text = "Full Name: " + selectedUser.FullName;
                addNew.Enabled = false;
            }
        }

        private void onPhoneNumberChanged(object sender, EventArgs e)
        {
            if(phoneNum.Text.Trim() == "")
            {
                listBox1.Hide();
                return;
            }
            if(selectedUser != null)
            {
                if (phoneNum.Text != selectedUser.Phone)
                {
                    selectedUser = null;
                    extraInfo.Text = "No customer selected.";
                    addNew.Enabled = true;
                }
                else
                {
                    extraInfo.Text = $"Full Name : {selectedUser.FullName}";
                    addNew.Enabled = false;
                }
            }
            var users = dbc.Users.Where(u => u.Phone.Contains(phoneNum.Text) && u.Role == "customer").ToList();
            if(users.Count == 0)
            {
                listBox1.Hide(); return;
            }
            if (users.Count == 1 && users[0].Phone == phoneNum.Text)
            {
                selectedUser = users[0];
                listBox1.Hide();
                return;
            }
            ShowLists(users);
        }

        private void ShowLists(List<User> users)
        {
            listBox1.DataSource = users;
            listBox1.Show();
        }

        private void onPhoneNumKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                selectedUser = listBox1.SelectedItem as User;
                phoneNum.Text = selectedUser.Phone;
                listBox1.Hide();
            } else if(e.KeyCode == Keys.Down && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
            }
        }

        private void onListBoxKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                selectedUser = listBox1.SelectedItem as User;
                phoneNum.Text = selectedUser.Phone;
                listBox1.Hide();
            } else if(e.KeyCode == Keys.Up && listBox1.SelectedIndex == 0)
            {
                phoneNum.Focus();
            } else if(e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
            }
        }

        private void updatePreview()
        {
            if(!Decimal.TryParse(weight.Text, out decimal weightDec))
            {
                previewPrice.Text = "Rp0";
                return;
            }
            if(categories.SelectedIndex == -1)
            {
                previewPrice.Text = "Rp0";
                return;
            }
            var pricePerKg = (categories.SelectedItem as Category)?.PricePerKg ?? 0m;
            var totalPrice = weightDec * pricePerKg;
            previewPrice.Text = $"{pricePerKg:Rp#,##0;(Rp#,##0);Rp0} x {weightDec} KG = {totalPrice:Rp#,##0;(Rp#,##0);Rp0}";
        }

        private void onWeightChanged(object sender, EventArgs e)
        {
            updatePreview();
        }

        private void onCategoryChanged(object sender, EventArgs e)
        {
            updatePreview();
        }
    }
}
