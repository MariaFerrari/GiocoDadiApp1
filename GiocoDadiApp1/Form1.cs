using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoDadiApp1
{
    public partial class Form1 : Form
    {
        public List<char> vittorie;
        int turni;
        public Random dado = new Random();
        public List<char> classifica;
        Risorsa risorsa;
        public Form1()
        {
            InitializeComponent();
            vittorie = new List<char>();
            turni = 5;
            classifica = new List<char>();
            risorsa = new Risorsa(vittorie, classifica);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string bgwId = BgwId(sender as BackgroundWorker);
            int dado;
            for (int i=0; i<turni; i++)
            {
                lock (risorsa)
                {
                    switch (bgwId)
                    {
                        case "nord":
                            if (risorsa.Counter == risorsa.nord)
                                dado = Turno(risorsa, risorsa.nord);
                            else
                                return;
                            break;
                        case "est":
                            if (risorsa.Counter == risorsa.est)
                                dado = Turno(risorsa, risorsa.est);
                            else
                                return;
                            break;
                        case "sud":
                            if (risorsa.Counter == risorsa.sud)
                                dado = Turno(risorsa, risorsa.sud);
                            else
                                return;
                            break;
                        case "ovest":
                            if (risorsa.Counter == risorsa.ovest)
                                dado = Turno(risorsa, risorsa.ovest);
                            else
                                return;
                            break;
                    }
                }
            }
        }

        private int Turno(Risorsa r, int giocatore)
        {
            int giocata = dado.Next(1, 12) + 1;
            r.AggiungiGiocata(giocatore, giocata);
            if (r.Counter == 3)
            {
                r.AddVittoria();
                r.AnnullaGiocataPrec();
                r.Counter = 0;
                r.CambioTurno();
            }
            else
                r.Counter++;
            return giocata;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private string BgwId(BackgroundWorker sender)
        {
            if (sender as BackgroundWorker == bgw_nord)
                return "nord"; 
            else
            {
                if (sender as BackgroundWorker == bgw_est)
                    return "est";
                else 
                {
                    if (sender as BackgroundWorker == bgw_sud)
                        return "sud";
                    else 
                    {
                        if (sender as BackgroundWorker == bgw_ovest)
                            return "ovest";
                        else return null;
                    }
                }
            }
        }
    }
    public class Risorsa
    {
        public int nord, est, sud, ovest;
        public int Counter { get; set; }
        int[] giocate;
        List<char> vittorie;
        List<char> classifica;
        public Risorsa(List<char> v, List<char> c)
        {
            nord = 0; est = 1; sud = 2; ovest = 3; Counter = 0;
            giocate = new int[4];
            vittorie = v; classifica = c;
        }
        public void CambioTurno()
        {
            switch (nord) 
            {
                case 0: nord++;
                    break;
                case 1: nord++;
                    break;
                case 2: nord++;
                    break;
                case 3: nord = 0;
                    break;
            }
            switch (sud) 
            {
                case 0:
                    sud++;
                    break;
                case 1:
                    sud++;
                    break;
                case 2:
                    sud++;
                    break;
                case 3:
                    sud = 0;
                    break;
            }
            switch (ovest) 
            {
                case 0:
                    ovest++;
                    break;
                case 1:
                    ovest++;
                    break;
                case 2:
                    ovest++;
                    break;
                case 3:
                    ovest = 0;
                    break;
            }
            switch (est) 
            {
                case 0:
                    est++;
                    break;
                case 1:
                    est++;
                    break;
                case 2:
                    est++;
                    break;
                case 3:
                    est = 0;
                    break;
            }
        }
        public void AggiungiGiocata(int index, int giocata)
        {
            giocate[index] = giocata;
        }
        char VincitoreMano()
        {
            int index = 0;
            for (int i = 0; i < 4; i++)
                if (giocate[i] > giocate[index])
                    index = i;
            if (nord == index) return 'N';
            if (est == index) return 'E';
            if (sud == index) return 'S';
            if (ovest == index) return 'W';
            else return ' ';
        }
        public void AddVittoria()
        {
            vittorie.Add(VincitoreMano());
        }
        public void AnnullaGiocataPrec()
        {
            giocate = new int[4];
        }
        public string[] ClassificaFinale()
        {
            return null;
        }
        public string[] ClassificaParziale()
        {
                int[] gc = new int[4];
                for (int i = 0; i < 4; i++)
                    gc[i] = giocate[i];
                string[] cl = new string[4];
                cl[nord] = "Nord";
                cl[est] = "Est";
                cl[sud] = "Sud";
                cl[ovest] = "Ovest";
                for (int i = 0; i < 4; i++)
                    for (int j = 1; j < 4; j++)
                    {
                        if (gc[j] < gc[j - 1])
                        {
                            int x = giocate[j];
                            gc[j] = gc[j - 1];
                            gc[j - 1] = x;
                            string s = cl[j];
                            cl[j] = cl[j - 1];
                            cl[j - 1] = s;
                        }
                    }
                return cl;
        }
    }
}
