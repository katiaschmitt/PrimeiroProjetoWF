using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SqlClient;

namespace PrimeiroProjetoWF
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection("Persist Security Info=False;User ID=sa;Initial Catalog=JovemProgramador;Data Source=BRE203D01\\SQLEXPRESS");
       // public SqlConnection conn = new SqlConnection("Persist Security Info=False;User ID = katia; Initial Catalog = db_katia; Data Source = aulabanco.ce9eq7mml3ie.sa - east - 1.rds.amazonaws.com");
        public void Conectar()
        {
            conn.Open();
        }
        public void Desconectar()
        {
            conn.Close();
        }

        public bool BuscarUsuario(string usuario, string senha)
        {
            string sql = $"select * from Usuario where Usuario = '{usuario}' and Senha = '{senha}' ";
            SqlCommand comando = new SqlCommand(sql, conn);

            var retorno = comando.ExecuteReader();

            if (retorno.Read())
                return true;

            return false;

        }

        public List<Aluno> BuscarAlunos()
        {
            string sql = "select Id, Nome, Idade from Aluno";
            SqlCommand comando = new SqlCommand(sql, conn);

            List<Aluno> aluno = new List<Aluno>();

            using (var reader = comando.ExecuteReader())
            { //cria um leitor do ADO.Net
                while (reader.Read())
                { //vai lendo cada item do resultado do select
                  //retorna sob demanda cada item encontrado
                    var idDb = reader.GetInt32(reader.GetOrdinal("Id"));
                    var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                    var IdadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                    

                    aluno.Add(new Aluno()
                    {
                        Id = idDb,
                        Nome = nomeDb,
                        Idade = IdadeDb
                    });
                }
                return aluno;
            }
        }
        public bool ExcluirAluno(int id)
        {
            string sql = $"delete from Aluno where Id = {id} ";
            SqlCommand comando = new SqlCommand(sql, conn);

            var retorno = comando.ExecuteReader();

            return true;

        }
    }


}
