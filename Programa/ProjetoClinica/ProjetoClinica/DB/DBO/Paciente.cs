using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class Paciente
    {
        public int Id { get; private set; }
        public string Nome_Completo { get; private set; }
        public string Email { get; private set; }
        public string Data_de_Nascimento { get; private set; }
        public string Endereco { get; private set; }
        public string Celular { get; private set; }
        public string Telefone_Residencial { get; private set; }
        public Image Imagem { get; private set; }


        public Paciente(int id, string nome_completo, string email, string data_de_nascimento, string endereco, string celular, string telefone_residencial, Image imagem)
        {
            if (nome_completo == null || nome_completo.Trim() == "")
                throw new Exception("Nome nulo");

            if (email == null || email.Trim() == "")
                throw new Exception("E-mail nulo");

            if (data_de_nascimento == null || data_de_nascimento.Trim() == "")
                throw new Exception("Data de nascimento nula");

            if (endereco == null || endereco.Trim() == "")
                throw new Exception("Endereco nulo");

            if (celular == null || celular.Trim() == "")
                throw new Exception("Celular nulo");

            if (telefone_residencial == null || telefone_residencial.Trim() == "")
                throw new Exception("Telefone nulo");

            //if (BDActions.CheckEmail(email))
            //    this.Email = email;
            else
                throw new Exception("E-mail invalido");

            //this.Id = id;
            //this.Username = username;
        }
    }
}