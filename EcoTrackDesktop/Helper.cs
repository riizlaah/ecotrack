using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoTrackDesktop
{
    public class Helper
    {
        public static void GenTableColumns(string[] columnsName, string[] bindings, DataGridView table)
        {
            table.AutoGenerateColumns = false;
            for (int i = 0; i < columnsName.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = columnsName[i];
                col.HeaderText = columnsName[i];
                col.DataPropertyName = bindings[i];
                col.ReadOnly = true;
                table.Columns.Add(col);
            }
        }
    }
}
