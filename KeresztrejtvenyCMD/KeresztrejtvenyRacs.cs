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
        private int[,] Sorszamok;

        public int SorokDb { get; private set; }
        public int OszlopokDb { get; private set; }

        public KeresztrejtvenyRacs(string forras)
        {
            BeolvasAdatsorok(forras);

            SorokDb = Adatsorok.Count;
            OszlopokDb = Adatsorok[0].Length;

            // Inicializálás +2 sorral és oszloppal (keret)
            Racs = new char[SorokDb + 2, OszlopokDb + 2];
            Sorszamok = new int[SorokDb + 2, OszlopokDb + 2];

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
                Console.Write("\t");
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '-')
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
            int leghoszever = 0;
            
            for (int i = 1; i <= OszlopokDb; i++)
            {
                int leghoszjelen = 0;

                for (int j = 1; j <= SorokDb; j++)
                {
                    if (Racs[j, i] == '-')
                    {
                        leghoszjelen++;
                    }
                    else
                    {
                        if (leghoszjelen > leghoszever) leghoszever = leghoszjelen;

                        leghoszjelen = 0;
                    }
                }

                if (leghoszjelen > leghoszever) leghoszever = leghoszjelen;

                leghoszjelen = 0;
            }

            return leghoszever;
        }

        public List<VizszintStatisztika> VSZStat()
        {
            Dictionary<int, int> statD = new Dictionary<int, int>();

            for (int i = 1; i <= SorokDb; i++)
            {
                int hossz = 0;

                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '-')
                    {
                        hossz++;
                    }
                    else
                    {
                        if (hossz >= 2)
                        {
                            if (statD.ContainsKey(hossz)) statD[hossz]++;
                            else statD[hossz] = 1;
                        }
                        hossz = 0;
                    }
                }

                if (hossz >= 2)
                {
                    if (statD.ContainsKey(hossz)) statD[hossz]++;
                    else statD[hossz] = 1;
                }
            }

            List<VizszintStatisztika> stat = new List<VizszintStatisztika>();

            foreach (var kvp in statD.OrderBy(x => x.Key))
            {
                stat.Add(new VizszintStatisztika(kvp.Key) { Darab = kvp.Value });
            }

            return stat;
        }

        public void MegSzamoz()
        {
            int szam = 1;

            for (int i = 1; i <= SorokDb; i++)
            {
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '-')
                    {
                        bool vizszintes = (Racs[i, j - 1] == '#' || j == 1) && Racs[i, j + 1] == '-';
                        bool fuggoleges = (Racs[i - 1, j] == '#' || i == 1) && Racs[i + 1, j] == '-';

                        if (vizszintes || fuggoleges)
                        {
                            Sorszamok[i, j] = szam;
                            szam++;
                        }
                    }
                }
            }

            for (int i = 1; i <= SorokDb; i++)
            {
                Console.Write("\t");
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    int sorszam = Sorszamok[i, j];

                    if (Racs[i, j] == '#') Console.Write("##");
                    else if (sorszam > 0) Console.Write(sorszam.ToString("D2")); // 2 karakteres szám
                    else Console.Write("[]");
                }
                Console.WriteLine();
            }
        }
    }
}
