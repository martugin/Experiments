using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grid.CurrentCell.ColumnIndex == 1)
            {
                var combo = e.Control as ComboBox;
                if (combo != null)
                    combo.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var cells = grid.Rows[grid.Rows.Add()].Cells;
            //var combo = ((DataGridViewComboBoxCell)cells[1]);
        }

        private void grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cell = grid.Rows[e.RowIndex].Cells[1];
            if (cell is DataGridViewComboBoxCell && !((DataGridViewComboBoxCell)cell).Items.Contains(e.FormattedValue))
                ((DataGridViewComboBoxCell)cell).Items.Add(e.FormattedValue);
        }
    }
}
