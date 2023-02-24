namespace Store.Domain.Repositories;

public interface ITaxaEntregaRepository
{
    decimal Get(string cep);
}
