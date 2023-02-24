using Store.Domain.Repositories;

namespace Store.Tests.Repositories;

public class FakeTaxaEntregaRepository : ITaxaEntregaRepository
{
    public decimal Get(string cep)
    {
        return 10;
    }
}
