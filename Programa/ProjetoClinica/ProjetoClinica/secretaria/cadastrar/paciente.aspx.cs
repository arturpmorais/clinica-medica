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
            string nome_completo = txtNomeCompleto.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtPassword.Text.Trim();
            string senhaConf = txtConfirmPassword.Text.Trim();
            string endereco = txtEndereco.Text.Trim();
            string celular = txtCelular.Text.Trim();
            string telefone_residencial = txtTelefoneResidencial.Text.Trim();
            string data_de_nascimento = txtDataNascimento.Text.Trim();

            BDActions bd = new BDActions();

            try
            {
                bd.CadastrarPaciente(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial, null);
                txtNomeCompleto.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtTelefoneResidencial.Text = "";
                txtDataNascimento.Text = "";
                LblAviso.Text = "Paciente cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                LblAviso.Text = ex.Message;
            }
        }
    }
}