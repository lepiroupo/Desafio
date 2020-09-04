namespace Desafio.Domain.Entities
{
    public class OperacaoCambio
    {
        public Cliente Cliente { get; private set; }
        public TaxaCambio TaxaCambio { get; private set; }
        public string Moeda { get; private set; }
        public decimal ValorMoeda { get; private set; }
        public decimal ValorOperacao { get; private set; }
        public OperacaoCambio(Cliente cliente, TaxaCambio taxaCambio)
        {
            Cliente = cliente;
            TaxaCambio = taxaCambio;
        }
        public void DefinirMoedaOperacao(string moeda, decimal valorMoeda)
        {
            Moeda = moeda;
            ValorMoeda = valorMoeda;
        }

        public void CalcularValorOperacao(decimal quantidadeMoeda)
        {
            ValorOperacao = quantidadeMoeda * ValorMoeda * (1 + TaxaCambio.ValorTaxa);
        }
    }
}
