using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Conferenza : Evento
    {
        public string Relatore { get; set; }
        public double Prezzo { get; set; }

        public Conferenza(string relatore, double prezzo, string titolo, string data, int capienzaMassima) : base(titolo, data, capienzaMassima)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }
        public string FormattazionePrezzo()
        {
            return Prezzo.ToString("0.00");
          
        }
        public string FormattazioneData()
        {
            return Data.ToString("dd/MM/yyyy");
        }
        public override string ToString()
        {
            return FormattazioneData() + " - " + Titolo + " - " + Relatore + " - " + FormattazionePrezzo() + " euro";
        }
    }
}
