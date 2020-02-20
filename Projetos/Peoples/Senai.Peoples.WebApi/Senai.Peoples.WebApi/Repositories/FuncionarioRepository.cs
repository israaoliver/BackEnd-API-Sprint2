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
        private string  Conexao = "Data Source=DEV9\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public FuncionariosDomain Atulizar(int id, FuncionariosDomain funcionario)
        {
            throw new NotImplementedException();
        }

        public FuncionariosDomain BuscarId()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string cadas = $"INSERT INTO Funcionarios(Nome,Sobrenome) VALUES ('{funcionario.Nome}','{funcionario.Sobrenome}')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(cadas, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> Funci = new List<FuncionariosDomain>();

            using (SqlConnection c = new SqlConnection(Conexao))
            {
                
                string q = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

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
    }
}
