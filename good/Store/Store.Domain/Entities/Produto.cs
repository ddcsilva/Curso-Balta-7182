﻿namespace Store.Domain.Entities;

public class Produto : Base
{
    public Produto(string titulo, decimal preco, bool ativo)
    {
        Titulo = titulo;
        Preco = preco;
        Ativo = ativo;
    }

    public string Titulo { get; private set; }
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }
}
