using System;
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
            jugarSiVerifica(2);
        }

        private void jugarSiVerifica(int dificultad)
        {
            if (verificarNombre())
            {
                llamarJuegoConDificultad(dificultad);
            }
            MessageBox.Show("Por favor, ingresa o selecciona tu nombre");
        }

        private void btnMedio_Click(object sender, EventArgs e)
        {
            jugarSiVerifica(3);
        }

        private void btnDificil_Click(object sender, EventArgs e)
        {
            jugarSiVerifica(4);
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

        private bool verificarNombre()
        {
            return cmbNombre.Text.Length != 0;
        }
    }
}
