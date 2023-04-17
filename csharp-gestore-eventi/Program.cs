namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel tuo gestionale!");
            Console.Write("Inserisci il nome dell`evento : ");
           string titolo = Console.ReadLine();
            Console.Write("Inserisci la data dell`evento (dd/MM/yyyy) : ");
            string data = Console.ReadLine();
            Console.Write("Inserisci la capienza massima dell`evento : ");
            int capienzaMassima;
            while (!int.TryParse(Console.ReadLine(), out capienzaMassima))
                Console.Write("Inserisci un numero");
            Evento evento = new Evento(titolo, data, capienzaMassima);
            Console.WriteLine(evento.ToString());
            Console.WriteLine("Il tuo evento è stato creato!");
            Console.Write("Vuoi prenotare dei posti? (si/no) : ");
            string rispostaPrenota = Console.ReadLine();
            if(rispostaPrenota == "si")
            {
                Console.Write("Inserisci il numero di posti da prenotare : ");
                int numPostiPrenotati;
                while (!int.TryParse(Console.ReadLine(), out numPostiPrenotati))
                    Console.Write("Inserisci un numero");
                evento.PrenotaPosti(numPostiPrenotati);
                Console.WriteLine($"Hai prenotato {evento.NumPostiPrenotati} posti");
                int postiDisponibili = evento.CapienzaMassima - evento.NumPostiPrenotati;
                Console.WriteLine($"Il numero di posti disponibili al momento è di {postiDisponibili} posti");
              
            }
            Console.Write("Vuoi disdire dei posti? (si/no) : ");
            string rispostaDisdisci = Console.ReadLine();
         
            while (rispostaDisdisci == "si") {
            
                Console.Write("Inserisci il numero di posti da disdire : ");
                int numPostiDisdetti;
                while (!int.TryParse(Console.ReadLine(), out numPostiDisdetti))
                    Console.Write("Inserisci un numero");
                evento.DisdiciPosti(numPostiDisdetti);
                Console.WriteLine("Fatto");
                int postiDisponibili = evento.CapienzaMassima - evento.NumPostiPrenotati;
                Console.WriteLine($"Numero posti prenotati : {evento.NumPostiPrenotati} ");
                Console.WriteLine($"Numero posti disponibili : {postiDisponibili} ");
                Console.Write("Vuoi disdire dei posti? (si/no) : ");
                rispostaDisdisci = Console.ReadLine();
            }
          
            Console.WriteLine("Ok,Vabene");
            Console.Write("Inserisci il nome del tuo programma eventi : ");
            string titoloProgramma = Console.ReadLine();
            Console.Write("Inserisci il numero di eventi per il tuo programma : ");
            int numEventi;
            while (!int.TryParse(Console.ReadLine(), out numEventi))
                Console.WriteLine("inserisci un numero : ");
            ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);
            Console.WriteLine(programma.NumeroEventi());
            while (programma.NumeroEventi() != numEventi)
            { 
                    Console.Write("Vuoi aggiungere un evento oppure una conferenza? (evento/conferenza) : ");
                    string risposta = Console.ReadLine();
                    if (risposta == "evento")
                    {
                        try
                        {
                            Console.Write($"Inserisci il nome dell` evento : ");
                            string titoloEvento = Console.ReadLine();
                            Console.Write("Inserisci la data dell`evento (dd/MM/yyyy) : ");
                            string dataEvento = Console.ReadLine();
                            Console.Write("Inserisci la capienza massima dell`evento : ");
                            int capienzaMassimaEvento;
                            while (!int.TryParse(Console.ReadLine(), out capienzaMassimaEvento))
                                Console.Write("Inserisci un numero : ");
                            Evento nuovoEvento = new Evento(titoloEvento, dataEvento, capienzaMassimaEvento);
                            programma.eventi.Add(nuovoEvento);
                           Console.WriteLine(programma.NumeroEventi());

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Evento non valido, riprova");
                        }


                    }
                    else if (risposta == "conferenza")
                    {
                        try
                        {
                            Console.Write($"Inserisci il nome della conferenza : ");
                            string titoloConferenza = Console.ReadLine();
                            Console.Write("Inserisci la data dell`evento (dd/MM/yyyy) : ");
                            string dataConferenza = Console.ReadLine();
                            Console.Write("Inserisci la capienza massima dell`evento : ");
                            int capienzaMassimaConferenza;
                            while (!int.TryParse(Console.ReadLine(), out capienzaMassimaConferenza))
                                Console.Write("Inserisci un numero : ");
                            Console.Write("Inserisci il nome del relatore : ");
                            string nomeRelatoreConferenza = Console.ReadLine();
                            Console.Write("Inserisci il prezzo per la conferenza : ");
                            double prezzoConferenza;
                            while (!double.TryParse(Console.ReadLine(), out prezzoConferenza))
                                Console.Write("Inserisci un numero : ");

                            Conferenza nuovaConferenza = new Conferenza(nomeRelatoreConferenza, prezzoConferenza, titoloConferenza, dataConferenza, capienzaMassimaConferenza);
                            programma.eventi.Add(nuovaConferenza);
                            Console.WriteLine(programma.NumeroEventi());
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Evento non valido, riprova");
                        }
                       
                    }

            }
            Console.WriteLine($"Il numero di eventi nel programma è {programma.NumeroEventi()} ");
            programma.StampaProgramma();
            Console.Write("Inserisci una data : ");
            string dataEventi = Console.ReadLine();
            ProgrammaEventi.StampaLista(programma.ListaData(dataEventi));
            programma.SvuotaLista();
            

        }
    }
}