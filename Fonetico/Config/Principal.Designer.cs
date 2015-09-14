namespace Config
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.lsvItens = new System.Windows.Forms.ListView();
            this.img32 = new System.Windows.Forms.ImageList(this.components);
            this.tool = new System.Windows.Forms.ToolStrip();
            this.btnTeste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStopWords = new System.Windows.Forms.ToolStripButton();
            this.btnSinonimos = new System.Windows.Forms.ToolStripButton();
            this.btnSinonimosComposto = new System.Windows.Forms.ToolStripButton();
            this.txtConfig = new System.Windows.Forms.TextBox();
            this.lblConfig = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.lblItens = new System.Windows.Forms.Label();
            this.ofdConfig = new System.Windows.Forms.OpenFileDialog();
            this.sfdConfig = new System.Windows.Forms.SaveFileDialog();
            this.btnCopiar = new System.Windows.Forms.ToolStripButton();
            this.fbdDLL = new System.Windows.Forms.FolderBrowserDialog();
            this.tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvItens
            // 
            this.lsvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvItens.LargeImageList = this.img32;
            this.lsvItens.Location = new System.Drawing.Point(15, 83);
            this.lsvItens.Name = "lsvItens";
            this.lsvItens.Size = new System.Drawing.Size(661, 399);
            this.lsvItens.SmallImageList = this.img32;
            this.lsvItens.TabIndex = 0;
            this.lsvItens.UseCompatibleStateImageBehavior = false;
            this.lsvItens.DoubleClick += new System.EventHandler(this.lsvItens_DoubleClick);
            // 
            // img32
            // 
            this.img32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img32.ImageStream")));
            this.img32.TransparentColor = System.Drawing.Color.Transparent;
            this.img32.Images.SetKeyName(0, "page_white_horizontal_32.png");
            this.img32.Images.SetKeyName(1, "page_white_code_32.png");
            this.img32.Images.SetKeyName(2, "page_white_code_red_32.png");
            // 
            // tool
            // 
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTeste,
            this.toolStripSeparator1,
            this.btnAbrir,
            this.btnSalvar,
            this.toolStripSeparator2,
            this.btnStopWords,
            this.btnSinonimos,
            this.btnSinonimosComposto,
            this.btnCopiar});
            this.tool.Location = new System.Drawing.Point(0, 0);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(688, 25);
            this.tool.TabIndex = 1;
            this.tool.Text = "toolStrip1";
            // 
            // btnTeste
            // 
            this.btnTeste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTeste.Image = ((System.Drawing.Image)(resources.GetObject("btnTeste.Image")));
            this.btnTeste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(23, 22);
            this.btnTeste.Text = "Testa";
            this.btnTeste.Click += new System.EventHandler(this.btnTeste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(23, 22);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(23, 22);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStopWords
            // 
            this.btnStopWords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopWords.Image = ((System.Drawing.Image)(resources.GetObject("btnStopWords.Image")));
            this.btnStopWords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopWords.Name = "btnStopWords";
            this.btnStopWords.Size = new System.Drawing.Size(23, 22);
            this.btnStopWords.Text = "Adicionar StopWords";
            this.btnStopWords.Click += new System.EventHandler(this.btnStopWords_Click);
            // 
            // btnSinonimos
            // 
            this.btnSinonimos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSinonimos.Image = ((System.Drawing.Image)(resources.GetObject("btnSinonimos.Image")));
            this.btnSinonimos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSinonimos.Name = "btnSinonimos";
            this.btnSinonimos.Size = new System.Drawing.Size(23, 22);
            this.btnSinonimos.Text = "Adicionar Sinonimos";
            this.btnSinonimos.Click += new System.EventHandler(this.btnSinonimos_Click);
            // 
            // btnSinonimosComposto
            // 
            this.btnSinonimosComposto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSinonimosComposto.Image = ((System.Drawing.Image)(resources.GetObject("btnSinonimosComposto.Image")));
            this.btnSinonimosComposto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSinonimosComposto.Name = "btnSinonimosComposto";
            this.btnSinonimosComposto.Size = new System.Drawing.Size(23, 22);
            this.btnSinonimosComposto.Text = "Adicionar Sinonimos Compostos";
            this.btnSinonimosComposto.Click += new System.EventHandler(this.btnSinonimosComposto_Click);
            // 
            // txtConfig
            // 
            this.txtConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfig.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfig.Location = new System.Drawing.Point(15, 41);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.ReadOnly = true;
            this.txtConfig.Size = new System.Drawing.Size(632, 23);
            this.txtConfig.TabIndex = 2;
            this.txtConfig.Text = "<add key=\"CaminhoFonetico\" value=\"[]\"/>";
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(12, 25);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(39, 13);
            this.lblConfig.TabIndex = 3;
            this.lblConfig.Text = "Config:";
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(653, 41);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(23, 23);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.Location = new System.Drawing.Point(12, 67);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(56, 13);
            this.lblItens.TabIndex = 5;
            this.lblItens.Text = "Itens XML:";
            // 
            // ofdConfig
            // 
            this.ofdConfig.FileName = "openFileDialog1";
            this.ofdConfig.Filter = "Arquivo Fonetico|*.FONETICO";
            // 
            // sfdConfig
            // 
            this.sfdConfig.Filter = "Arquivo Fonetico|*.FONETICO";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiar.Image")));
            this.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(23, 22);
            this.btnCopiar.Text = "Copiar DLL";
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 494);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.txtConfig);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.lsvItens);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Fonetico";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvItens;
        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.ToolStripButton btnTeste;
        private System.Windows.Forms.TextBox txtConfig;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnSinonimos;
        private System.Windows.Forms.ToolStripButton btnSinonimosComposto;
        private System.Windows.Forms.ToolStripButton btnStopWords;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.OpenFileDialog ofdConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList img32;
        private System.Windows.Forms.SaveFileDialog sfdConfig;
        private System.Windows.Forms.ToolStripButton btnCopiar;
        private System.Windows.Forms.FolderBrowserDialog fbdDLL;
    }
}

