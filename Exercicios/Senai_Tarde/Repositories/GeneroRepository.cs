using Senai_Tarde.Domains;
using Senai_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DESKTOP-16CG1FL\\SQLEXPRESS; initial catalog=Filmes_Prog; user Id=sa; pwd=sa@132;";

        public GeneroDomain Atualizar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string info = "SELECT IdGenero,Nome FROM Generos ";

                string atualizar = $"UPDATE Generos SET Nome = '{genero.Nome}' WHERE IdGenero = {genero.IdGenero}";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(info, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {


                        GeneroDomain bancoGenero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        if (genero.IdGenero == bancoGenero.IdGenero)
                        {
                            if (genero.Nome != bancoGenero.Nome)
                            {

                                rdr.Close();

                                using (SqlCommand command = new SqlCommand(atualizar, con))
                                {

                                    command.ExecuteNonQuery();


                                    return genero;


                                }
                            }
                        }


                    }
                }
                return null;




            }


        }


        public void Cadastrar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string insert = $"INSERT INTO Generos(Nome) VALUES ('{genero.Nome}') ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(insert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string delete = $"DELETE FROM Generos WHERE  IdGenero= {id}";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain Buscar(int id)
        {
            GeneroDomain genero = new GeneroDomain();

            string buscar = $"SELECT IdGenero,Nome FROM Generos WHERE IdGenero = {id}";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(buscar, con))
                {
                    rdr = cmd.ExecuteReader(); 

                    while(rdr.Read())
                    {
                        genero.IdGenero = Convert.ToInt32(rdr["IdGenero"]);
                        genero.Nome = rdr["Nome"].ToString();

                        if (genero.IdGenero == id)
                        {
                            return genero;
                        }
                    }
                }
            }
            return null;
        }


        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome FROM Generos";

                con.Open();

                SqlDataReader rdr;



                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
    }
}