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
    public partial class frmString : Form
    {
        public string Item { get; set; }

        public frmString()
        {
            InitializeComponent();
            Item = string.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtString.Text == string.Empty)
            {
                MessageBox.Show("Preeencha Alguma coisa na String", "Buuuro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Item = Fonetico.Fonetico.RemoverCaracterEspeciais(Fonetico.Fonetico.RemoverAcentos(txtString.Text.ToUpper()), ' ');
            if (Item.Contains(" "))
            {
                MessageBox.Show("Uma StopWord não pode conter espaço ou caracteres especiais", "Buuuro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo deletar esta StopWord?", "Não Faz Merda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void frmString_Load(object sender, EventArgs e)
        {
            if (Item != string.Empty)
            {
                btnDeletar.Enabled = true;
                txtString.Text = Item;
            }
        }
    }
}
