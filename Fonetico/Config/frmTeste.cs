using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Config
{
    public partial class frmTeste : Form
    {
        public frmTeste()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            txtFonetico.Text = Fonetico.Fonetico.RetornaFonetico(txtTexto.Text).Trim();
            txtCodigo.Text = Fonetico.Fonetico.RetornaCodigoFonetico(txtTexto.Text);
        }
    }
}
