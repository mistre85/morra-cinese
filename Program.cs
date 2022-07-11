//morra cinese

//2 parteciapanti
// cpu e utente

//l'utente e i computer devono scegliere tra sasso carta e forbice
//una volta che l'utente scelgie bisogna decidicedere il vincitore/punteggio
//          sasso   carta   forbice
// sasso     p        vc       vs
// carta     -        p        vf
// forbice   -        -         p
//
//

//al meglio di N partite che stabilisce l'utente
//tenere il punteggio intermedio
//stampare alla fine il vincitore

//aggiungere alla fine di tutte le partie una stampa di tutte le mosse fatte dai giocatori.

//
// Giocatore / Partecipante --> punteggio | vincitore | mossa
// Mossa / Mano ??
// Partita --> punteggio | vincitore | resoconto finale
// Esito(?) = sè vincente una mossa ?? --> regola
// RegoleGioco ??
// MorraCinese / Gioco --> resconto finale
//

// tabella: classifica
// nome del giocatore: 
// punteggio:
// numero di match:
// data:

//  nome     punteggio   partite     data (order by) ...
//  paolo       5           5          11/07/2022
//  cpu       3           5          11/07/2022


using morra_cinese;
using System.Data.SqlClient;

bool adOggetti = false;
//new MorraCinese().Gioca();


if (adOggetti)
{
    MorraCinese gioco = new MorraCinese();

    gioco.Gioca();
    gioco.StampaResoconto();
}
else
{

    SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=morra-cinese;Integrated Security=True");

    try
    {
        conn.Open();


        string[] simboliMorra = { "sasso", "carta", "forbice" };
        int punteggioUtente = 0;
        int punteggioCpu = 0;
        int numeroPartite;

        string[] mosseUtente;
        string[] mosseCpu;

        string resocontoFinale = "";

       

        Console.WriteLine("************************");
        Console.WriteLine("Gioco della morra cinese");
        Console.WriteLine("************************");

        
        //stampa della classifica
        string query = "SELECT nome_giocatore,punteggio,numero_partite,data_partita from classifica order by data_partita desc";
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine();
        Console.WriteLine("****** Classifica ******");
        Console.WriteLine("Nome\tPunteggio\tPartite\tData");

        while (reader.Read())
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}",reader.GetString(0),reader.GetInt32(1),reader.GetInt32(2),reader.GetDateTime(3));
        }

        Console.WriteLine();
        Console.WriteLine("**** Fine Classifica ****");
        Console.WriteLine();

        reader.Close();


        Console.Write("Quanti match vuoi fare?: ");
        numeroPartite = int.Parse(Console.ReadLine());

        mosseUtente = new string[numeroPartite];
        mosseCpu = new string[numeroPartite];

        //salvateggio nel DB
        query = "INSERT INTO classifica (nome_giocatore,punteggio,numero_partite,data_partita) values(@nome,@punteggio,@partite,@data)";
        cmd = new SqlCommand(query, conn);

        cmd.Parameters.Add(new SqlParameter("@data", DateTime.Today));

        for (int partita = 0; partita < numeroPartite; partita++)
        {

            resocontoFinale += partita + "\t";

            Console.WriteLine("Partita {0} di {1}", partita + 1, numeroPartite);
            Console.Write("tu scegli?: ", partita);

            string mossaUtente = Console.ReadLine();
            mosseUtente[partita] = mossaUtente;

            int mossaCPU = new Random().Next(0, simboliMorra.Length);
            string sceltaCPU = simboliMorra[mossaCPU];
            mosseCpu[partita] = sceltaCPU;

            resocontoFinale += mossaUtente + "\t" + sceltaCPU;

            //la logica è semplificata dal fatto che si guarda solo alla scelta dell'utente
            //essendo 2 giocatori se uno vince l'altro perde (solo 2 casi) quindi possiamo semplificare le logiche
            bool pareggio = sceltaCPU == mossaUtente;
            bool vinceForbice = mossaUtente == "forbice" && sceltaCPU == "carta";
            bool vinceCarta = mossaUtente == "carta" && sceltaCPU == "sasso";
            bool vinceSasso = mossaUtente == "sasso" && sceltaCPU == "forbice";

            Console.WriteLine("CPU sceglie {0} ", sceltaCPU);

            if (pareggio)
            {
                Console.WriteLine("Parità, nessun punteggio assegnato!");

            }
            else
            {

                if (vinceForbice || vinceCarta || vinceSasso)
                {
                    Console.WriteLine("+1 punto per te");
                    punteggioUtente++;
                }
                else
                {
                    Console.WriteLine("+1 punto per cpu");
                    punteggioCpu++;
                }
            }

            Console.WriteLine();
            resocontoFinale += "\n";
        }

        //end partita

        if (punteggioUtente == punteggioCpu)
        {
            Console.WriteLine("Nessun vincitore!");
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@partite", numeroPartite));

            if (punteggioUtente > punteggioCpu)
            {
                Console.WriteLine("Hai vinto! {0} a {1}", punteggioUtente, punteggioCpu);
                cmd.Parameters.Add(new SqlParameter("@nome", "Paolo"));
                cmd.Parameters.Add(new SqlParameter("@punteggio", punteggioUtente));
            }
            else
            {
                Console.WriteLine("Hai Perso! {0} a {1}", punteggioUtente, punteggioCpu);
                cmd.Parameters.Add(new SqlParameter("@nome", "CPU"));
                cmd.Parameters.Add(new SqlParameter("@punteggio", punteggioCpu));
            }

            //alla fine di tutto eseguo la query
            cmd.ExecuteNonQuery();
        }

        

        Console.WriteLine("Resoconto partite (array):");
        Console.WriteLine();
        Console.WriteLine("Partita\tTu\tCPU");


        for (int i = 0; i < numeroPartite; i++)
        {
            Console.WriteLine("{0}\t{1}\t{2}", i, mosseUtente[i], mosseCpu[i]);
        }

        //Console.WriteLine("Resoconto partite (String):");
        //Console.WriteLine();
        //Console.WriteLine("Partita\tTu\tCPU\n" + resocontoFinale);


      


    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        conn.Close();
    }
}
