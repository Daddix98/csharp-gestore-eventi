using GestoreEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Milestone2
    {
        public static void Esegui()
        {

            try
            {


                Console.WriteLine("Inserisci nome dell' evento: ");
                string? titolo = Console.ReadLine();

                Console.WriteLine("Inserisci la data dell' evento: ");
                string? data = Console.ReadLine();
                DateTime dataDefinitiva;
                //tryparse è un metodo del dateTime che mi permette di convertire una stringa in dateTime e di varmi sapere se ci è riuscito o no
                //in questo caso la variabile dataDefinitiva non è stata inizializzata ed utilizzo out per avvertire il metodo tryParse
                if (!DateTime.TryParse(data, out dataDefinitiva))
                {
                    Console.WriteLine("La data che hai inserito non è valida ");
                    return;
                }
                if (dataDefinitiva < DateTime.Now)
                {
                    Console.WriteLine("La data che hai inserito è nel passato ");
                    return;

                }

                Console.WriteLine("Inserisci numero posti totali: ");
                string? numeroPosti = Console.ReadLine();

                int numeroPostiDefinitivo;
                if (!int.TryParse(numeroPosti, out numeroPostiDefinitivo))
                {
                    Console.WriteLine("Il numero di posti inserito non è un numero ");
                    return;
                }

                Evento evento = new Evento(titolo, dataDefinitiva, numeroPostiDefinitivo);

                Console.WriteLine("Inserisci il numero di posti che vuoi prenotare: ");
                string? nPostiPrenotati = Console.ReadLine();

                int postiPrenotatiDefinitivi;
                if (!int.TryParse(nPostiPrenotati, out postiPrenotatiDefinitivi))
                {
                    Console.WriteLine("Il numero di posti inserito non è un numero ");
                    return;
                }

                evento.PrenotaPosti(postiPrenotatiDefinitivi);
                Console.WriteLine("Numero posti prenotati = " + evento.NumeroPostiPrenotati);

                Console.WriteLine("Numero posti disponibile = " + (evento.MaxCapienzaEvento - evento.NumeroPostiPrenotati));

                while (true)
                {
                    Console.WriteLine("Vuoi disdire dei posti (si/no)? : ");
                    string? rispostaUtente = Console.ReadLine();
                    if (!rispostaUtente.ToLower().Equals("si"))//ToLower converte una stringa tutta in minuscolo e poi lo confronta con si
                    {
                        return;
                    }
                    Console.WriteLine("Indica il numero di posti da disdire: ");
                    string? postiDisdetti = Console.ReadLine();

                    int postiDisdettiDefinitivo;
                    if (!int.TryParse(postiDisdetti, out postiDisdettiDefinitivo))
                    {
                        Console.WriteLine("Il numero di posti inserito non è un numero ");
                        return;
                    }

                    evento.DisdiciPosti(postiDisdettiDefinitivo);
                    Console.WriteLine("Numero posti prenotati = " + evento.NumeroPostiPrenotati);

                    Console.WriteLine("Numero posti disponibile = " + (evento.MaxCapienzaEvento - evento.NumeroPostiPrenotati));




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//ex.Message contiene il dettaglio dell'eccezione che sia sollevato da me o dal programma
                                              //tutta la poszione di codice che potrebbe andare in errore(eccezione) va messa all'interno del try in modo che il programma
                                              //non si arresti e l'eccezione venga gestita. L'eccezione non permettera al codice di andare avanti ma invece lo porterà direttamente al chatch 
                                              //dove ho possibilità di visualizzare i dettagli dell'errore 
            }
        }
    }
}
