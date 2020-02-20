using Senai_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Interfaces
{
    interface IFilmesRepository
    {

        List<FilmeDomain> Listar();

        FilmeDomain BuscarId(int id);

        void Cadastrar(FilmeDomain novoFilme);

        void AtualizarFilme(int id, FilmeDomain atulizaFilme);

        void DeletarFilme(int id);

        List<FilmeDomain> BuscarPorTitulo(FilmeDomain tituloBusca);
    }
}
