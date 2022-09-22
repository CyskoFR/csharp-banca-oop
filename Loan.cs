public class Loan
{
    private static int LastID { get; set; } = 0;

    public int ID { get; set; }

    public Client Holder { get; set; }
    public int Amount { get; set; }
    public int Payment { get; set; }

    public DateTime Start { get; private set; }

    public DateTime End { get; private set; }

    public Loan(Client holder, int amount, int payment, DateTime start)
    {
        //gestione virtuale degli id
        LastID++;
        ID = LastID;

        Holder = holder;
        Amount = amount;
        Payment = payment;
        Start = start;

        End = ResolveLastDate();
    }

    private DateTime ResolveLastDate()
    {
        int numberOfRates = (int)(Amount / Payment);

        End = Start.AddMonths(numberOfRates);

        return End;
    }

    public int PaymentLeft()
    {

        TimeSpan span = End.Subtract(DateTime.Today);

        return (int)(span.Days / (365.25 / 12));
    }
}
