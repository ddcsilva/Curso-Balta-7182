using Store.Domain.Commands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CriarPedidoCommandTests
    {
        [TestMethod]
        [TestCategory("Commands")]
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
    }
}
