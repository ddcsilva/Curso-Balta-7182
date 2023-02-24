using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CriarPedidoCommand : Notifiable, ICommand
    {
        public CriarPedidoCommand()
        {
            Items = new List<CriarItemPedidoCommand>();
        }

        public CriarPedidoCommand(string cliente, string cep, string codigoPromocional, IList<CriarItemPedidoCommand> items)
        {
            Cliente = cliente;
            Cep = cep;
            this.codigoPromocional = codigoPromocional;
            Items = items;
        }

        public string Cliente { get; set; }
        public string Cep { get; set; }
        public string codigoPromocional { get; set; }
        public IList<CriarItemPedidoCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Cliente, 11, "Cliente", "Cliente inválido")
                .HasLen(Cep, 8, "Cep", "CEP inválido")
            );
        }
    }
}