using EcoTrackDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoTrackDesktop.Views
{
    public partial class OfficerForms : Form
    {
        bool logout = false;
        Main mainWindow;
        EcoTrackContext dbc;
        Timer timer;
        public OfficerForms(Main _mainWindow, EcoTrackContext ctx)
        {
            dbc = ctx;
            timer = new Timer();
            mainWindow = _mainWindow;
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += updateTimeLb;
            timer.Start();
            updateTimeLb(null, null);
        }
        private void updateTimeLb(object sender, EventArgs e)
        {
            timeLb.Text = DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss");
        }

        private void onLogout(object sender, EventArgs e)
        {
            logout = true;
            mainWindow.Show();
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!logout) mainWindow.Close();
        }

        private void onUser(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new Users(dbc));
        }

        private void onCategory(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new SellRecyclables(dbc));
        }

        private void onTransactions(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new Transactions(dbc));
        }
    }
}
