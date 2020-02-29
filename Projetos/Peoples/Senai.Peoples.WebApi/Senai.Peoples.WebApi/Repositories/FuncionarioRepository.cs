using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{

    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string  Conexao = "Data Source=DESKTOP-16CG1FL\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public void Atulizar(int id, FuncionariosDomain f)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string update = $"UPDATE Funcionarios SET Nome = '{f.Nome}', Sobrenome = '{f.Sobrenome}',DataNacimento = '{f.DataNacimento}' WHERE IdFuncionario = {id}";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryId = $"SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = {id}";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryId, con))
                {
                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionariosDomain f = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString()
                        };

                        return f;
                    }
                }
            }
            return null;
        }

        public List<FuncionariosDomain> BuscarNome(FuncionariosDomain f)
        {
            List<FuncionariosDomain> f_List = new List<FuncionariosDomain>();
            
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryBusca = $"SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE Nome LIKE '{f.Nome}%' ORDER BY Nome ASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBusca, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionariosDomain f_new = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString()

                        };

                        f_List.Add(f_new);

                       
                    }
                    return f_List;
                }
            }
           
        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string cadas = $"INSERT INTO Funcionarios(Nome,Sobrenome,DataNacimento) VALUES ('{funcionario.Nome}','{funcionario.Sobrenome}','{funcionario.DataNacimento}')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(cadas, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string delete = $"DELETE FROM Funcionarios WHERE IdFuncionario = {id}";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> Funci = new List<FuncionariosDomain>();

            using (SqlConnection c = new SqlConnection(Conexao))
            {
                
                string q = "SELECT IdFuncionario, Nome, Sobrenome, DataNacimento FROM Funcionarios";

                c.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(q, c))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionariosDomain f = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString()

                        };

                        Funci.Add(f);

                    }
                }
            }
            return Funci;
        }

        public List<NomeDomain> NomeCompleto()
        {
            List<NomeDomain> No = new List<NomeDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryJunta = "SELECT CONCAT (Nome,' ',Sobrenome) FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryJunta, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        NomeDomain nCompleto = new NomeDomain
                        {
                            NomeCompleto = rdr[0].ToString()
                        };

                        No.Add(nCompleto);
                    }
                    return No;
                }

            }
        }
    }
}
