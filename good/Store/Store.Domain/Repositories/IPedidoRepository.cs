using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IPedidoRepository
{
    void Salvar(Pedido pedido);
}
