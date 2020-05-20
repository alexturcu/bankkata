using System;
using System.Linq;
using bankkata.domain.feature.entities;
using bankkata.domain.feature.infrastructure;
using bankkata.domain.helpers.contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace bankkata.tests.feature
{
    public class TransactionRepositoryTests : IDisposable
    {
        public const string TODAY = "12/05/2015";
        private readonly Mock<IClock> _clockMock;
        private readonly TransactionRepository transactionRepository;

        public TransactionRepositoryTests()
        {
            _clockMock = new Mock<IClock>();
            transactionRepository = new TransactionRepository(_clockMock.Object);

            _clockMock.Setup(mock => mock.TodayAsString()).Returns(TODAY);
        }

        [Fact]
        public void Create_And_Store_A_Deposit_Transaction()
        {
            transactionRepository.AddDeposit(100);
            
            var transactions = transactionRepository.AllTransactions();

            transactions.Count.Should().Equals(1);
            transactions.First().Should().BeEquivalentTo(new Transaction(TODAY, 100));
        }

        [Fact]
        public void Create_And_Store_A_Withdrawal_Transaction()
        {
            transactionRepository.AddWithdrawal(100);
            
            var transactions = transactionRepository.AllTransactions();

            transactions.Count.Should().Equals(1);
            transactions.First().Should().BeEquivalentTo(new Transaction(TODAY, -100));
        }

        public void Dispose()
        {
            _clockMock.VerifyAll();
        }
    }
}
