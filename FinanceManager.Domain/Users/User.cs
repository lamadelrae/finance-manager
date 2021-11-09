using FinanceManager.Domain.Base;
using System;

namespace FinanceManager.Domain.Users
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string Password { get; private set; }

        public User(Guid id,
                    DateTime createdAt,
                    bool isDeleted,
                    string name,
                    string password) : base(id, createdAt, isDeleted)
        {
            Name = name;
            Password = password;
        }
    }
}
