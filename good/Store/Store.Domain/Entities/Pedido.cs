using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities;

public class Pedido : Base
{
    public Pedido(Cliente cliente, decimal taxaEntrega, Desconto desconto)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNull(cliente, "Cliente", "Cliente Inválido")
        );

        Cliente = cliente;
        Data = DateTime.Now;
        Numero = Guid.NewGuid().ToString().Substring(0, 8);
        TaxaEntrega = taxaEntrega;
        Desconto = desconto;
        Status = StatusPedidoEnum.AguardandoPagamento;
        Items = new List<ItemPedido>();
    }

    public Cliente Cliente { get; private set; }
    public DateTime Data { get; private set; }
    public string Numero { get; private set; }
    public IList<ItemPedido> Items { get; private set; }
    public decimal TaxaEntrega { get; private set; }
    public Desconto Desconto { get; private set; }
    public StatusPedidoEnum Status { get; private set; }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        var item = new ItemPedido(produto, quantidade);

        if (item.Valid)
        {
            Items.Add(item);
        }
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.Total();
        }

        total += TaxaEntrega;
        total -= Desconto != null ? Desconto.Valor() : 0;

        return total;
    }

    public void Pagar(decimal quantia)
    {
        if (quantia == Total())
        {
            Status = StatusPedidoEnum.AguardandoEntrega;
        }
    }

    public void Cancelar()
    {
        Status = StatusPedidoEnum.Cancelado;
    }
}
