using ProjetoClinica.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class EspecialidadeDBO
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }


        public EspecialidadeDBO(int id, string nome)
        {
            if (id < 0)
                throw new Exception("ID inválido");

            if (nome.IsEmptyString())
                throw new Exception("Nome nulo");

            this.Id = id;
            this.Nome = nome;
        }
    }
}