﻿using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> Get(IEnumerable<Guid> ids);
}
