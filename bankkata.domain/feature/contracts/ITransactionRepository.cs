using System.Collections.Generic;
using bankkata.domain.feature.entities;

namespace bankkata.domain.feature.contracts
{
    public interface ITransactionRepository
    {
        void AddDeposit(int amount);
        void AddWithdrawal(int amount);
        List<Transaction> AllTransactions();
    }
}