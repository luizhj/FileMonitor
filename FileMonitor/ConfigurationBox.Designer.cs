namespace FileMonitor
{
    partial class ConfigurationBox
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
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EntPasta = new System.Windows.Forms.TextBox();
            this.EntAmarelo = new System.Windows.Forms.TextBox();
            this.EntVermelho = new System.Windows.Forms.TextBox();
            this.BtnFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EntRefresh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EntSubPasta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirmar.Location = new System.Drawing.Point(542, 122);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(82, 28);
            this.BtnConfirmar.TabIndex = 60;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.Location = new System.Drawing.Point(454, 122);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 28);
            this.BtnCancelar.TabIndex = 70;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pasta para verificar o arquivo: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tempo em minutos para \"Alerta\" (Amarelo)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tempo em minutos para \"Parada\" (Vermelho)";
            // 
            // EntPasta
            // 
            this.EntPasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntPasta.Location = new System.Drawing.Point(235, 6);
            this.EntPasta.Name = "EntPasta";
            this.EntPasta.Size = new System.Drawing.Size(290, 20);
            this.EntPasta.TabIndex = 10;
            this.EntPasta.Leave += new System.EventHandler(this.EntPasta_Leave);
            // 
            // EntAmarelo
            // 
            this.EntAmarelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntAmarelo.Location = new System.Drawing.Point(235, 50);
            this.EntAmarelo.Name = "EntAmarelo";
            this.EntAmarelo.Size = new System.Drawing.Size(290, 20);
            this.EntAmarelo.TabIndex = 20;
            this.EntAmarelo.Leave += new System.EventHandler(this.EntAmarelo_Leave);
            // 
            // EntVermelho
            // 
            this.EntVermelho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntVermelho.Location = new System.Drawing.Point(235, 72);
            this.EntVermelho.Name = "EntVermelho";
            this.EntVermelho.Size = new System.Drawing.Size(290, 20);
            this.EntVermelho.TabIndex = 30;
            this.EntVermelho.Leave += new System.EventHandler(this.EntVermelho_Leave);
            // 
            // BtnFolder
            // 
            this.BtnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFolder.Image = global::FileMonitor.Properties.Resources.FolderOpen;
            this.BtnFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFolder.Location = new System.Drawing.Point(531, 4);
            this.BtnFolder.Name = "BtnFolder";
            this.BtnFolder.Size = new System.Drawing.Size(75, 24);
            this.BtnFolder.TabIndex = 11;
            this.BtnFolder.Text = "Pasta";
            this.BtnFolder.UseVisualStyleBackColor = true;
            this.BtnFolder.Click += new System.EventHandler(this.BtnFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Timer para atualização";
            // 
            // EntRefresh
            // 
            this.EntRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntRefresh.Location = new System.Drawing.Point(235, 94);
            this.EntRefresh.Name = "EntRefresh";
            this.EntRefresh.Size = new System.Drawing.Size(290, 20);
            this.EntRefresh.TabIndex = 40;
            this.EntRefresh.Leave += new System.EventHandler(this.EntRefresh_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Sub Pasta (archive / processada)";
            // 
            // EntSubPasta
            // 
            this.EntSubPasta.Location = new System.Drawing.Point(235, 28);
            this.EntSubPasta.Name = "EntSubPasta";
            this.EntSubPasta.Size = new System.Drawing.Size(290, 20);
            this.EntSubPasta.TabIndex = 12;
            this.EntSubPasta.Leave += new System.EventHandler(this.EntSubPasta_Leave);
            // 
            // ConfigurationBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(636, 162);
            this.Controls.Add(this.EntSubPasta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EntRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnFolder);
            this.Controls.Add(this.EntVermelho);
            this.Controls.Add(this.EntAmarelo);
            this.Controls.Add(this.EntPasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnConfirmar);
            this.Name = "ConfigurationBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurationBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EntPasta;
        private System.Windows.Forms.TextBox EntAmarelo;
        private System.Windows.Forms.TextBox EntVermelho;
        private System.Windows.Forms.Button BtnFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EntRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EntSubPasta;
    }
}