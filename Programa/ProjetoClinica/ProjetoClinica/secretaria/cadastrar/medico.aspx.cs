using ProjetoClinica.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria.cadastrar
{
    public partial class medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            //string nome_completo = txtNome.Text;
            //int especialidade = sei lal;
            //string endereco = txtEndereco.Text;
            //string email = txtEmail.Text;
            //string celular = ;
            //string telefone_residencial = ;
            //string senha = txtPassword.Text;
            //string senhaConf = txtConfirmPassword.Text;

            BDActions bd = new BDActions();

            try
            {
                //bd.CadastrarMedico(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial, null, especialidade);
            }
            catch (Exception ex)
            {
                LblAviso.Text = ex.Message;
            }
        }
    }
}