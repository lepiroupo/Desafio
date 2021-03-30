using System.Collections.Generic;
using System.Linq;

namespace Desafio.Message.Notifications
{
    public class NotificacaoErro
    {
        private readonly List<string> _mensagens;
        public IReadOnlyCollection<string> Mensagens => _mensagens;
        public bool PossuiMensangens => _mensagens.Any();
        public NotificacaoErro()
        {
            _mensagens = new List<string>();
        }

        public void AdicionarMensangens(IEnumerable<string> mensagens)
        {
            _mensagens.AddRange(mensagens);
        }

        public void AdicionarMensangem(string mensagem)
        {
            _mensagens.Add(mensagem);
        }
    }
}
