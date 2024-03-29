﻿using ProjetoClinica.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class SecretariaDBO
    {
        public string Codigo { get; private set; }
        public string Nome_Completo { get; private set; }

        public SecretariaDBO(string codigo, string nome_completo)
        {
            if (codigo.IsEmptyString())
                throw new Exception("Codigo nulo");

            if (nome_completo.IsEmptyString())
                throw new Exception("Nome nulo");

            this.Codigo = codigo;
            this.Nome_Completo = nome_completo;
        }
    }
}