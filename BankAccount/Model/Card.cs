namespace BankAccount.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Cvc { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }

    }
}
