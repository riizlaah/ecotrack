using EcoTrackDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EcoTrackDesktop.Views
{

    public partial class Transactions : UserControl
    {
        bool editing = false;
        EcoTrackContext dbc;
        public Transactions(EcoTrackContext ctx)
        {
            dbc = ctx;
            InitializeComponent();
            Helper.GenTableColumns(
                new string[] { "Customer Name", "Category", "Weight", "Total Price", "Date Time" },
                new string[] { "CustomerName", "CategoryName", "WeightKG", "TotalPriceRp", "Date" },
                table1
            );
            RefreshData();
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now.AddDays(7);
        }

        public void RefreshData(string src = "")
        {
            var query = dbc.Transactions.AsQueryable();
            if(src.Trim() != "")
            {
                query = query.Where(u => u.User.FullName.Contains(src) || u.User.Username.Contains(src) || u.Category.Name.Contains(src));
            }
            if(todayOpt.Checked)
            {
                query = query.Where(t => DbFunctions.TruncateTime(t.Date) == DbFunctions.TruncateTime(DateTime.Today));
            } else
            {
                query = query.Where(t => DbFunctions.TruncateTime(t.Date) >= DbFunctions.TruncateTime(startDate.Value) && DbFunctions.TruncateTime(t.Date) <= DbFunctions.TruncateTime(endDate.Value));
            }
            table1.DataSource = query.Include(t => t.User).Include(t => t.Category).OrderByDescending(t => t.Date).ToList();
        }

        private void onTrySearch(object sender, EventArgs e)
        {
            RefreshData(search.Text);
        }

        private void onTodayCheckedChanged(object sender, EventArgs e)
        {
            if(todayOpt.Checked)
            {
                dateRangeInput.Hide();
                RefreshData();
            }
        }

        private void onDateRangeCheckedChanged(object sender, EventArgs e)
        {
            if(dateRangeOpt.Checked)
            {
                dateRangeInput.Show();
                RefreshData();
            }
        }

        private void onStartDateChanged(object sender, EventArgs e)
        {
            if (todayOpt.Checked) return;
            if (startDate.Value > endDate.Value)
            {
                endDate.Value = startDate.Value.AddDays(1);
            }
            RefreshData();
        }

        private void onEndDateChanged(object sender, EventArgs e)
        {
            if (todayOpt.Checked) return;
            if (endDate.Value < startDate.Value)
            {
                endDate.Value = startDate.Value.AddDays(1);
            }
            RefreshData();
        }
    }
}
