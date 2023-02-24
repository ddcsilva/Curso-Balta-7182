using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;

namespace Store.Domain.Handlers
{
    public class PedidoHandler :
        Notifiable,
        IHandler<CriarPedidoCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaEntregaRepository _taxaRepository;
        private readonly IDescontoRepository _descontoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(
            IClienteRepository clienteRepository,
            ITaxaEntregaRepository taxaEntregaRepository,
            IDescontoRepository descontoRepository,
            IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository)
        {
            _clienteRepository = clienteRepository;
            _taxaRepository = taxaEntregaRepository;
            _descontoRepository = descontoRepository;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public ICommandResult Handle(CriarPedidoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);

            // 1. Recupera o cliente
            var cliente = _clienteRepository.Get(command.Cliente);

            // 2. Calcula a taxa de entrega
            var taxaEntrega = _taxaRepository.Get(command.Cep);

            // 3. Obtém o cupom de desconto
            var desconto = _descontoRepository.Get(command.codigoPromocional);

            // 4. Gera o pedido
            var produtos = _produtoRepository.Get(ExtrairGuids.Extrair(command.Items)).ToList();
            var pedido = new Pedido(cliente, taxaEntrega, desconto);
            foreach (var item in command.Items)
            {
                var produto = produtos.Where(x => x.Id == item.Produto).FirstOrDefault();
                pedido.AdicionarItem(produto, item.Quantidade);
            }

            // 5. Agrupa as notificações
            AddNotifications(pedido.Notifications);

            // 6. Verifica se deu tudo certo
            if (Invalid)
            {
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);
            }

            // 7. Retorna o resultado
            _pedidoRepository.Salvar(pedido);

            return new GenericCommandResult(true, $"Pedido {pedido.Numero} gerado com sucesso", pedido);
        }
    }
}