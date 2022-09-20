﻿using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Interfaces
{
    public interface IVoto
    {
        void Adicionar(int voto);
        void Excluir(Votos voto);
        bool Salvar();
        Task<Votos> RetornarIdVoto(int id);
        Task<IEnumerable<Votos>> LerVotos();
    }
}
