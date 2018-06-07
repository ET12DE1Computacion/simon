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
    public partial class frmMenu : Form
    {
        BackEnd backEnd;

        public frmMenu(BackEnd unBackEnd)
        {
            InitializeComponent();
            backEnd = unBackEnd;
            cargarListaJugadores();
        }

        private void btnFacil_Click(object sender, EventArgs e)
        {
            llamarJuegoConDificultad(2);
        }

        private void btnMedio_Click(object sender, EventArgs e)
        {
            llamarJuegoConDificultad(3);
        }

        private void btnDificil_Click(object sender, EventArgs e)
        {
            llamarJuegoConDificultad(4);
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            int dificultad;
            try
            {
                dificultad = int.Parse(txtDificultad.Text);
            }
            catch (InvalidCastException error)
            {
                MessageBox.Show("Solo se admiten numeros enteros capo ... ");
                return;
            }
            if (dificultad > 4)
            {
                llamarJuegoConDificultad(dificultad);
            }
        }

        private void llamarJuegoConDificultad(int dificultad)
        {
            if (cmbNombre.SelectedItem!=null)
            {
                backEnd.cargarJugador((int)cmbNombre.SelectedValue);
            }
            else
            {
                backEnd.altaJugador(cmbNombre.Text);
            }
            frmJuego juego = new frmJuego(dificultad, backEnd);
            juego.ShowDialog();
            cargarListaJugadores();
        }

        private void cargarListaJugadores()
        {
            cmbNombre.DataSource = backEnd.traerJugadores();
            cmbNombre.DisplayMember = "mostrar";
            cmbNombre.ValueMember = "id";
            cmbNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNombre.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbNombre.Text = "";
        }

        private void btnPuntaje_Click(object sender, EventArgs e)
        {
            frmPuntaje puntaje = new frmPuntaje(backEnd.traePuntaje());
            puntaje.ShowDialog();
        }
    }
}
