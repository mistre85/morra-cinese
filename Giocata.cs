namespace morra_cinese
{
    public class Giocata
    {
        Mossa mossaUtente;
        Mossa mossaCpu;

        int numero;

        public Giocata(Mossa mossaUtente, Mossa mossaCpu, int numeroGiocata)
        {
            this.mossaUtente = mossaUtente;
            this.mossaCpu = mossaCpu;
            this.numero = numeroGiocata;
        }

        public Giocatore getVincitore()
        {
            //la logica è semplificata dal fatto che si guarda solo alla scelta dell'utente
            //essendo 2 giocatori se uno vince l'altro perde (solo 2 casi) quindi possiamo semplificare le logiche
            bool pareggio = mossaCpu.Valore == mossaUtente.Valore;
            bool vinceForbice = mossaUtente.Valore == "forbice" && mossaCpu.Valore == "carta";
            bool vinceCarta = mossaUtente.Valore == "carta" && mossaCpu.Valore == "sasso";
            bool vinceSasso = mossaUtente.Valore == "sasso" && mossaCpu.Valore == "forbice";

            if (pareggio)
            {
                return null;
            }
            else
            {

                if (vinceForbice || vinceCarta || vinceSasso)
                {
                    return mossaUtente.getGiocatore();
                }
                else
                {
                    return mossaCpu.getGiocatore();
                }
            }

        }

        public void AssegnaPunto(Giocatore vincitore)
        {
            if (vincitore == null)
            {
                Console.WriteLine("Parità, nessun punteggio assegnato!");
            }
            else
            {

                if (vincitore.Cpu)                
                    Console.WriteLine("+1 punto per cpu");
                else
                    Console.WriteLine("+1 punto per utente");
                  

                vincitore.Punteggio++;
            }
        }
        public void Stampa()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", numero, 
                mossaUtente.Valore, 
                mossaCpu.Valore,
                mossaUtente.getGiocatore().Punteggio,
                mossaCpu.getGiocatore().Punteggio);
        }

    }
}