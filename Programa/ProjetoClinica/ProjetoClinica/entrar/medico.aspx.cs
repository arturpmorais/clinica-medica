﻿using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.entrar
{
    public partial class medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pwd = txtPassword.Text;

            try
            {
                BDActions bd = new BDActions();
                MedicoDBO m = bd.LoginMedico(email, pwd);

                Session["Usuario"] = m;

                Response.Redirect("/medico/index.aspx");
            }
            catch (Exception ex)
            {
                LblAviso.Text = ex.Message;
            }
        }
    }
}