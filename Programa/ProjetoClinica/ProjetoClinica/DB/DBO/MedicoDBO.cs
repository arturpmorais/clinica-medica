using ProjetoClinica.extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class MedicoDBO
    {
        public int Id { get; private set; }
        public string Nome_Completo { get; private set; }
        public string Email { get; private set; }
        public string Data_de_Nascimento { get; private set; }
        public string Endereco { get; private set; }
        public string Celular { get; private set; }
        public string Telefone_Residencial { get; private set; }
        public string Imagem { get; private set; }
        public EspecialidadeDBO Especialidade { get; private set; }


        public MedicoDBO(int id, string nome_completo, string email, string data_de_nascimento, string endereco, string celular, string telefone_residencial, string imagem, EspecialidadeDBO especialidade)
        {
            if (id < 0)
                throw new Exception("ID inválido");

            if (nome_completo.IsEmptyString())
                throw new Exception("Nome nulo");

            if (email.IsEmptyString())
                throw new Exception("E-mail nulo");

            if (data_de_nascimento.IsEmptyString())
                throw new Exception("Data de nascimento nula");

            if (endereco.IsEmptyString())
                throw new Exception("Endereco nulo");

            if (celular.IsEmptyString())
                throw new Exception("Celular nulo");

            if (telefone_residencial.IsEmptyString())
                throw new Exception("Telefone nulo");
            
            if (imagem.IsEmptyString())
                throw new Exception("Imagem nula");

            if (especialidade == null)
                throw new Exception("Especialidade nulo");

            this.Id = id;
            this.Nome_Completo = nome_completo;
            this.Email = email;
            this.Data_de_Nascimento = data_de_nascimento;
            this.Endereco = endereco;
            this.Celular = celular;
            this.Telefone_Residencial = telefone_residencial;
            this.Imagem = imagem;
            this.Especialidade = especialidade;
        }
    }
}