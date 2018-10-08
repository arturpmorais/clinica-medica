using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using ProjetoClinica.DB.DBO;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;

namespace ProjetoClinica.DB
{
    public class BDActions
    {
        private readonly string cs;

        public BDActions()
        {
            this.cs = WebConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        }

        public Medico LoginMedico(string a) {
            Medico m = null;

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();

            try
            {

            }
            catch (Exception e) { }
            finally { }

            return m;
        }

        public Paciente LoginPaciente(string email, string senha) {
            if (IsEmptyString(email))
                throw new Exception("Digite um e-mail!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (IsEmptyString(senha))
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM paciente WHERE email=@email", conn);

            cmd.Parameters.AddWithValue("@email", email);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                Paciente p = null;
                object[] dados;

                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);
                dados = ds.Tables[0].Rows[0].ItemArray;

                p = new Paciente((int)dados[0], (string)dados[1],
                                (string)dados[2], (string)dados[3],
                                (string)dados[4], (string)dados[5],
                                (string)dados[6], null);

                return p;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar o Banco de Dados!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        public void CadastrarMedico(string nome_completo, string email, string senha, string data_de_nascimento, string endereco, string celular, string telefone_residencial, int especialidade) {
            ValidarInformacoes(nome_completo, email, senha, data_de_nascimento, endereco, celular, telefone_residencial);

            if (EhCadastrado(email, "MEDICO"))
                throw new Exception("E-mail já cadastrado!");

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO medico VALUES(" +
                                            "@nome_completo, @email, @senha, " +
                                            "@data_de_nascimento, @endereco, " +
                                            "@celular, @telefone_residencial, " +
                                            "@imagem, @especialidade)", conn);

            cmd.Parameters.AddWithValue("@nome_completo", nome_completo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));
            cmd.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@telefone_residencial", telefone_residencial);
            cmd.Parameters.AddWithValue("@imagem", null);
            cmd.Parameters.AddWithValue("@especialidade", especialidade);

            try
            {
                // abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        public void CadastrarPaciente(string nome_completo, string email, string senha, string data_de_nascimento, string endereco, string celular, string telefone_residencial) {
            ValidarInformacoes(nome_completo, email, senha, data_de_nascimento, endereco, celular, telefone_residencial);

            if (EhCadastrado(email, "PACIENTE"))
                throw new Exception("E-mail já cadastrado!");

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO medico VALUES(" +
                                            "@nome_completo, @email, @senha, " +
                                            "@data_de_nascimento, @endereco, " +
                                            "@celular, @telefone_residencial, " +
                                            "@imagem)", conn);

            cmd.Parameters.AddWithValue("@nome_completo", nome_completo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));
            cmd.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@telefone_residencial", telefone_residencial);
            cmd.Parameters.AddWithValue("@imagem", null);

            try
            {
                // abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }


        //////////////////////////////////////////////////////

        private bool EhCadastrado(string email, string funcao)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = null;

            if (funcao.Equals("MEDICO"))
                cmd = new SqlCommand("SELECT count(id) FROM medico WHERE email=@email", conn);
            else if (funcao.Equals("PACIENTE"))
                cmd = new SqlCommand("SELECT count(id) FROM paciente WHERE email=@email", conn);

            cmd.Parameters.AddWithValue("@email", email);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);

                int count = (int)ds.Tables[0].Rows[0].ItemArray[0];

                if (count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar o Banco de Dados!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        private void ValidarInformacoes(string nome_completo, string email, string senha, string data_de_nascimento, string endereco, string celular, string telefone_residencial)
        {
            if (IsEmptyString(nome_completo))
                throw new Exception("Digite um nome!");

            if (nome_completo.Length >= 10 && nome_completo.Length <= 100)
                throw new Exception("Tamanho do nome é inválido!");

            ///

            if (IsEmptyString(email))
                throw new Exception("Digite um nome!");

            if (email.Length >= 5 && email.Length <= 50)
                throw new Exception("Tamanho do e-mail é inválido!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (IsEmptyString(senha))
                throw new Exception("Digite uma senha!");

            if (PasswordCheck.GetPasswordStrength(senha) < PasswordStrength.Medium)
                throw new Exception("Senha muito fraca!");

            ///

            if (IsEmptyString(data_de_nascimento))
                throw new Exception("Escolha uma data!");

            if (data_de_nascimento.Length != 10)
                throw new Exception("Escolha uma data válida!");

            ///

            if (IsEmptyString(endereco))
                throw new Exception("Digite um endereço!");

            if (endereco.Trim().Length < 5)
                throw new Exception("Endereço muito pequeno!");

            ///

            if (IsEmptyString(celular))
                throw new Exception("Digite um celular!");

            if (!IsValidPhoneNumber(celular))
                throw new Exception("Celular inválido!");

            ///

            if (IsEmptyString(telefone_residencial))
                throw new Exception("Digite um telefone residencial!");

            if (!IsValidPhoneNumber(telefone_residencial))
                throw new Exception("Telefone residencial inválido!");
        }

        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private bool IsValidPhoneNumber(string num)
        {
            if (IsEmptyString(num))
                return false;

            return Regex.Match(num, @"^([\+]?55[-]?|[0])?[1-9][0-9]{8}$").Success;
        }

        private string EncodePassword(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private bool IsEmptyString(string s)
        {
            if (s == null || s.Trim() == "")
                return true;

            return false;
        }
    }
}