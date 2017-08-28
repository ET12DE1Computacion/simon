using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Simon
{
    public partial class frmJuego : Form
    {
        int areaJuego, ladoBoton, nroTurno, dificultad;
        List<Button> listaBotones;
        List<int> listaBotonesJugados;
        Random r;
        BackEnd backEnd;
        Thread hilo;
        ThreadStart delegadoHilo;

        public frmJuego(int unaDificultad, BackEnd unBackEnd)
        {
            InitializeComponent();
            areaJuego = this.Size.Height - 20;
            ladoBoton = areaJuego / unaDificultad;
            generarBotones(unaDificultad);
            listaBotonesJugados = new List<int>();
            r = new Random(DateTime.Now.Millisecond);
            nroTurno = 0;
            backEnd = unBackEnd;
            dificultad = unaDificultad;
            delegadoHilo = new ThreadStart(generarYPintar);
            hilo = new Thread(delegadoHilo);
        }

        private void generarBotones(int dificultad)
        {
            int cantidadBotones = 0;
            listaBotones = new List<Button>();

            for (int fila = 0; fila < dificultad; fila++)
            {
                for (int columna = 0; columna < dificultad; columna++)
                {
                    Button boton = new Button();
                    cantidadBotones++;
                    boton.Name = "btn"+cantidadBotones.ToString();
                    boton.Text = cantidadBotones.ToString();
                    boton.Location = new Point((this.Size.Width - areaJuego) / 2 + columna * ladoBoton, fila * ladoBoton);
                    boton.Size = new Size(ladoBoton, ladoBoton);
                    boton.BackColor = System.Drawing.Color.LightGray;
                    boton.MouseDown += new MouseEventHandler(this.boton_MouseDown);
                    boton.MouseUp += new MouseEventHandler(this.boton_MouseUp);
                    this.Controls.Add(boton);
                    listaBotones.Add(boton);
                }
            }
        }

        private void frmJuego_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            hilo.Start();
        }

        private void generarYPintar()
        {
            int numeroBoton = r.Next(0, listaBotones.Count);
            listaBotonesJugados.Add(numeroBoton);
            for (int i = 0; i < listaBotonesJugados.Count; i++)
            {
                pintarBoton(listaBotonesJugados[i], Color.Blue);
                Thread.Sleep(500);
                pintarBoton(listaBotonesJugados[i], Color.LightGray);
            }
        }

        private void pintarBoton(int nroBotonAPintar, System.Drawing.Color unColor, int tiempo )
        {
            if (this.InvokeRequired)
            {
                delegadoPintarBoton3 delegado = new delegadoPintarBoton3(pintarBoton);
                this.Invoke(delegado, new object[] { nroBotonAPintar, unColor, tiempo });
            }
            else
            {
                pintarBoton(nroBotonAPintar, unColor);
                System.Threading.Thread.Sleep(tiempo);
                pintarBoton(nroBotonAPintar, Color.LightGray);
                this.Refresh();
            }            
        }
        
        private void pintarBoton(int nroBotonAPintar, System.Drawing.Color unColor)
        {
            if (this.InvokeRequired)
            {
                delegadoPintarBoton2 delegado = new delegadoPintarBoton2(pintarBoton);
                this.Invoke(delegado, new object[] { nroBotonAPintar, unColor });
            }
            else
            {
                listaBotones[nroBotonAPintar].BackColor = unColor;
                this.Refresh();

            }
            
        }

        private delegate void delegadoPintarBoton2(int nroBotonAPintar, System.Drawing.Color unColor);
        private delegate void delegadoPintarBoton3(int nroBotonAPintar, System.Drawing.Color unColor, int tiempo);

        private void boton_MouseDown(object sender, EventArgs e)
        {
            if ((hilo.ThreadState != ThreadState.WaitSleepJoin)&&(hilo.ThreadState != ThreadState.Running))
            {
                
                 if (listaBotonesJugados[nroTurno]==int.Parse(((Button)sender).Text)-1)
                   {
                       pintarBoton(listaBotonesJugados[nroTurno], Color.LightGreen);                               
                   }
                else
                    {
                      pintarBoton(int.Parse(((Button)sender).Text) - 1, Color.Red, 600);
                      MessageBox.Show(string.Format("Perdiste, hiciste {0}  pts. en dificultad {1}. Te tocan {2} caramelos",
                      listaBotonesJugados.Count - 1, dificultad, (listaBotonesJugados.Count - 1)/5));
                      if ((dificultad>=2)&&(dificultad<=4))
                      {
                         backEnd.sumarPuntos(dificultad, listaBotonesJugados.Count-1);
                      }
                      Close();
                    }
            }
            else
            {
                MessageBox.Show("No hagas trampa, espera que termine la secuencia...");
                this.Close();
            }
        }

        private void boton_MouseUp(object sender, EventArgs e)
        {
            pintarBoton(listaBotonesJugados[nroTurno++], Color.LightGray);
            if (nroTurno == listaBotonesJugados.Count)
            {
                nroTurno = 0;
                hilo = new Thread(delegadoHilo);
                hilo.Start();
            }
        }

        private void boton_Click(object sender, EventArgs e)
        {
            if (listaBotonesJugados[nroTurno] == int.Parse(((Button)sender).Text) - 1)
            {
                pintarBoton(listaBotonesJugados[nroTurno], Color.LightGreen);
                nroTurno++;
                if (nroTurno == listaBotonesJugados.Count)
                {
                    nroTurno = 0;
                    hilo.Start();
                }
            }
            else
            {
                pintarBoton(listaBotonesJugados[nroTurno], Color.Red);
                MessageBox.Show("Perdiste, hiciste " + listaBotonesJugados.Count.ToString() + " pts.");
                Close();
            }
        }
    }
}