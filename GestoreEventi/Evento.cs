using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestoreEvento
{

    public class Evento
    {
        public string Titolo { get; set; }
        public DateTime Data { get; set; }
        public int MaxCapienzaEvento { get; private set; }//private set significa che posso assegnare un valore a questa proprietà solamente all'interno di questa classe 
        public int NumeroPostiPrenotati { get; private set; }

        public Evento(string titolo, DateTime data, int maxCapienzaEvento)
        {
            Titolo = titolo;
            Data = data;
            MaxCapienzaEvento = maxCapienzaEvento;
        }


        // Creo metodo per controllo formale e sollevo delle eccezioni al bisogno 
        public void PrenotaPosti(int postiPrenotati)
        {
            if(DateTime.Now > Data)
            {
                throw new Exception("L'evento è già passato");
            }

            int postiRimanenti = MaxCapienzaEvento - NumeroPostiPrenotati;
            if (postiRimanenti.Equals(0))
            {
                throw new Exception("Posti terminati");
            }

            if(postiPrenotati > postiRimanenti)
            {
                throw new Exception("Stai prenotando più posti di quanti ne siano rimasti");
            }
            NumeroPostiPrenotati += postiPrenotati;

        }

        //Creo metodo che gestisce eccezioni legati al numero di posti disponibili
        public void DisdiciPosti(int postiDisdetti)
        {
            if (DateTime.Now > Data)
            {
                throw new Exception("L'evento è già passato");
            }


            if (postiDisdetti > NumeroPostiPrenotati)
            {
                throw new Exception("Stai disdicendo più posti di quanti ne siano prenotati");
            }
            NumeroPostiPrenotati -= postiDisdetti;

        }

        //Sto sovrascrivendo il metodo tostring del sistema che trsformava simplicemente la classe evento in string
        //con override il metodo to string mi restituerà solo la data formattata-titolo
        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy") + "-" + Titolo;
        }
    }





}