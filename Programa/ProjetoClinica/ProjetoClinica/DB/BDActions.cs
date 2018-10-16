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

        public MedicoDBO LoginMedico(string email, string senha)
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM medico WHERE email=@email AND senha=@senha " +
                                            "SELECT * FROM especialidade e, medico m WHERE " +
                                            "e.id = m.especialidade AND " +
                                            "m.email = @email AND m.senha=@senha", conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            MedicoDBO m = null;
            object[] dadosMedico;
            object[] dadosEspecialidade;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o Banco de Dados!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }

            if (ds.Tables["Medico"].Rows.Count > 0 && ds.Tables["Especialidade"].Rows.Count > 0)
            {
                dadosMedico = ds.Tables["Medico"].Rows[0].ItemArray;
                dadosEspecialidade = ds.Tables["Especialidade"].Rows[0].ItemArray;

                int id = (int)dadosMedico[0];
                string nome_completo = (string)dadosMedico[1];
                email = (string)dadosMedico[2];
                string data_de_nascimento = (string)dadosMedico[4];
                string endereco = (string)dadosMedico[5];
                string celular = (string)dadosMedico[6];
                string telefone_residencial = (string)dadosMedico[7];
                string imagem;
                if (dadosMedico[8] is System.DBNull)
                    imagem = null;
                else
                    imagem = (string)dadosMedico[8];
                EspecialidadeDBO especialidade = new EspecialidadeDBO((int)dadosEspecialidade[0], (string)dadosEspecialidade[1]);

                m = new MedicoDBO(id, nome_completo, email, data_de_nascimento, endereco, celular, telefone_residencial, imagem, especialidade);

                return m;
            }
            else
                throw new Exception("E-mail ou senha incorretos!");
        }

        public PacienteDBO LoginPaciente(string email, string senha) {
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

            PacienteDBO p = null;
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
                string data_de_nascimento = (string)dados[4];
                string endereco = (string)dados[5];
                string celular = (string)dados[6];
                string telefone_residencial = (string)dados[7];
                string imagem;
                if (dados[8] is System.DBNull)
                    imagem = null;
                else
                    imagem = (string)dados[8];

                p = new PacienteDBO(id, nome_completo, email, data_de_nascimento, endereco, celular, telefone_residencial, imagem);

                return p;
            }
            else
                throw new Exception("E-mail ou senha incorretos!");
        }

        public SecretariaDBO LoginSecretaria(string codigo, string senha)
        {
            if (IsEmptyString(codigo))
                throw new Exception("Digite um código!");

            if (codigo.Trim().Length != 5)
                throw new Exception("Código inválido!");

            ///

            if (IsEmptyString(senha))
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM secretaria WHERE codigo=@codigo AND senha=@senha", conn);

            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            SecretariaDBO s = null;
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

                codigo = (string)dados[0];
                //string nome_completo = (string)dados[1];

                //s = new SecretariaDBO(codigo, nome_completo);
                s = new SecretariaDBO(codigo);

                return s;
            }
            else
                throw new Exception("Código ou senha incorretos!");
        }

        public void CadastrarMedico(string nome_completo, string email, string senha, string senhaConf, string data_de_nascimento, string endereco, string celular, string telefone_residencial, string imagem, int especialidade)
        {
            ValidarInformacoes(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial);

            if (EhCadastrado(email, "MEDICO"))
                throw new Exception("E-mail já cadastrado!");

            if (especialidade < 0)
                throw new Exception("Escolha uma especialidade!");

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO medico VALUES(" +
                                            "@nome_completo, @email, @senha, " +
                                            "@data_de_nascimento, @endereco, " +
                                            "@celular, @telefone_residencial, " +
                                            "null, @especialidade)", conn);

            cmd.Parameters.AddWithValue("@nome_completo", nome_completo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));
            cmd.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@telefone_residencial", telefone_residencial);
            cmd.Parameters.AddWithValue("@especialidade", especialidade);

            try
            {
                // abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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

        public void CadastrarPaciente(string nome_completo, string email, string senha, string senhaConf, string data_de_nascimento, string endereco, string celular, string telefone_residencial, string imagem) {
            ValidarInformacoes(nome_completo, email, senha, senhaConf, data_de_nascimento, endereco, celular, telefone_residencial);

            if (EhCadastrado(email, "PACIENTE"))
                throw new Exception("E-mail já cadastrado!");

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO paciente VALUES(" +
                                            "@nome_completo, @email, @senha, " +
                                            "@data_de_nascimento, @endereco, " +
                                            "@celular, @telefone_residencial, " +
                                            "null)", conn);

            cmd.Parameters.AddWithValue("@nome_completo", nome_completo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));
            cmd.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@telefone_residencial", telefone_residencial);

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

        public void CadastrarEspecialidade(string especialidade)
        {
            if (ExisteEspecialidade(especialidade))
                throw new Exception("Especialidade já cadastrada!");

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO especialidade VALUES(@especialidade)", conn);
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


        //////////////////////////////////////////////////////

        private bool ExisteEspecialidade(string especialidade)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = null;

            cmd = new SqlCommand("SELECT count(id) FROM especialidade WHERE especialidade=@especialidade", conn);
            cmd.Parameters.AddWithValue("@especialidade", especialidade);

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

        private void ValidarInformacoes(string nome_completo, string email, string senha, string senhaConf, string data_de_nascimento, string endereco, string celular, string telefone_residencial)
        {
            if (IsEmptyString(nome_completo))
                throw new Exception("Digite um nome!");

            if (!(nome_completo.Length >= 10 && nome_completo.Length <= 100))
                throw new Exception("Tamanho do nome é inválido!");

            ///

            if (IsEmptyString(email))
                throw new Exception("Digite um nome!");

            if (!(email.Length >= 5 && email.Length <= 50))
                throw new Exception("Tamanho do e-mail é inválido!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (IsEmptyString(senha))
                throw new Exception("Digite uma senha!");

            if (PasswordCheck.GetPasswordStrength(senha) < PasswordStrength.Medium)
                throw new Exception("Senha muito fraca!");

            if (!senha.Equals(senhaConf))
                throw new Exception("Senhas diferentes!");

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

            ///

            if (IsEmptyString(telefone_residencial))
                throw new Exception("Digite um telefone residencial!");
        }

        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
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