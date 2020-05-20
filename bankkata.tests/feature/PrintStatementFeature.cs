using bankkata.domain.feature;
using bankkata.domain.feature.contracts;
using bankkata.domain.feature.entities;
using bankkata.domain.feature.infrastructure;
using bankkata.domain.helpers.contracts;
using Moq;
using Xunit;

namespace bankkata.tests.feature
{
    public class PrintStatementFeature
    {
        private readonly Mock<IConsoleWriter> _consoleMock;
        private readonly Mock<IClock> _clockMock;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;
        private readonly Account account;

        public PrintStatementFeature()
        {
            _consoleMock = new Mock<IConsoleWriter>();
            _clockMock = new Mock<IClock>();

            _statementPrinter = new StatementPrinter(_consoleMock.Object);
            _transactionRepository = new TransactionRepository(_clockMock.Object);
            account = new Account(_transactionRepository, _statementPrinter);
        }

        [Fact]
        public void Print_Statement_Containing_All_Transactions()
        {
            _clockMock.SetupSequence(mock => mock.TodayAsString())
                      .Returns("01/04/2014")
                      .Returns("02/04/2014")
                      .Returns("10/04/2014");
            
            _consoleMock.Setup(mock => mock.WriteLine("DATE | AMOUNT | BALANCE"));
            _consoleMock.Setup(mock => mock.WriteLine("10/04/2014 | 500.00 | 1400.00"));
            _consoleMock.Setup(mock => mock.WriteLine("02/04/2014 | -100.00 | 900.00"));
            _consoleMock.Setup(mock => mock.WriteLine("01/04/2014 | 1000.00 | 1000.00"));

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
            
            account.PrintStatement();

            _clockMock.VerifyAll();
            _consoleMock.VerifyAll();
        }

        [Fact]
        public void Print_Statement_Containing_Real_Transactions()
        {
            _clockMock.SetupSequence(mock => mock.TodayAsString())
                      .Returns("05/04/2014")
                      .Returns("03/04/2014")
                      .Returns("06/04/2014");
            
            _consoleMock.Setup(mock => mock.WriteLine("DATE | AMOUNT | BALANCE"));
            _consoleMock.Setup(mock => mock.WriteLine("06/04/2014 | 100.00 | 700.00"));
            _consoleMock.Setup(mock => mock.WriteLine("03/04/2014 | -400.00 | 600.00"));
            _consoleMock.Setup(mock => mock.WriteLine("05/04/2014 | 1000.00 | 1000.00"));

            account.Deposit(1000);
            account.Withdraw(400);
            account.Deposit(100);
            
            account.PrintStatement();

            _clockMock.VerifyAll();
            _consoleMock.VerifyAll();
        }
    }
}