namespace KeresztrejtvenyCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!no | ez a feladat kikészít");

            //string forras = "../../../kr1.txt";
            string forras = "../../../kr2.txt";

            var racs = new KeresztrejtvenyRacs(forras);

            Console.WriteLine();


            Console.WriteLine("5. feladat: A keresztrejtvény mérete");
            Console.WriteLine($"\tSorok száma: {racs.SorokDb}");
            Console.WriteLine($"\tOszlopok száma: {racs.OszlopokDb}");

            Console.WriteLine("6. feladat: A beolvasott keresztrejtvény");
            racs.KiirRacs();

            Console.WriteLine($"7. feladat: A leghosszabb függ.: {racs.LegFugSzo()} karakter"); //nem működik megfelelően

            Console.WriteLine("8. feladat: Vízszintes szavak statisztikája");
            List<VizszintStatisztika> stat = racs.VSZStat();
            foreach (VizszintStatisztika adat in stat) Console.WriteLine($"\t{adat.Hossz} betűs: {adat.Darab} darab");
        }
    }
}
