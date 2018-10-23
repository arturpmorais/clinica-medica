using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.entrar
{
    public partial class secretaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string pwd = txtPassword.Text;

            try
            {
                BDActions bd = new BDActions();
                SecretariaDBO s = bd.LoginSecretaria(codigo, pwd);

                Session["Usuario"] = s;

                Response.Redirect("/secretaria/index.aspx");
            }
            catch (Exception ex)
            {
                LblAviso.Text = ex.Message;
            }
        }
    }
}