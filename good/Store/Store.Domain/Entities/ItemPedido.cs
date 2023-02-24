using Flunt.Validations;

namespace Store.Domain.Entities;

public class ItemPedido : Base
{
    public ItemPedido(Produto produto, int quantidade)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNull(produto, "Produto", "Produto Inválido")
                .IsGreaterThan(quantidade, 0, "Quantidade", "A quantidade deve ser maior que zero")
        );

        Produto = produto;
        Preco = Produto != null ? produto.Preco : 0;
        Quantidade = quantidade;
    }

    public Produto Produto { get; private set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get; private set; }

    public decimal Total()
    {
        return Preco + Quantidade;
    }
}
