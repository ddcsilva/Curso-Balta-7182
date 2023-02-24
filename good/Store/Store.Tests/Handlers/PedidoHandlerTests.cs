using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class PedidoHandlerTests
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaEntregaRepository _taxaEntregaRepository;
        private readonly IDescontoRepository _descontoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoHandlerTests()
        {
            _clienteRepository = new FakeClienteRepository();
            _taxaEntregaRepository = new FakeTaxaEntregaRepository();
            _descontoRepository = new FakeDescontoRepository();
            _pedidoRepository = new FakePedidoRepository();
            _produtoRepository = new FakeProdutoRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            // TODO: Implementar
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cep_invalido_o_pedido_deve_ser_gerado_normalmente()
        {
            // TODO: Implementar
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            // TODO: Implementar
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
        {
            // TODO: Implementar
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand();
            command.Cliente = "";
            command.Cep = "13411080";
            command.codigoPromocional = "12345678";
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand();
            command.Cliente = "12345678";
            command.Cep = "13411080";
            command.codigoPromocional = "12345678";
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));

            var handler = new PedidoHandler(
                _clienteRepository,
                _taxaEntregaRepository,
                _descontoRepository,
                _produtoRepository,
                _pedidoRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }
    }
}