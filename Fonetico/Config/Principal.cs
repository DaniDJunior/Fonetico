using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Config
{
    public partial class Principal : Form
    {

        public Fonetico.DICIONARIO dicUso = new Fonetico.DICIONARIO();

        public Principal()
        {
            InitializeComponent();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (ofdConfig.ShowDialog() == DialogResult.OK)
            {
                txtConfig.Text = "<add key=\"CaminhoFonetico\" value=\"" + ofdConfig.FileName + "\"/>";
                ConfigurationManager.AppSettings["CaminhoFonetico"] = ofdConfig.FileName;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (ofdConfig.ShowDialog() == DialogResult.OK)
            {
                txtConfig.Text = "<add key=\"CaminhoFonetico\" value=\"" + ofdConfig.FileName + "\"/>";
                ConfigurationManager.AppSettings["CaminhoFonetico"] = ofdConfig.FileName;
                dicUso = Fonetico.DICIONARIO.Open(ofdConfig.FileName);
                UpdateItens();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["CaminhoFonetico"].ToString() != string.Empty)
            {
                dicUso = Fonetico.DICIONARIO.Open(ConfigurationManager.AppSettings["CaminhoFonetico"].ToString());
            }
            UpdateItens();
        }

        private void UpdateItens()
        {
            lsvItens.Items.Clear();
            foreach (string i in dicUso.STOPWORD)
            {
                ListViewItem item = new ListViewItem(i);
                item.ImageIndex = 0;
                item.Tag = i;
                lsvItens.Items.Add(item);
            }
            foreach (Fonetico.SIGNIFICADO i in dicUso.SIGNIFICADOS)
            {
                ListViewItem item = new ListViewItem(i.CHAVE);
                item.ImageIndex = 1;
                item.Tag = i;
                lsvItens.Items.Add(item);
            }
            foreach (Fonetico.SIGNIFICADO i in dicUso.SIGNIFICADOCOMPOSTO)
            {
                ListViewItem item = new ListViewItem(i.CHAVE);
                item.ImageIndex = 2;
                item.Tag = i;
                lsvItens.Items.Add(item);
            }

        }

        private void lsvItens_DoubleClick(object sender, EventArgs e)
        {
            if (lsvItens.SelectedItems.Count == 1)
            {
                if(lsvItens.SelectedItems[0].ImageIndex == 0)
                {
                    frmString tela = new frmString();
                    tela.Item = lsvItens.SelectedItems[0].Tag.ToString();
                    tela.ShowDialog();
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (lsvItens.SelectedItems[0].Tag.ToString() != tela.Item)
                        {
                            dicUso.STOPWORD.Remove(lsvItens.SelectedItems[0].Tag.ToString());
                            dicUso.STOPWORD.Add(tela.Item);
                            UpdateItens();
                        }
                    }
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.Abort)
                    {
                        dicUso.STOPWORD.Remove(lsvItens.SelectedItems[0].Tag.ToString());
                        UpdateItens();
                    }
                }
                else if (lsvItens.SelectedItems[0].ImageIndex == 1)
                {
                    frmSignificado tela = new frmSignificado();
                    tela.Item = (Fonetico.SIGNIFICADO)lsvItens.SelectedItems[0].Tag;
                    tela.ShowDialog();
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        UpdateItens();
                    }
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.Abort)
                    {
                        dicUso.SIGNIFICADOS.Remove((Fonetico.SIGNIFICADO)lsvItens.SelectedItems[0].Tag);
                        UpdateItens();
                    }
                }
                else if (lsvItens.SelectedItems[0].ImageIndex == 2)
                {
                    frmSignificado tela = new frmSignificado();
                    tela.Item = (Fonetico.SIGNIFICADO)lsvItens.SelectedItems[0].Tag;
                    tela.FlagComposto = true;
                    tela.ShowDialog();
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        UpdateItens();
                    }
                    if (tela.DialogResult == System.Windows.Forms.DialogResult.Abort)
                    {
                        dicUso.SIGNIFICADOS.Remove((Fonetico.SIGNIFICADO)lsvItens.SelectedItems[0].Tag);
                        UpdateItens();
                    }
                }
            }
        }

        private void btnStopWords_Click(object sender, EventArgs e)
        {
            frmString tela = new frmString();
            tela.ShowDialog();
            if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dicUso.STOPWORD.Add(tela.Item);
                UpdateItens();
            }
        }

        private void btnSinonimos_Click(object sender, EventArgs e)
        {
            frmSignificado tela = new frmSignificado();
            tela.ShowDialog();
            if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dicUso.SIGNIFICADOS.Add(tela.Item);
                UpdateItens();
            }
        }

        private void btnSinonimosComposto_Click(object sender, EventArgs e)
        {
            frmSignificado tela = new frmSignificado();
            tela.FlagComposto = true;
            tela.ShowDialog();
            if (tela.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dicUso.SIGNIFICADOCOMPOSTO.Add(tela.Item);
                UpdateItens();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (sfdConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = sfdConfig.FileName;
                if (!FileName.Contains(".FONETICO"))
                {
                    FileName += ".FONETICO";
                }
                Fonetico.DICIONARIO.Salvar(FileName, dicUso);
                txtConfig.Text = "<add key=\"CaminhoFonetico\" value=\"" + FileName + "\"/>";
                ConfigurationManager.AppSettings["CaminhoFonetico"] = FileName;
            }
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["CaminhoFonetico"].ToString() == string.Empty)
            {
                MessageBox.Show("É preciso um arquivo fonetico configurado antes", "Buuuuro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Fonetico.DICIONARIO dicAux = Fonetico.DICIONARIO.Open(ConfigurationManager.AppSettings["CaminhoFonetico"].ToString());
            if (dicAux != dicUso)
            {
                if (MessageBox.Show("Deseja salvar as alterações no arquivo fonetico antes de testar?", "??????????", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSalvar_Click(sender, e);
                }
            }
            frmTeste tela = new frmTeste();
            tela.ShowDialog();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (fbdDLL.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Copy(Application.StartupPath + "\\Fonetico.dll", fbdDLL.SelectedPath + "\\Fonetico.dll");
            }
        }

    }
}
