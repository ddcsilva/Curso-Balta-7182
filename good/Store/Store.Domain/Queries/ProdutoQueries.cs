using Store.Domain.Entities;
using System.Linq.Expressions;

namespace Store.Domain.Queries;

public static class ProdutoQueries
{
    public static Expression<Func<Produto, bool>> GetProdutosAtivos()
    {
        return x => x.Ativo;
    }

    public static Expression<Func<Produto, bool>> GetProdutosInativos()
    {
        return x => x.Ativo == false;
    }
}
