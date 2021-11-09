using System;

namespace FinanceManager.Infrastructure.Data.DataRecords.Base
{
    internal class DataRecord : IDataRecord
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
