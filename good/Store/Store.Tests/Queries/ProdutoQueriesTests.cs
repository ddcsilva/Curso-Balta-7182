using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProdutoQueriesTests
    {
        private IList<Produto> _produtos;

        public ProdutoQueriesTests()
        {
            _produtos = new List<Produto>
            {
                new Produto("Produto 01", 10, true),
                new Produto("Produto 02", 20, true),
                new Produto("Produto 03", 30, true),
                new Produto("Produto 04", 40, false),
                new Produto("Produto 05", 50, false)
            };
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            var resultado = _produtos.AsQueryable().Where(ProdutoQueries.GetProdutosAtivos());
            Assert.AreEqual(resultado.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var resultado = _produtos.AsQueryable().Where(ProdutoQueries.GetProdutosInativos());
            Assert.AreEqual(resultado.Count(), 2);
        }
    }
}