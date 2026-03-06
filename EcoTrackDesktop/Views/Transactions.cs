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
                new string[] { "Id", "Customer Name", "Category", "Weight", "Total Price", "Date Time" },
                new string[] { "Id", "CustomerName", "CategoryName", "WeightKG", "TotalPriceRp", "Date" },
                table1
            );
            RefreshData();
        }

        public void RefreshData(string src = "")
        {
            var query = dbc.Transactions.AsQueryable();
            if(src.Trim() != "")
            {
                query = query.Where(u => u.User.FullName.Contains(src) || u.User.Username.Contains(src));
            }
            table1.DataSource = query.Include(t => t.User).Include(t => t.Category).OrderByDescending(t => t.Date).ToList();
        }

        private void onCellClicked(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void onTrySearch(object sender, EventArgs e)
        {
            RefreshData(search.Text);
        }

    }
}
