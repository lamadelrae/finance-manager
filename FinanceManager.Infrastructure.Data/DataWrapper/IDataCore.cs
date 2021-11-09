using FinanceManager.Infrastructure.Data.DataRecords.Base;
using System.Collections.Generic;

namespace FinanceManager.Infrastructure.Data.DataWrapper
{
    internal interface IDataCore<T> where T : IDataRecord
    {
        IEnumerable<T> QueryAsync(string sql, object param);

        IEnumerable<T> Query(string sql, object param);

        T QuerySingle(string sql, object param);

        T QuerySingleAsync(string sql, object param);

        void Execute(string sql, object param);

        void ExecuteAsync(string sql, object param);
    }
}
