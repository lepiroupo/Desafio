﻿using Desafio.Api.Model.Requests;
using Desafio.Api.Model.Responses;
using System.Threading.Tasks;

namespace Desafio.App.Interfaces
{
    public interface ICotacaoApp
    {        
        Task<ObterCotacaoMoedaResponse> ObterCotacaoMoeda(ObterCotacaoMoedaRequest request);
    }
}
