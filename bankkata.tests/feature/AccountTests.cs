using System;
using System.Collections.Generic;
using bankkata.domain.feature.contracts;
using bankkata.domain.feature.entities;
using Moq;
using Xunit;

namespace bankkata.tests.feature
{
    public class AccountTests : IDisposable
    {
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IStatementPrinter> _statementPrinterMock;
        private readonly Account account;

        public AccountTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _statementPrinterMock = new Mock<IStatementPrinter>();

            account = new Account(_transactionRepositoryMock.Object, _statementPrinterMock.Object);
        }

        [Fact]
        public void Should_Store_A_Deposit_Transaction()
        {
            var amount = 1000;

            _transactionRepositoryMock.Setup(mock => mock.AddDeposit(amount));

            account.Deposit(amount);
        }

        [Fact]
        public void Should_Store_A_Withdrawal_Transaction()
        {
            var amount = 100;

            _transactionRepositoryMock.Setup(mock => mock.AddWithdrawal(amount));

            account.Withdraw(amount);
        }

        [Fact]
        public void Print_A_Statement()
        {
            var transactions = new List<Transaction>();

            _transactionRepositoryMock.Setup(mock => mock.AllTransactions()).Returns(transactions);
            _statementPrinterMock.Setup(mock => mock.Print(transactions));

            account.PrintStatement();
        }

        public void Dispose()
        {
            _transactionRepositoryMock.VerifyAll();
            _statementPrinterMock.VerifyAll();
        }
    }
}