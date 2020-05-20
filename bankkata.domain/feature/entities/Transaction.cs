namespace bankkata.domain.feature.entities
{
    public class Transaction
    {
        public string Date { get; set; }
        public int Amount { get; set; }

        public Transaction(string date, int amount)
        {
            this.Date = date;
            this.Amount = amount;
        }
    }
}