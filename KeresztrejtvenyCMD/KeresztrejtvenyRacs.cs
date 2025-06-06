using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeresztrejtvenyCMD
{
    internal class KeresztrejtvenyRacs
    {
        private List<string> Adatsorok;
        private char[,] Racs;
        private int[] Sorszamok;

        public int SorokDb { get; private set; }
        public int OszlopokDb { get; private set; }

        public KeresztrejtvenyRacs(string forras)
        {
            BeolvasAdatsorok(forras);

            SorokDb = Adatsorok.Count;
            OszlopokDb = Adatsorok[0].Length;

            // Inicializálás +2 sorral és oszloppal
            Racs = new char[SorokDb + 2, OszlopokDb + 2];
            Sorszamok = new int[SorokDb * OszlopokDb]; // tetszőleges kezdeti méret

            FeltoltRacs();
        }

        private void BeolvasAdatsorok(string forras)
        {
            Adatsorok = new List<string>(File.ReadAllLines(forras));
        }

        private void FeltoltRacs()
        {
            for (int i = 0; i < SorokDb; i++)
            {
                string sor = Adatsorok[i];
                for (int j = 0; j < OszlopokDb; j++)
                {
                    Racs[i + 1, j + 1] = sor[j]; // +1 eltolás keret miatt
                }
            }
        }

        public void KiirRacs()
        {
            for (int i = 1; i <= SorokDb; i++)
            {
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i,j] == '-')
                    {
                        Console.Write("[]");
                    }
                    else if (Racs[i, j] == '#')
                    {
                        Console.Write("##");
                    }
                }
                Console.WriteLine();
            }
        }

        public int LegFugSzo()
        {
            int leghoszjelen = 0;
            int leghoszever = 0;
            
            for (int i = 1; i <= OszlopokDb; i++)
            {
                for (int j = 1; j <= SorokDb; j++)
                {
                    if (Racs[j, i] == '-')
                    {
                        leghoszjelen++;
                    }
                    else if (Racs[j, i] == '#')
                    {
                        if (leghoszjelen > leghoszever)
                        {
                            leghoszever = leghoszjelen;
                        }
                        leghoszjelen = 0;
                    }
                }
                leghoszjelen = 0;
            }

            return leghoszever;
        }

        public int VSZStat()
        {
            List<VizszintStatisztika> stat = new List<VizszintStatisztika>();
            
            for (int i = 1; i <= OszlopokDb; i++)
            {
                for (int j = 1; j <= SorokDb; j++)
                {
                    if (Racs[i, j] == '-')
                    {
                        leghoszjelen++;
                    }
                    else if (Racs[j, i] == '#')
                    {
                        if (leghoszjelen > leghoszever)
                        {
                            leghoszever = leghoszjelen;
                        }
                        leghoszjelen = 0;
                    }
                }
                leghoszjelen = 0;
            }

            return leghoszever;
        }
    }
}
