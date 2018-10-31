using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ProjetoClinica.DB;

namespace ProjetoClinica.secretaria
{
    public partial class Query : System.Web.UI.Page
    {
        [WebMethod]
        public static string CarregarDadosGraficos()
        {
            string dados = null;

            try
            {
                BDActions bd = new BDActions();
                dados = bd.CarregarDadosRelatorios();
            }
            catch (Exception ex)
            {
                dados = "{ \"erro\" : \"" + ex.Message + "\" }";
            }

            return dados;
        }
    }
}