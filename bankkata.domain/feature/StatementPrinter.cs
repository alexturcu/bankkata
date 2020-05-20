using System.Collections.Generic;
using System.Linq;
using bankkata.domain.feature.contracts;
using bankkata.domain.feature.entities;
using bankkata.domain.helpers.contracts;

namespace bankkata.domain.feature
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string STATEMENT_HEADER = "DATE | AMOUNT | BALANCE";
        private const string DecimalFormat = "#.00";

        private readonly IConsoleWriter _console;

        public StatementPrinter(IConsoleWriter console)
        {
            this._console = console;
        }

        public void Print(List<Transaction> transactions)
        {
            PrintHeader();
            PrintStatementLines(transactions);
        }

        private void PrintHeader()
        {
            _console.WriteLine(STATEMENT_HEADER);
        }

        private void PrintStatementLines(List<Transaction> transactions)
        {
            transactions.Reverse();
            
            var index = 0;
            transactions.ForEach(transaction => {
                var runningBalance = transactions.Skip(index).Sum(t => t.Amount);
                ++index;
                PrintStatementLine(transaction, runningBalance);
            });
        }

        private void PrintStatementLine(Transaction transaction, int runningBalance)
        {
            _console.WriteLine($"{transaction.Date} | {transaction.Amount.ToString(DecimalFormat)} | {runningBalance.ToString(DecimalFormat)}");
        }
    }
}