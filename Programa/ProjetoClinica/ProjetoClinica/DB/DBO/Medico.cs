using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class Medico
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }

        public Medico(int id, string username, string email)
        {
            if (username == null || username.Trim() == "")
                throw new Exception("Username nulo");

            if (email == null || email.Trim() == "")
                throw new Exception("E-mail nulo");

            //if (BDActions.CheckEmail(email))
            //    this.Email = email;
            else
                throw new Exception("E-mail invalido");

            //this.Id = id;
            //this.Username = username;
        }
    }
}