﻿namespace ShopStoreWithIdentity.Entity
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; }
    }
}
