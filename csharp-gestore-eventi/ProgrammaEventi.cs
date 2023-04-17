using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {
        public string Titolo { get; set; }
        public List<Evento> eventi;

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
        }
        public void AggiungiEvento(Evento evento)
        {
            eventi.Add(evento);
        }
        public List<Evento> ListaData(string data)
        {
            List <Evento> nuovaLista = new List <Evento>();
            string[] formats = { "dd/MM/yyyy" };
            DateOnly formatoData = DateOnly.ParseExact(data, formats);
            foreach(Evento evento in eventi)
            {
                if(evento.Data == formatoData)
                {
                    nuovaLista.Add(evento);
                }
            }
            return nuovaLista;

        }
        public static void StampaLista(List<Evento> lista)
        {
            foreach(Evento evento in lista)
            {
                Console.Write($"{evento.ToString()}");
            }
        }
        public int NumeroEventi()
        {
            return eventi.Count;
        }
        public void SvuotaLista()
        {
            eventi.Clear();
        }
        public void StampaProgramma(ProgrammaEventi programmaeventi)
        {
            Console.WriteLine($"{programmaeventi.Titolo}");
            foreach(Evento evento in programmaeventi.eventi)
            {
                Console.WriteLine($"{evento.ToString()}");
            } 
        }
    }
}
