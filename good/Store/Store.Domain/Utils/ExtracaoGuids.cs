using Store.Domain.Commands;

namespace Store.Domain.Utils
{
    public static class ExtracaoGuids
    {
        public static IEnumerable<Guid> Extrair(IList<CriarItemPedidoCommand> items)
        {
            var guids = new List<Guid>();

            foreach (var item in items)
            {
                guids.Add(item.Produto);
            }

            return guids;
        }
    }
}