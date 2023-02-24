using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeClienteRepository : IClienteRepository
    {
        public Cliente Get(string documento)
        {
            if (documento == "12345678911")
            {
                return new Cliente("Danilo Silva", "danilo.silva@msn.com");
            }

            return null;
        }
    }
}
