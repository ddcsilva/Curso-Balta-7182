﻿using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IDescontoRepository
{
    Desconto Get(string codigo);
}
