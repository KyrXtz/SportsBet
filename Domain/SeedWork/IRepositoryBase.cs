﻿namespace SportsBet.Domain.SeedWork
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
