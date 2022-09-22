public class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    public int Salary { get; set; }

    public Client(string codiceFiscale)
    {
        FiscalCode = codiceFiscale;
        Salary = 0;
        Name = null;
        Surname = null;
    }
    public Client(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Name = nome;
        Surname = cognome;
        FiscalCode = codiceFiscale;
        Salary = stipendio;
    }

    public override string ToString()
    {
        return $"{this.Name}\t{this.Surname}\t{this.FiscalCode}\t{this.Salary}";
    }

}