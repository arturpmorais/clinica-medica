using ProjetoClinica.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria.cadastrar
{
    public partial class paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string nome_completo = txtNomeCompleto.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string celular = txtCelular.Text;
            string telefone_residencial = txtTelefoneResidencial.Text;
            string senha = txtPassword.Text;
            string senhaConf = txtConfirmPassword.Text;
            string data_de_nascimento = txtDataNascimento.Text;

            BDActions bd = new BDActions();

            try
            {
                bd.CadastrarPaciente(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial, null);
            }
            catch (Exception ex)
            {
                LblAviso.Text = ex.Message;
            }
        }
    }
}