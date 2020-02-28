using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string conexao = "Data Source=DEV9\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public void Atualizar(UsuariosDomain user)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string update = $"UPDATE Usuarios SET Email = '{user.Email}', Senha = '{user.Senha}', IdTipoUsuario = {user.IdTipoUsuario} WHERE IdTipoUsuario = {user.IdUsuarios}";

                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string busca = "SELECT Usuarios.IdUsuario,Usuarios.IdTipoUsuario, Usuarios.Email, Usuarios.Senha, TiposUsuarios.Titulo FROM Usuarios INNER JOIN TiposUsuarios ON TiposUsuarios.IdTipoUsuario = Usuarios.IdTipoUsuario " +
                    $"WHERE Usuarios.IdUsuario = {id}";

                using (SqlCommand cmd = new SqlCommand(busca, con))
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain u = new UsuariosDomain
                        {
                            IdUsuarios = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString(),
                            TipoUsuario =
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[1]),
                                Titulo = rdr[4].ToString()
                            }
                        };

                        return u;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(UsuariosDomain user)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string post = $"INSERT INTO Usuarios (IdTipoUsuario,Email,Senha) VALUES" +
                    $"({user.IdTipoUsuario},'{user.Email}','{user.Senha}')";

                using (SqlCommand cmd = new SqlCommand(post, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string delete = $"DELETE FROM Usuarios WHERE IdUsuario = {id} ";

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarioLista = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "SELECT Usuarios.IdUsuario,Usuarios.IdTipoUsuario, Usuarios.Email, Usuarios.Senha, TiposUsuarios.Titulo " +
                    "FROM Usuarios INNER JOIN TiposUsuarios ON TiposUsuarios.IdTipoUsuario = Usuarios.IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            IdUsuarios = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString(),
                            TipoUsuario =
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[1]),
                                Titulo = rdr[4].ToString()
                            }
                        };

                        usuarioLista.Add(usuario);
                    }

                }
            }
            return usuarioLista;
        }
    }
}
