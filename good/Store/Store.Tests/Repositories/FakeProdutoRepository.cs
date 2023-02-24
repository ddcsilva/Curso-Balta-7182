using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProdutoRepository
    {
        public IEnumerable<Produto> Get(IEnumerable<Guid> ids)
        {
            IList<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto("Produto 01", 10, true));
            produtos.Add(new Produto("Produto 02", 10, true));
            produtos.Add(new Produto("Produto 03", 10, true));
            produtos.Add(new Produto("Produto 04", 10, false));
            produtos.Add(new Produto("Produto 05", 10, false));

            return produtos;
        }
    }
}