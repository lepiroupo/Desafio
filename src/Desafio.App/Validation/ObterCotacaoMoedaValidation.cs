using Desafio.Api.Model.Requests;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Message.Notifications;
using FluentValidation;
using System.Linq;

namespace Desafio.App.Validation
{
    public class ObterCotacaoMoedaValidation : AbstractValidator<ObterCotacaoMoedaRequest>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly NotificacaoErro _notificacaoErro;

        public ObterCotacaoMoedaValidation(IClienteRepository clienteRepository, NotificacaoErro notificacaoErro)
        {
            _clienteRepository = clienteRepository;
            _notificacaoErro = notificacaoErro;
            DefinirValidacao();
            
        }

        public bool Validar(ObterCotacaoMoedaRequest request)
        {
            var validationResult = Validate(request);

            _notificacaoErro.AdicionarMensangens(validationResult.Errors.Select(e => e.ErrorMessage));

            return validationResult.IsValid;
        }

        private void DefinirValidacao()
        {
            CascadeMode = CascadeMode.Continue;
            RuleFor(x => x.Moeda)
                .Must(m => m.Length.Equals(3)).WithMessage("Moeda informada é inválida");
            RuleFor(x => x.IdCliente).Cascade(CascadeMode.Stop)
                .NotEqual(0).WithMessage("IdCliente deve ser maior que 0")
                .Must(ClienteExiste).WithMessage($"Cliente não encontrado");
            RuleFor(x => x.QuantidadeMoeda).GreaterThan(0).WithMessage("Quantidade de moeda deve ser maior que 0");
        }

        private bool ClienteExiste(long idCliente)
        {
            return _clienteRepository.ObterClientePorId(idCliente) != null;
        }
    }
}
