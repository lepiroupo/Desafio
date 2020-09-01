namespace Desafio.Domain.Entities
{
    public class TaxaCambio
    {
        public decimal ValorTaxa { get; private set; }
        public TaxaCambio(decimal valorTaxa)
        {
            ValorTaxa = valorTaxa;
        }
    }
}
