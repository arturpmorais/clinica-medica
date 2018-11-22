using ProjetoClinica.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB.DBO
{
    public class ConsultaDBO
    {
        public int Id { get; private set; }
        public string Data { get; private set; }
        public string Duracao { get; private set; }
        public MedicoDBO Medico { get; private set; }
        public PacienteDBO Paciente { get; private set; }
        public string Status { get; private set; }
        public string Sintomas { get; private set; }
        public string Diagnostico { get; private set; }
        public string Medicacao { get; private set; }
        public string Observacoes { get; private set; }
        public string Avaliacao { get; private set; }

        public ConsultaDBO(int id, string data, string duracao, MedicoDBO medico, PacienteDBO paciente, string status, 
                           string sintomas, string diagnostico, string medicacao, string observacoes, string avaliacao)
        {
            if (id < 0)
                throw new Exception("ID inválido");

            if (data.IsEmptyString())
                throw new Exception("Data nula!");

            if (duracao.IsEmptyString())
                throw new Exception("Duração nula!");

            //if (medico == null)
            //    throw new Exception("Médico nulo!");

            //if (paciente == null)
            //    throw new Exception("Paciente nulo!");

            if (status.IsEmptyString())
                throw new Exception("Data nula!");

            this.Id = id;
            this.Data = data;
            this.Duracao = duracao;
            this.Medico = medico;
            this.Paciente = paciente;
            this.Status = status;
            this.Sintomas = sintomas;
            this.Diagnostico = diagnostico;
            this.Medicacao = medicacao;
            this.Observacoes = observacoes;
            this.Avaliacao = avaliacao;
        }
    }
}