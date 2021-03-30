using System.Threading.Tasks;

namespace Desafio.ExchangeRates.Proxy.Interfaces
{
    public interface IExchangeRatesApiProxy
    {
        Task<decimal> ObterUltimaCotacaoMoeda(string siglaMoeda);
    }
}
