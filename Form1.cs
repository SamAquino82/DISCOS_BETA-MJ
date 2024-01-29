using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_beta_discos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Discos> discos = new List<Discos>();
        private void Form1_Load(object sender, EventArgs e)
        {
            NegocioDiscos negocio = new NegocioDiscos();
            discos = negocio.listar();
            dgv1.DataSource = discos;
            pictureBox1.Load(discos[0].imagen);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgv1.CurrentRow.DataBoundItem;
            pictureBox1.Load(seleccionado.imagen);
        }
    }
}
