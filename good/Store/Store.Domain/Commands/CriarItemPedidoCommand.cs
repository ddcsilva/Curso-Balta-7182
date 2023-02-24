using Store.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands
{
    public class CriarItemPedidoCommand : Notifiable, ICommand
    {
        public CriarItemPedidoCommand() { }

        public CriarItemPedidoCommand(Guid produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public Guid Produto { get; set; }
        public int Quantidade { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Produto.ToString(), 32, "Produto", "Produto inválido")
                .IsGreaterThan(Quantidade, 0, "Quantidade", "Quantidade inválida")
            );
        }
    }
}