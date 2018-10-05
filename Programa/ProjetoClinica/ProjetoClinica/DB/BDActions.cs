using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProjetoClinica.DB
{
    public class BDActions
    {
        private static string cs = WebConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;

        bool LogarMedico(string a) {
            SqlConnection conn = new SqlConnection(cs);

            //if ()

            return true;
        }

        bool LogarPaciente() {
            return true;
        }

        bool CadastrarMedico(string nome_completo, string email, string senha, string data_de_nascimento, string endereco, string celular, string telefone_residencial, int especialidade) {
            SqlConnection conn = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("INSERT INTO medico VALUES(@nome_completo, @email, @senha, @data_de_nascimento, @endereco, @celular, @telefone_residencial, NULL, @especialidade)");
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
                //abre conexao
                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro no cadastro!");
            }
            finally
            {
                //fecha conexao
                conn.Close();
                conn.Dispose();
            }
        }

        void CadastrarPaciente(string nome_completo, string email, string senha, string data_de_nascimento, string endereco, string celular, string telefone_residencial) {
            
        }

        private static string EncodePassword(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}