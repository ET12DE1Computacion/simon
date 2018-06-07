using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simon
{
    public partial class frmPuntaje : Form
    {
        DataTable tablaPuntaje;
        public frmPuntaje(DataTable unaTablaPuntaje)
        {
            InitializeComponent();
            tablaPuntaje = unaTablaPuntaje;
        }

        private void frmPuntaje_Shown(object sender, EventArgs e)
        {
            dgvVisor.DataSource = tablaPuntaje;
            dgvVisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
