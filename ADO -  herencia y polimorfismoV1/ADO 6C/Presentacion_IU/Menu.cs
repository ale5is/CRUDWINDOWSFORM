using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_IU
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void gestionarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipo ofre = new FrmEquipo();
            ofre.MdiParent = this;
            ofre.Show();

        }
    }
}
