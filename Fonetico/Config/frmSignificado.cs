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
    public partial class frmSignificado : Form
    {
        public Fonetico.SIGNIFICADO Item { get; set; }

        public bool FlagComposto { get; set; }

        public frmSignificado()
        {
            InitializeComponent();
            Item = null;
            FlagComposto = false;
        }

        private void frmSignificado_Load(object sender, EventArgs e)
        {
            if (Item != null)
            {
                btnDeletar.Enabled = true;
                txtChave.Text = Item.CHAVE;
                txtValor.Text = Item.VALOR;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo deletar esta StopWord?", "Não Faz Merda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((txtChave.Text == string.Empty) || (txtValor.Text == string.Empty))
            {
                MessageBox.Show("Preeencha Alguma coisa nos Campos", "Buuuro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string chave = Fonetico.Fonetico.RemoverCaracterEspeciais(Fonetico.Fonetico.RemoverAcentos(txtChave.Text.ToUpper()), ' ');
            string valor = Fonetico.Fonetico.RemoverCaracterEspeciais(Fonetico.Fonetico.RemoverAcentos(txtValor.Text.ToUpper()), ' ');
            if (!FlagComposto)
            {
                if ((chave.Contains(" ")) || (valor.Contains(" ")))
                {
                    MessageBox.Show("Este significado não pode ter espaço ou caracteres especiais", "Buuuro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Item == null)
            {
                Item = new Fonetico.SIGNIFICADO();
            }
            Item.CHAVE = chave;
            Item.VALOR = valor;
            DialogResult = DialogResult.OK;
        }
    }
}
