
using RDMDalWSR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForm
{
    public partial class FrmMain : Form
    {
        RdmDalWSR dal;
        
        public FrmMain()
        {           
            InitializeComponent();
        }

        private async void btnLoginAsync_Click(object sender, EventArgs e)
        {
            btnLoginAsync.Enabled = false;
            dal = new RdmDalWSR("http://user09.2isa.org/",txtBoxPseudo.Text);
            RdmDalWSRResult ret = await dal.LoginAsync(CancellationToken.None) ;
            if(ret.ErrorCode == 0)
            {
                txtBoxMdp.Text = dal.Password;
                Grisage();
                GetListUsers();
            }else
            {
                MessageBox.Show(ret.ErrorMessage);
            }
            
        }


        private void btnListUtilisateurAsync_Click(object sender, EventArgs e)
        {
            GetListUsers();
        }

        private void txtBoxPseudo_TextChanged(object sender, EventArgs e)
        {
            btnLoginAsync.Enabled = !string.IsNullOrWhiteSpace(txtBoxPseudo.Text);
        }

        private async void btnDeconnect_Click(object sender, EventArgs e)
        {
            await dal.LogoutAsync(CancellationToken.None);
            txtBoxMdp.Clear();
            listBoxUtilisateurs.DataSource = null;
            Grisage();
            
        }

        private async void GetListUsers()
        {       
            RdmDalWSRResult result = await dal.GetPseudosAsync(CancellationToken.None);
            listBoxUtilisateurs.DataSource = (List<string>)result.Data;
        }

        private void Grisage()
        {
            btnDeconnect.Enabled = dal.IsLogged;
            btnLoginAsync.Enabled = !dal.IsLogged;
            txtBoxPseudo.Enabled = !dal.IsLogged;
        }
    }
}
