namespace Desafio.Domain.Entities
{
    public class OperacaoCambio
    {
        public Cliente Cliente { get; private set; }
        public TaxaCambio TaxaCambio { get; private set; }
        public Moeda Moeda { get; private set; }
        public OperacaoCambio(Cliente cliente, TaxaCambio taxaCambio, Moeda moeda)
        {
            Cliente = cliente;
            TaxaCambio = taxaCambio;
            Moeda = moeda;
        }
        public decimal ObterValorOperacao(decimal quantidadeMoeda)
        {
            return quantidadeMoeda * Moeda.ValorEmReais * (1 + TaxaCambio.ValorTaxa);
        }
    }
}
