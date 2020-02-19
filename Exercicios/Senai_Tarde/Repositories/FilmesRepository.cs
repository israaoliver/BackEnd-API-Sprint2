using Senai_Tarde.Domains;
using Senai_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {

        private string conexao = "Data Source=DEV9\\SQLEXPRESS; initial catalog=Filmes_Prog; user Id=sa; pwd=sa@132;";

        public void AtualizarFilme(int id, FilmeDomain atulizaFilme)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string update = $"UPDATE Filmes SET Titulo = '{atulizaFilme.Titulo}' WHERE IdFilmes= {id}";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public FilmeDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string pegando = $"SELECT IdFilmes,IdGenero,Titulo FROM Filmes WHERE IdFilmes = {id}";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(pegando, con))
                {
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = rdr[2].ToString()
                        };

                        return filme;
                    }
                }  
                }
            return null;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string create = $"INSERT INTO Filmes(IdGenero,Titulo) VALUES ({novoFilme.IdGenero},'{novoFilme.Titulo}')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(create, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarFilme(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string delete = $"DELETE FROM Filmes WHERE IdFilmes = {id}";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> ListaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "SELECT Filmes.IdFilmes, Filmes.IdGenero, Filmes.Titulo, Generos.Nome FROM Filmes INNER JOIN Generos ON Generos.IdGenero = Filmes.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Nome = rdr[3].ToString()
                        };



                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = rdr[2].ToString(),
                            Genero = genero                           
                                                  

                        };





                        ListaFilme.Add(filme);


                    }
                }

            }

            return (ListaFilme);
        }
    }

}






