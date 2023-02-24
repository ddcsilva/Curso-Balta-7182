using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IClienteRepository
{
    Cliente Get(string documento);
}
