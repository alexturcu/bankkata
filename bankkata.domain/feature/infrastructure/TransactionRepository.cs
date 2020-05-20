using System.Collections.Generic;
using bankkata.domain.feature.contracts;
using bankkata.domain.feature.entities;
using bankkata.domain.helpers.contracts;

namespace bankkata.domain.feature.infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IClock _clock;
        private readonly List<Transaction> transactions;
        public TransactionRepository(IClock clock)
        {
            _clock = clock;
            transactions = new List<Transaction>();
        }

        public void AddDeposit(int amount)
        {
            Transaction deposit = new Transaction(_clock.TodayAsString(), amount);
            
            transactions.Add(deposit);
        }

        public void AddWithdrawal(int amount)
        {
            Transaction withdrawal = new Transaction(_clock.TodayAsString(), -amount);
            
            transactions.Add(withdrawal);
        }

        public List<Transaction> AllTransactions()
        {
            return transactions;
        }
    }
}