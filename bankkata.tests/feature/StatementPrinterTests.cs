using System;
using System.Collections.Generic;
using bankkata.domain.feature;
using bankkata.domain.feature.entities;
using bankkata.domain.helpers.contracts;
using Moq;
using Xunit;

namespace bankkata.tests.feature
{
    public class StatementPrinterTests : IDisposable
    {
        private readonly Mock<IConsoleWriter> _consoleMock;
        private readonly StatementPrinter statementPrinter;

        public StatementPrinterTests()
        {
            _consoleMock = new Mock<IConsoleWriter>();
            statementPrinter = new StatementPrinter(_consoleMock.Object);
        }

        [Fact]
        public void Always_Print_The_Header()
        {
            var NO_TRANSACTIONS = new List<Transaction>();

            _consoleMock.Setup(mock => mock.WriteLine("DATE | AMOUNT | BALANCE"));

            statementPrinter.Print(NO_TRANSACTIONS);
        }

        [Fact]
        public void Print_Transactions_In_Reverse_Chronological_Order()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("01/04/2014", 1000),
                new Transaction("02/04/2014", -100),
                new Transaction("10/04/2014", 500)
            };

            _consoleMock.Setup(mock => mock.WriteLine("DATE | AMOUNT | BALANCE"));
            _consoleMock.Setup(mock => mock.WriteLine("10/04/2014 | 500.00 | 1400.00"));
            _consoleMock.Setup(mock => mock.WriteLine("02/04/2014 | -100.00 | 900.00"));
            _consoleMock.Setup(mock => mock.WriteLine("01/04/2014 | 1000.00 | 1000.00"));
            
            statementPrinter.Print(transactions);
        }

        public void Dispose()
        {
            _consoleMock.VerifyAll();
        }
    }
}