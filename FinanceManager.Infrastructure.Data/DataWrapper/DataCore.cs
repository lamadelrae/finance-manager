using FinanceManager.Infrastructure.Data.DataRecords.Base;
using System;
using System.Collections.Generic;

namespace FinanceManager.Infrastructure.Data.DataWrapper
{
    internal class DataCore<T> : IDataCore<T> where T : IDataRecord
    {
        public void Execute(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public void ExecuteAsync(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryAsync(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public T QuerySingle(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public T QuerySingleAsync(string sql, object param)
        {
            throw new NotImplementedException();
        }
    }
}
