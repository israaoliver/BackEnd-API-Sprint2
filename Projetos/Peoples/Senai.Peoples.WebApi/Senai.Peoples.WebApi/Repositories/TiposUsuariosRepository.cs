using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private string conexao = "Data Source=DESKTOP-16CG1FL\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public void Atualizar(TiposUsuariosDomain tipo)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string update = $"UPDATE TiposUsuarios SET Titulo = '{tipo.Titulo}' WHERE IdTipoUsuario = {tipo.IdTipoUsuario}";

                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TiposUsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string busca = $"SELECT IdTipoUsuario, Titulo FROM TiposUsuarios WHERE IdTipoUsuario = {id}";

                using (SqlCommand cmd = new SqlCommand(busca, con))
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        TiposUsuariosDomain tipo = new TiposUsuariosDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };

                        return tipo;
                    }
                }
                return null;
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string delete = $"DELETE FROM TiposUsuarios WHERE IdTipoUsuario = {id} ";

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TiposUsuariosDomain> Listar()
        {
            List<TiposUsuariosDomain> tipoLista = new List<TiposUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "SELECT IdTipoUsuario, Titulo FROM TiposUsuarios";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        TiposUsuariosDomain tipo = new TiposUsuariosDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };

                        tipoLista.Add(tipo);
                    }

                }
            }
            return tipoLista;
        }
    }
}
