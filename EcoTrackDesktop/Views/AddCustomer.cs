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

namespace EcoTrackDesktop.Views
{
    public partial class AddCustomer : Form
    {
        EcoTrackContext dbc;
        public AddCustomer(EcoTrackContext ctx)
        {
            dbc = ctx;
            InitializeComponent();
        }

        private void onCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void onSave(object sender, EventArgs e)
        {
            if (username.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if (fullName.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if (!Regex.IsMatch(phoneNum.Text, @"^\+?\d+$"))
            {
                MessageBox.Show("Phone Number not valid.");
                return;
            }
            if (password.Text.Length < 6)
            {
                MessageBox.Show("Password must have 6 characters or more.");
                return;
            }
            dbc.Users.Add(new User
            {
                Username = username.Text,
                Password = Main.hash(password.Text),
                FullName = fullName.Text,
                Phone = phoneNum.Text,
                Role = "customer",
            });
            dbc.SaveChanges();
            dbc.lastUserPhoneNum = phoneNum.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
