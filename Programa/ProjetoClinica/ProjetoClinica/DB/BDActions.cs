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
using System.IO;

namespace ProjetoClinica.DB
{
    public class BDActions
    {
        private readonly string cs;

        public BDActions()
        {
            this.cs = WebConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        }

        public Medico LoginMedico(string email, string senha)
        {
            if (IsEmptyString(email))
                throw new Exception("Digite um e-mail!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (IsEmptyString(senha))
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM medico WHERE email=@email AND senha=@senha" +
                                            "SELECT * FROM especialidade e, medico m WHERE" +
                                            "e.id = m.idEspecialidade AND" +
                                            "m.email = @email AND m.senha=@senha", conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            Medico m = null;
            object[] dadosMedico;
            object[] dadosEspecialidade;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                dadosMedico = ds.Tables["Medico"].Rows[0].ItemArray;
                dadosEspecialidade = ds.Tables["Especialidade"].Rows[0].ItemArray;

                int id = (int)dadosMedico[0];
                string nome_completo = (string)dadosMedico[1];
                email = (string)dadosMedico[2];
                string data_de_nascimento = (string)dadosMedico[3];
                string endereco = (string)dadosMedico[4];
                string celular = (string)dadosMedico[5];
                string telefone_residencial = (string)dadosMedico[6];
                Image imagem = BytesToImage((byte[])dadosMedico[7]);
                Especialidade especialidade = new Especialidade((int)dadosEspecialidade[0], (string)dadosEspecialidade[1]);

                m = new Medico(id, nome_completo, email, data_de_nascimento, endereco, celular, telefone_residencial, imagem, especialidade);

                return m;
            }
            else
                throw new Exception("E-mail ou senha incorretos!");
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

            SqlCommand cmd = new SqlCommand("SELECT * FROM paciente WHERE email=@email AND senha=@senha", conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            Paciente p = null;
            object[] dados;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                dados = ds.Tables[0].Rows[0].ItemArray;

                int id = (int)dados[0];
                string nome_completo = (string)dados[1];
                email = (string)dados[2];
                string data_de_nascimento = (string)dados[3];
                string endereco = (string)dados[4];
                string celular = (string)dados[5];
                string telefone_residencial = (string)dados[6];
                Image imagem = BytesToImage((byte[])dados[7]);

                p = new Paciente(id, nome_completo, email, data_de_nascimento, endereco, celular, telefone_residencial, imagem);

                return p;
            }
            else
                throw new Exception("E-mail ou senha incorretos!");
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

        public Image BytesToImage(byte[] bytes)
        {
            MemoryStream memstr = new MemoryStream(bytes);
            Image img = Image.FromStream(memstr);

            return img;
        }
    }
}