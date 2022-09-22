//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

using System;

Bank bancaIntesa = new Bank("Intesa San Paolo");

Console.WriteLine("Software Gestionale Bank " + bancaIntesa.Nome);
Console.WriteLine();

bool running = true;

while (running)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Aggiungi cliente");
    Console.WriteLine("2. Modifica cliente");
    Console.WriteLine("3. Ricerca cliente");
    Console.WriteLine("4. Ricerca prestito cliente");
    Console.WriteLine("5. Aggiungi un prestito");
    Console.WriteLine();

    Console.Write("Cosa vuoi fare? ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            string codiceFiscale = Console.ReadLine();

            Client clienteEsistente = bancaIntesa.SearchClient(codiceFiscale);

            if (clienteEsistente != null)
            {
                Console.WriteLine("Attenzione! Il cliente è già stato inserito!");
            }
            else
            {

                Client nuovoCLiente = new Client(codiceFiscale);
                bancaIntesa.AddClient(nuovoCLiente);
                Console.WriteLine("Il cliente è stato inserito correttamente");
            }

            break;

        case 2:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = bancaIntesa.SearchClient(codiceFiscale);

            if (clienteEsistente == null)
            {
                Console.WriteLine("Attenzione! non è stato trovato alcun cliente, cambia i criteri di ricerca");
            }
            else
            {
                Console.WriteLine("Inserisci il nome del cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome del cliente:");
                string cognomeCliente = Console.ReadLine();

                clienteEsistente.Name = nomeCliente;
                clienteEsistente.Surname = cognomeCliente;

                Console.WriteLine("Il cliente è stato modificato correttamente");
            }

            break;

        case 3:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = bancaIntesa.SearchClient(codiceFiscale);

            if (clienteEsistente == null)
            {
                Console.WriteLine("Attenzione! non è stato trovato alcun cliente, cambia i criteri di ricerca");
            }
            else
            {
                Console.WriteLine("Client Trovato!");
                Console.WriteLine(clienteEsistente.ToString());
            }

            break;

        case 4:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            Client client = bancaIntesa.SearchClient(codiceFiscale);
            List<Loan> loans = bancaIntesa.SearchLoans(codiceFiscale);

            int totalAmount = 0;


            foreach (Loan loan in loans)
            {
                totalAmount += loan.Amount;
            }

            Console.WriteLine("Totale ammontare prestiti concessi: {0}", totalAmount);

            foreach (Loan loan in loans)
            {
                Console.WriteLine("Per il prestito {0}, rimangono {1} rate da pagare.", loan.ID, loan.PaymentLeft());
            }

            break;

        case 5:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = bancaIntesa.SearchClient(codiceFiscale);

            if (clienteEsistente == null)
            {
                Console.WriteLine("Attenzione! non è stato trovato alcun cliente, cambia i criteri di ricerca");
            }
            else
            {
                Console.WriteLine("Client trovato!");

                Console.WriteLine("Inserisci l'amount del prestito:");
                int ammontare = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Inserisci la payment del prestito:");
                int rata = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Inserisci la data di inizio prestito:");
                DateTime dataInizio = Convert.ToDateTime(Console.ReadLine());

                Loan newLoan = new Loan(clienteEsistente, ammontare, rata, dataInizio);

                bancaIntesa.AddLoan(newLoan);

            }

            break;
    }
}
