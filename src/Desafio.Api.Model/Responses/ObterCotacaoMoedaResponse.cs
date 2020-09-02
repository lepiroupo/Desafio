using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Api.Model.Responses
{
    public class ObterCotacaoMoedaResponse
    {
        public string Moeda { get; private set; }
        public decimal ValorMoeda { get; set; }
        public string Quantidade { get; set; }
        public decimal ValorTaxa { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
