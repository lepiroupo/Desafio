using Desafio.Domain.Enums;
using System;

namespace Desafio.Domain.Entities
{
    public class TaxaCambio
    {
        public Segmento Segmento { get; private set; }
        public decimal ValorTaxa { get; private set; }        

        public TaxaCambio(Segmento segmento, decimal valorTaxa)
        {
            Segmento = segmento;
            ValorTaxa = valorTaxa;
        }
    }
}
