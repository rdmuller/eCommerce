﻿namespace eCommerce.Domain.Entites;
public class Department : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public ICollection<User>? Users { get; private set; }
}
