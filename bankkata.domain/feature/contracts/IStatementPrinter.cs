using System.Collections.Generic;
using bankkata.domain.feature.entities;

namespace bankkata.domain.feature.contracts
{
    public interface IStatementPrinter
    {
        void Print(List<Transaction> transactions);
    }
}