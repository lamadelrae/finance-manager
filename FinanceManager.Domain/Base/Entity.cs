using System;

namespace FinanceManager.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        public Entity(Guid id, DateTime createdAt, bool isDeleted)
        {
            Id = id;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}