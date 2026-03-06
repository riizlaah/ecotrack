using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoTrackDesktop.Models;
using System.Security.Cryptography;
using EcoTrackDesktop.Views;

namespace EcoTrackDesktop
{
    public partial class Main : Form
    {
        private readonly EcoTrackContext dbc;
        Timer timer;
        public Main()
        {
            dbc = new EcoTrackContext();
            InitializeComponent();
            timer = new Timer();
            
        }

        

        private void onTryLogin(object sender, EventArgs e)
        {
            if(username.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            var user = dbc.Users.Where(u => u.Username ==  username.Text).FirstOrDefault();
            if (user != null)
            {
                if(!verifyHash(password.Text, user.Password))
                {
                    MessageBox.Show("Wrong username or password.");
                    return;
                }
                dbc.currUser = user;
                username.Text = "";
                password.Text = "";
                if(user.Role == "admin")
                {
                    var adminWindow = new AdminForms(this, dbc);
                    adminWindow.Show();
                    Hide();
                    return;
                } else if(user.Role == "officer")
                {
                    var officerWindow = new OfficerForms(this, dbc);
                    officerWindow.Show();
                    Hide();
                    return;
                }
                Close();
                return;
            }
            MessageBox.Show("Wrong username or password.");
        }

        public static string hash(string input)
        {
            using(var alg = SHA256.Create())
            {
                byte[] hashBytes = alg.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach(var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private bool verifyHash(string input, string hashedStr)
        {
            var hashedInput = hash(input);
            return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hashedStr) == 0;
        }
    }
}
