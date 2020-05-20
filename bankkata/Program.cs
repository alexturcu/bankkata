using System;
using bankkata.domain.feature;
using bankkata.domain.feature.entities;
using bankkata.domain.feature.infrastructure;
using bankkata.domain.helpers;

namespace bankkata
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            var console = new ConsoleWriter();
            var transactionRepository = new TransactionRepository(clock);
            var statementPrinter = new StatementPrinter(console);
            var account = new Account(transactionRepository, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(400);
            account.Deposit(100);

            account.PrintStatement();
        }
    }
}
