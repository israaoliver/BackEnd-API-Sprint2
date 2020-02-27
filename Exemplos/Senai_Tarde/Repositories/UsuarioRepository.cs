using Senai_Tarde.Domains;
using Senai_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string conexao = "Data Source=DEV9\\SQLEXPRESS; initial catalog=Filmes_Prog; user Id=sa; pwd=sa@132;";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email",email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while(rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr[0]);

                            usuario.Email = rdr[1].ToString();

                            usuario.Senha = rdr[2].ToString();

                            usuario.Permissao = rdr[3].ToString();

                        }
                        return usuario;
                    }
                }
            }
            return null;
        }
    }
}
