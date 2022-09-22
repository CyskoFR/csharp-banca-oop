public class Bank
{
    public string Nome { get; set; }

    List<Loan> Loans;

    List<Client> Clients;

    public Bank(string nome)
    {

        this.Nome = nome;
        Loans = new List<Loan>();
        Clients = new List<Client>();

        //fake db
        Client fc1 = new Client("ABCD");
        Loan fl1 = new Loan(fc1, 2000, 100, DateTime.Parse("01/01/2022"));

        Client fc2 = new Client("EFGH");
        Loan fl2 = new Loan(fc2, 4000, 100, DateTime.Parse("01/01/2021"));
        Loan fl3 = new Loan(fc2, 1000, 50, DateTime.Parse("01/05/2022"));

        Client fc3 = new Client("ILMN");
        Loan fl4 = new Loan(fc3, 1000, 30, DateTime.Parse("01/01/2021"));
        Loan fl5 = new Loan(fc3, 1000, 25, DateTime.Parse("01/05/2022"));
        Loan fl6 = new Loan(fc3, 1000, 70, DateTime.Parse("01/07/2022"));

        Clients.Add(fc1);
        Clients.Add(fc2);
        Clients.Add(fc3);

        Loans.Add(fl1);
        Loans.Add(fl2);
        Loans.Add(fl3);
        Loans.Add(fl4);
        Loans.Add(fl5);
        Loans.Add(fl6);

    }

    public void AddClient(Client cliente)
    {
        this.Clients.Add(cliente);
    }

    public Client SearchClient(string codiceFiscale)
    {
        foreach (Client cliente in Clients)
        {
            if (cliente.FiscalCode == codiceFiscale)
            {
                return cliente;
            }
        }

        return null;

    }

    public void AddLoan(Loan newLoan)
    {
        this.Loans.Add(newLoan);
    }

    public List<Loan> SearchLoans(string codiceFiscale)
    {
        List<Loan> loans = new List<Loan>();
        foreach (Loan loan in Loans)
        {
            if (loan.Holder.FiscalCode == codiceFiscale)
            {
                loans.Add(loan);
            }
        }

        return loans;

    }
}
