namespace ClientWinForm
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabLayPanMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabLayPanInner = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxLogin = new System.Windows.Forms.GroupBox();
            this.txtBoxMdp = new System.Windows.Forms.TextBox();
            this.btnLoginAsync = new System.Windows.Forms.Button();
            this.txtBoxPseudo = new System.Windows.Forms.TextBox();
            this.listBoxUtilisateurs = new System.Windows.Forms.ListBox();
            this.btnListUtilisateur = new System.Windows.Forms.Button();
            this.btnDeconnect = new System.Windows.Forms.Button();
            this.tabLayPanMain.SuspendLayout();
            this.tabLayPanInner.SuspendLayout();
            this.grpBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLayPanMain
            // 
            this.tabLayPanMain.ColumnCount = 3;
            this.tabLayPanMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayPanMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabLayPanMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayPanMain.Controls.Add(this.tabLayPanInner, 1, 1);
            this.tabLayPanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLayPanMain.Location = new System.Drawing.Point(0, 0);
            this.tabLayPanMain.Name = "tabLayPanMain";
            this.tabLayPanMain.RowCount = 3;
            this.tabLayPanMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayPanMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabLayPanMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayPanMain.Size = new System.Drawing.Size(659, 456);
            this.tabLayPanMain.TabIndex = 0;
            // 
            // tabLayPanInner
            // 
            this.tabLayPanInner.ColumnCount = 2;
            this.tabLayPanInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabLayPanInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabLayPanInner.Controls.Add(this.grpBoxLogin, 0, 0);
            this.tabLayPanInner.Controls.Add(this.listBoxUtilisateurs, 1, 0);
            this.tabLayPanInner.Controls.Add(this.btnListUtilisateur, 0, 1);
            this.tabLayPanInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLayPanInner.Location = new System.Drawing.Point(23, 23);
            this.tabLayPanInner.Name = "tabLayPanInner";
            this.tabLayPanInner.RowCount = 2;
            this.tabLayPanInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabLayPanInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabLayPanInner.Size = new System.Drawing.Size(613, 410);
            this.tabLayPanInner.TabIndex = 0;
            // 
            // grpBoxLogin
            // 
            this.grpBoxLogin.Controls.Add(this.btnDeconnect);
            this.grpBoxLogin.Controls.Add(this.txtBoxMdp);
            this.grpBoxLogin.Controls.Add(this.btnLoginAsync);
            this.grpBoxLogin.Controls.Add(this.txtBoxPseudo);
            this.grpBoxLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxLogin.Location = new System.Drawing.Point(3, 3);
            this.grpBoxLogin.Name = "grpBoxLogin";
            this.grpBoxLogin.Size = new System.Drawing.Size(300, 199);
            this.grpBoxLogin.TabIndex = 0;
            this.grpBoxLogin.TabStop = false;
            this.grpBoxLogin.Text = "Login";
            // 
            // txtBoxMdp
            // 
            this.txtBoxMdp.Location = new System.Drawing.Point(6, 74);
            this.txtBoxMdp.Name = "txtBoxMdp";
            this.txtBoxMdp.ReadOnly = true;
            this.txtBoxMdp.Size = new System.Drawing.Size(288, 20);
            this.txtBoxMdp.TabIndex = 2;
            // 
            // btnLoginAsync
            // 
            this.btnLoginAsync.Enabled = false;
            this.btnLoginAsync.Location = new System.Drawing.Point(6, 45);
            this.btnLoginAsync.Name = "btnLoginAsync";
            this.btnLoginAsync.Size = new System.Drawing.Size(100, 23);
            this.btnLoginAsync.TabIndex = 1;
            this.btnLoginAsync.Text = "Se connecter";
            this.btnLoginAsync.UseVisualStyleBackColor = true;
            this.btnLoginAsync.Click += new System.EventHandler(this.btnLoginAsync_Click);
            // 
            // txtBoxPseudo
            // 
            this.txtBoxPseudo.Location = new System.Drawing.Point(6, 19);
            this.txtBoxPseudo.Name = "txtBoxPseudo";
            this.txtBoxPseudo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPseudo.TabIndex = 0;
            this.txtBoxPseudo.TextChanged += new System.EventHandler(this.txtBoxPseudo_TextChanged);
            // 
            // listBoxUtilisateurs
            // 
            this.listBoxUtilisateurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUtilisateurs.FormattingEnabled = true;
            this.listBoxUtilisateurs.Location = new System.Drawing.Point(309, 3);
            this.listBoxUtilisateurs.Name = "listBoxUtilisateurs";
            this.listBoxUtilisateurs.Size = new System.Drawing.Size(301, 199);
            this.listBoxUtilisateurs.TabIndex = 1;
            // 
            // btnListUtilisateur
            // 
            this.btnListUtilisateur.Location = new System.Drawing.Point(3, 208);
            this.btnListUtilisateur.Name = "btnListUtilisateur";
            this.btnListUtilisateur.Size = new System.Drawing.Size(106, 55);
            this.btnListUtilisateur.TabIndex = 2;
            this.btnListUtilisateur.Text = "Obtenir la liste des utilisateurs connectés";
            this.btnListUtilisateur.UseVisualStyleBackColor = true;
            this.btnListUtilisateur.Click += new System.EventHandler(this.btnListUtilisateurAsync_Click);
            // 
            // btnDeconnect
            // 
            this.btnDeconnect.Enabled = false;
            this.btnDeconnect.Location = new System.Drawing.Point(112, 45);
            this.btnDeconnect.Name = "btnDeconnect";
            this.btnDeconnect.Size = new System.Drawing.Size(100, 23);
            this.btnDeconnect.TabIndex = 3;
            this.btnDeconnect.Text = "Se déconnecter";
            this.btnDeconnect.UseVisualStyleBackColor = true;
            this.btnDeconnect.Click += new System.EventHandler(this.btnDeconnect_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 456);
            this.Controls.Add(this.tabLayPanMain);
            this.Name = "FrmMain";
            this.Text = "Client ";
            this.tabLayPanMain.ResumeLayout(false);
            this.tabLayPanInner.ResumeLayout(false);
            this.grpBoxLogin.ResumeLayout(false);
            this.grpBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabLayPanMain;
        private System.Windows.Forms.TableLayoutPanel tabLayPanInner;
        private System.Windows.Forms.GroupBox grpBoxLogin;
        private System.Windows.Forms.Button btnLoginAsync;
        private System.Windows.Forms.TextBox txtBoxPseudo;
        private System.Windows.Forms.ListBox listBoxUtilisateurs;
        private System.Windows.Forms.TextBox txtBoxMdp;
        private System.Windows.Forms.Button btnListUtilisateur;
        private System.Windows.Forms.Button btnDeconnect;
    }
}

