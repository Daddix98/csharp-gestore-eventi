using GestoreEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }
        private List<Evento> listaEventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            listaEventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento e)
        {
            listaEventi.Add(e);
        }

        public List<Evento> GetEventi(DateTime dt)
        {
            List<Evento> listaTemporanea = new List<Evento>();
            foreach (var item in listaEventi)   //
            {
                if(item.Data == dt)
                {
                    listaTemporanea.Add(item);

                }
            }
            return listaTemporanea;
        }
    }
}
