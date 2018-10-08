using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoClinica.DB.DBO;

namespace ProjetoClinica
{
    public partial class Medico : System.Web.UI.MasterPage
    {
        private int id;
        private string nome_completo;
        private string email;
        private string data_de_nascimento;
        private string endereco;
        private string celular;
        private string telefone_residencial;
        private System.Drawing.Image imagem;
        private Especialidade especialidade;

        public Medico(int id, string nome_completo, string email, string data_de_nascimento, string endereco, string celular, string telefone_residencial, System.Drawing.Image imagem, Especialidade especialidade)
        {
            this.id = id;
            this.nome_completo = nome_completo;
            this.email = email;
            this.data_de_nascimento = data_de_nascimento;
            this.endereco = endereco;
            this.celular = celular;
            this.telefone_residencial = telefone_residencial;
            this.imagem = imagem;
            this.especialidade = especialidade;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}