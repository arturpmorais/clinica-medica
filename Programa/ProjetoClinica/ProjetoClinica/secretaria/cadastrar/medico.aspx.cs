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
            string nome_completo = txtNomeCompleto.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtPassword.Text;
            string senhaConf = txtConfirmPassword.Text;
            string endereco = txtEndereco.Text.Trim();
            string celular = txtCelular.Text.Trim();
            string telefone_residencial = txtTelefoneResidencial.Text.Trim();
            string data_de_nascimento = txtDataNascimento.Text.Trim();
            int especialidade = int.Parse(dllEspecialidades.SelectedValue);

            BDActions bd = new BDActions();

            try
            {
                bd.CadastrarMedico(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial, null, especialidade);
                txtNomeCompleto.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtTelefoneResidencial.Text = "";
                txtDataNascimento.Text = "";
                dllEspecialidades.SelectedIndex = 0;

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "Médico cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}