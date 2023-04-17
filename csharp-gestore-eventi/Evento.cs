using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        private string _titolo;
        private DateOnly _data;
        private int _capienzaMassima;
        public string Titolo
        {

            get
            {
                return _titolo;
            }

            set
            {
                if (value == "")
                    throw new Exception("Il titolo non può essere un campo vuoto");
                else
                    _titolo = value;
            }
        }
        public DateOnly Data
        {

            get
            {
                return _data;
            }

            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now))
                    throw new Exception("Non puoi inserire una data già passata");
                else
                    _data = value;
            }
        }
        public int CapienzaMassima
        {

            get
            {
                return _capienzaMassima;
            }

            set
            {
                if (value < 0)
                    throw new Exception("Non puoi inserire numeri negativi");
                else
                    _capienzaMassima = value;
            }
        }

        public int NumPostiPrenotati { get; private set; }

        public Evento(string titolo, DateOnly data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = capienzaMassima;
            NumPostiPrenotati = 0;
        }
        public void PrenotaPosti(int postiPrenotati)
        {
            int postiDisponibili = CapienzaMassima - NumPostiPrenotati;
            if (postiDisponibili == 0)
                throw new Exception("Non ci sono posti disponibili");
            
            else if(Data < DateOnly.FromDateTime(DateTime.Now))
                throw new Exception("L`evento è già passato");
            else
            NumPostiPrenotati = postiPrenotati;
        }
        public void DisdiciPosti(int postiDisdetti)
        {
            int posti = NumPostiPrenotati - postiDisdetti;
            if (posti < 0)
                throw new Exception("Non ci sono posti da disdire sufficienti");
            else if (Data < DateOnly.FromDateTime(DateTime.Now))
                throw new Exception("L`evento è già passato");
            else
            NumPostiPrenotati = posti;
        }
        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy") + "-" + Titolo;
        }

    }
}
