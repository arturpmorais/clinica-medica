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
using ProjetoClinica.extensions;
using Newtonsoft.Json;

namespace ProjetoClinica.DB
{
    public class BDActions
    {
        private readonly string cs;

        public BDActions()
        {
            this.cs = WebConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        }

        public string CarregarDadosRelatorios()
        {
            SqlConnection conn = new SqlConnection(cs);
            
            // comandos de consulta
            SqlCommand cmdPacientesPorMedico = new SqlCommand("SELECT m.nome_completo as Medico, count(pm.idPaciente) as Pacientes " +
                                                              "FROM(SELECT idMedico, idPaciente FROM consulta WHERE status != 'CANCELADA' GROUP BY idMedico, idPaciente) AS pm, medico AS m " +
                                                              "WHERE pm.idMedico = m.id " +
                                                              "GROUP BY m.nome_completo", conn);

            SqlCommand cmdConsultasMensaisPorMedico = new SqlCommand("SELECT m.nome_completo AS Medico, count(c.id) AS Consultas " +
                                                                     "FROM medico m, consulta c " +
                                                                     "WHERE " +
                                                                     "m.id = c.idMedico AND " +
                                                                     "c.status = 'CANCELADA' AND " +
                                                                     "MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE()) " +
                                                                     "GROUP BY m.nome_completo", conn);

            SqlCommand cmdConsultasCanceladasPorMedico = new SqlCommand("SELECT m.nome_completo AS Medico, count(c.id) AS Consultas " +
                                                                        "FROM medico m, consulta c " +
                                                                        "WHERE " +
                                                                        "m.id = c.idMedico AND " +
                                                                        "c.status != 'CANCELADA' AND " +
                                                                        "MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE()) " +
                                                                        "GROUP BY m.nome_completo", conn);

            SqlCommand cmdAtendimentoPorEspecialidade = new SqlCommand("SELECT e.especialidade as Especialidade, count(c.id) as Consultas " +
                                                                       "FROM especialidade e, consulta c, medico m " +
                                                                       "WHERE " +
                                                                       "e.id = m.especialidade AND " +
                                                                       "m.id = c.idMedico AND " +
                                                                       "c.status != 'CANCELADA' AND " +
                                                                       "DAY(CONVERT(DATE, c.data, 103)) = DAY(GETDATE()) " +
                                                                       "GROUP BY e.especialidade", conn);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = null;
            DataRow dr = null;

            ds.Tables.Add("PacientesPorMedico");
            ds.Tables.Add("ConsultasMensaisPorMedico");
            ds.Tables.Add("ConsultasCanceladasPorMedico");
            ds.Tables.Add("AtendimentoPorEspecialidade");

            try
            {
                // abre conexao
                conn.Open();

                // executa a consulta
                adapter.SelectCommand = cmdPacientesPorMedico;
                adapter.Fill(ds.Tables["PacientesPorMedico"]);

                adapter.SelectCommand = cmdConsultasMensaisPorMedico;
                adapter.Fill(ds.Tables["ConsultasMensaisPorMedico"]);

                adapter.SelectCommand = cmdConsultasMensaisPorMedico;
                adapter.Fill(ds.Tables["ConsultasCanceladasPorMedico"]);

                adapter.SelectCommand = cmdAtendimentoPorEspecialidade;
                adapter.Fill(ds.Tables["AtendimentoPorEspecialidade"]);

                dt = ds.Tables["PacientesPorMedico"];

                string[] labelsPM = new string[dt.Rows.Count];
                int[] dataPM = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    labelsPM[i] = (string)dr.ItemArray[0];
                    dataPM[i] = (int)dr.ItemArray[1];
                }

                dt = ds.Tables["ConsultasMensaisPorMedico"];

                string[] labelsCMM = new string[dt.Rows.Count];
                int[] dataCMM = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    labelsCMM[i] = (string)dr.ItemArray[0];
                    dataCMM[i] = (int)dr.ItemArray[1];
                }

                dt = ds.Tables["ConsultasCanceladasPorMedico"];

                string[] labelsCCM = new string[dt.Rows.Count];
                int[] dataCCM = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    labelsCCM[i] = (string)dr.ItemArray[0];
                    dataCCM[i] = (int)dr.ItemArray[1];
                }

                dt = ds.Tables["AtendimentoPorEspecialidade"];

                string[] labelsAE = new string[dt.Rows.Count];
                int[] dataAE = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    labelsAE[i] = (string)dr.ItemArray[0];
                    dataAE[i] = (int)dr.ItemArray[1];
                }

                // gráfico de barra
                var dados = new {
                    PacientesPorMedico = new // gráfico de barra
                    {
                        labels = labelsPM,
                        series = new[]
                        {
                            new { data = dataPM }
                        }
                    },
                    ConsultasMensaisPorMedico = new // gráfico de barra
                    {
                        labels = labelsCMM,
                        series = new[]
                        {
                            new { data = dataCMM }
                        }
                    },
                    ConsultasCanceladasPorMedico = new // gráfico de barra
                    {
                        labels = labelsCCM,
                        series = new[]
                        {
                            new { data = dataCCM }
                        }
                    },
                    AtendimentoPorEspecialidade = new // gráfico de pizza
                    {
                        labels = labelsAE,
                        data = new
                        {
                            series = dataAE
                        }
                    }
                };

                return JsonConvert.SerializeObject(dados);
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

        public void MarcarConsultaComoAvisada(int id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("UPDATE consulta SET pacienteAvisado=1 WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                // abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao atualizar o registro da consulta!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        public string[][] PacientesComConsultaProxima()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT p.nome_completo, p.email, c.id, c.data FROM paciente p, consulta c " +
                                            "WHERE " +
                                            "p.id = c.idPaciente AND " +
                                            "c.status != 'CANCELADA' AND " +
                                            "DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) >= 0 AND " +
                                            "DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) <= 2 AND " +
                                            "c.pacienteAvisado = 0 " +
                                            "ORDER BY c.data", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = null;
            DataRow dr = null;

            string[][] dados = null;
            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds);

                dt = ds.Tables[0];
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    dados = new string[count][];

                    for (int i = 0; i < count; i++)
                    {
                        dados[i] = new string[4];
                        dr = dt.Rows[i];

                        dados[i][0] = dr.ItemArray[0].ToString();
                        dados[i][1] = dr.ItemArray[1].ToString();
                        dados[i][2] = dr.ItemArray[2].ToString();
                        dados[i][3] = dr.ItemArray[3].ToString();
                    }
                }

                return dados;
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

        public void MarcarConsulta(int idMedico, int idPaciente, string data, string horario, string duracao)
        {
            if (idMedico < 0)
                throw new Exception("Escolha um médico!");

            if (idPaciente < 0)
                throw new Exception("Escolha um paciente!");

            if (data.IsEmptyString())
                throw new Exception("Escolha uma data!");

            if (horario.IsEmptyString())
                throw new Exception("Escolha um horário!");

            if (duracao.IsEmptyString())
                throw new Exception("Escolha uma duração!");

            string datetime = VerificarDataNovaConsulta(data, horario);

            VerificarDisponibilidade(idMedico, idPaciente, datetime);

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO consulta VALUES(@data, @duracao, @idMedico, @idPaciente, @status, null, null, null, 0)", conn);
            cmd.Parameters.AddWithValue("@data", datetime);
            cmd.Parameters.AddWithValue("@duracao", duracao);
            cmd.Parameters.AddWithValue("@idMedico", idMedico);
            cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
            cmd.Parameters.AddWithValue("@status", "PENDENTE");

            try
            {
                // abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao marcar consulta!");
            }
            finally
            {
                // fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        public MedicoDBO LoginMedico(string email, string senha)
        {
            if (email.IsEmptyString())
                throw new Exception("Digite um e-mail!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (senha.IsEmptyString())
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmdMedico = new SqlCommand("SELECT * FROM medico as Medico WHERE email=@email AND senha=@senha", conn);
            SqlCommand cmdEspecialidade = new SqlCommand("SELECT * FROM especialidade e, medico m WHERE e.id = m.especialidade " +
                                                         "AND m.email = @email AND m.senha=@senha", conn);

            cmdMedico.Parameters.AddWithValue("@email", email);
            cmdMedico.Parameters.AddWithValue("@senha", EncodePassword(senha));
            cmdEspecialidade.Parameters.AddWithValue("@email", email);
            cmdEspecialidade.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add("Medico");
            ds.Tables.Add("Especialidade");

            MedicoDBO m = null;
            object[] dadosMedico;
            object[] dadosEspecialidade;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.SelectCommand = cmdMedico;
                adapter.Fill(ds.Tables["Medico"]);
                adapter.SelectCommand = cmdEspecialidade;
                adapter.Fill(ds.Tables["Especialidade"]);
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

            if (ds.Tables["Medico"].Rows.Count > 0 && ds.Tables["Especialidade"].Rows.Count > 0)
            {
                dadosMedico = ds.Tables["Medico"].Rows[0].ItemArray;
                dadosEspecialidade = ds.Tables["Especialidade"].Rows[0].ItemArray;

                int id = (int)dadosMedico[0];
                string nome_completo = (string)dadosMedico[1];
                email = (string) dadosMedico[2];
                string data_de_nascimento = (string)dadosMedico[4];
                string endereco = (string)dadosMedico[5];
                string celular = (string)dadosMedico[6];
                string telefone_residencial = (string)dadosMedico[7];
                string imagem;
                if (dadosMedico[8] is System.DBNull)
                    imagem = "/images/default_profile_picture.png";
                else
                    imagem = (string) dadosMedico[8];
                EspecialidadeDBO especialidade = new EspecialidadeDBO((int)dadosEspecialidade[0], (string)dadosEspecialidade[1]);

                m = new MedicoDBO(id, nome_completo, email, data_de_nascimento, endereco, celular, telefone_residencial, imagem, especialidade);

                return m;
            }
            else
                throw new Exception("E-mail ou senha incorretos!");
        }

        public PacienteDBO LoginPaciente(string email, string senha) {
            if (email.IsEmptyString())
                throw new Exception("Digite um e-mail!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (senha.IsEmptyString())
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("SELECT * FROM paciente WHERE email=@email AND senha=@senha", conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Tables.Add("Paciente");

            PacienteDBO p = null;
            object[] dados;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds.Tables["Paciente"]);
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

            if (ds.Tables["Paciente"].Rows.Count > 0)
            {
                dados = ds.Tables["Paciente"].Rows[0].ItemArray;

                int id = (int)dados[0];
                string nome_completo = (string)dados[1];
                email = (string)dados[2];
                string data_de_nascimento = (string)dados[4];
                string endereco = (string)dados[5];
                string celular = (string)dados[6];
                string telefone_residencial = (string)dados[7];
                string imagem;
                if (dados[8] is System.DBNull)
                    imagem = "/images/default_profile_picture.png";
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
            if (codigo.IsEmptyString())
                throw new Exception("Digite um código!");

            if (codigo.Trim().Length != 5)
                throw new Exception("Código inválido!");

            ///

            if (senha.IsEmptyString())
                throw new Exception("Digite uma senha!");

            ///

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM secretaria WHERE codigo=@codigo AND senha=@senha", conn);

            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@senha", EncodePassword(senha));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Tables.Add("Secretaria");

            SecretariaDBO s = null;
            object[] dados;

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.Fill(ds.Tables["Secretaria"]);
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

            if (ds.Tables["Secretaria"].Rows.Count > 0)
            {
                dados = ds.Tables["Secretaria"].Rows[0].ItemArray;

                codigo = (string)dados[0];
                string nome_completo = (string)dados[1];

                s = new SecretariaDBO(codigo, nome_completo);

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
            if (especialidade.IsEmptyString())
                throw new Exception("Digite uma especialidade!");

            if (especialidade.Trim().Length > 50)
                throw new Exception("Especialidade de tamanho muito grande!");

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

        private void VerificarDisponibilidade(int idMedico, int idPaciente, string datetime)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmdMedico = new SqlCommand("SELECT count(*) FROM consulta WHERE idMedico=@idMedico AND data=@data", conn);
            SqlCommand cmdPaciente = new SqlCommand("SELECT count(*) FROM consulta WHERE idPaciente=@idPaciente AND data=@data", conn);

            cmdMedico.Parameters.AddWithValue("@idMedico", idMedico);
            cmdMedico.Parameters.AddWithValue("@data", datetime);
            cmdPaciente.Parameters.AddWithValue("@idPaciente", idPaciente);
            cmdPaciente.Parameters.AddWithValue("@data", datetime);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add("ConsultasMedico");
            ds.Tables.Add("ConsultasPaciente");

            try
            {
                // abre conexao
                conn.Open();
                // executa a consulta
                adapter.SelectCommand = cmdMedico;
                adapter.Fill(ds.Tables["ConsultasMedico"]);
                adapter.SelectCommand = cmdPaciente;
                adapter.Fill(ds.Tables["ConsultasPaciente"]);
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

            if ((int)ds.Tables["ConsultasPaciente"].Rows[0].ItemArray[0] > 0)
                throw new Exception("O paciente já possui uma consulta marcada nesse horário!");

            if ((int)ds.Tables["ConsultasMedico"].Rows[0].ItemArray[0] > 0)
                throw new Exception("O médico já possui uma consulta marcada nesse horário!");
        }

        private string VerificarDataNovaConsulta(string data, string horario)
        {
            if (data.Length != 10)
                throw new Exception("Escolha uma data válida!");

            if (horario.Length != 5)
                throw new Exception("Escolha um horário válido!");

            string datetime = data + " " + horario;
            DateTime dataConsulta = DateTime.Parse(datetime);

            if (dataConsulta <= DateTime.Now)
                throw new Exception("Escolha uma data futura!");

            if (dataConsulta.Hour < 7 || dataConsulta.Hour > 22)
                throw new Exception("A Clínica estará fechada nesse horário!");

            return datetime;
        }

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
            if (nome_completo.IsEmptyString())
                throw new Exception("Digite um nome!");

            if (!(nome_completo.Length >= 10 && nome_completo.Length <= 100))
                throw new Exception("Tamanho do nome é inválido!");

            ///

            if (email.IsEmptyString())
                throw new Exception("Digite um nome!");

            if (!(email.Length >= 5 && email.Length <= 50))
                throw new Exception("Tamanho do e-mail é inválido!");

            if (!IsValidEmail(email))
                throw new Exception("E-mail inválido!");

            ///

            if (senha.IsEmptyString())
                throw new Exception("Digite uma senha!");

            if (PasswordCheck.GetPasswordStrength(senha) < PasswordStrength.Medium)
                throw new Exception("Senha muito fraca!");

            if (!senha.Equals(senhaConf))
                throw new Exception("Senhas diferentes!");

            ///

            if (data_de_nascimento.IsEmptyString())
                throw new Exception("Escolha uma data!");

            if (data_de_nascimento.Length != 10)
                throw new Exception("Escolha uma data válida!");

            ///

            if (endereco.IsEmptyString())
                throw new Exception("Digite um endereço!");

            if (endereco.Trim().Length < 5)
                throw new Exception("Endereço muito pequeno!");

            ///

            if (celular.IsEmptyString())
                throw new Exception("Digite um celular!");

            ///

            if (telefone_residencial.IsEmptyString())
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
    }
}