namespace Store.Domain.Entities;

public class Desconto : Base
{
    public Desconto(decimal quantia, DateTime dataExpiracao)
    {
        Quantia = quantia;
        DataExpiracao = dataExpiracao;
    }

    public decimal Quantia { get; private set; }
    public DateTime DataExpiracao { get; private set; }

    public bool EstaValido()
    {
        return DateTime.Compare(DateTime.Now, DataExpiracao) < 0;
    }

    public decimal Valor()
    {
        if (EstaValido())
            return Quantia;
        else
            return 0;
    }
}
