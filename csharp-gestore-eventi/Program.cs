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

        }
    }
}