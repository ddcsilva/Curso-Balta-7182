using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities;

[TestClass]
public class PedidoTests
{
    private readonly Cliente _cliente = new Cliente("Danilo Silva", "danilo.silva@msn.com");
    private readonly Produto _produto = new Produto("Produto 1", 10, true);
    private readonly Desconto _desconto = new Desconto(10, DateTime.Now.AddDays(5));

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);

        Assert.AreEqual(8, pedido.Numero.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);

        Assert.AreEqual(StatusPedidoEnum.AguardandoPagamento, pedido.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);
        // TODO: Verificar a não adição do item
        pedido.AdicionarItem(_produto, 1);
        pedido.Pagar(10);

        Assert.AreEqual(StatusPedidoEnum.AguardandoPagamento, pedido.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);
        pedido.Cancelar();

        Assert.AreEqual(StatusPedidoEnum.Cancelado, pedido.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);
        pedido.AdicionarItem(null, 1);

        Assert.AreEqual(0, pedido.Items.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
    {
        var pedido = new Pedido(_cliente, 0.5M, _desconto);
        pedido.AdicionarItem(_produto, 0);

        Assert.AreEqual(0, pedido.Items.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
    {
        var pedido = new Pedido(_cliente, 10, _desconto);
        pedido.AdicionarItem(_produto, 5);

        Assert.AreEqual(50, pedido.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
    {
        var descontoExpirado = new Desconto(10, DateTime.Now.AddDays(-5));
        var pedido = new Pedido(_cliente, 10, descontoExpirado);
        pedido.AdicionarItem(_produto, 5);

        Assert.AreEqual(60, pedido.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
    {
        Assert.Fail();
    }
}
