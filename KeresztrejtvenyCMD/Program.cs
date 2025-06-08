namespace KeresztrejtvenyCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!no | ez a feladat kikészít");

            string[] forrasok = { "../../../kr1.txt", "../../../kr2.txt" }; //további források itt adhatóak hozzá
            string forras = forrasok[0]; //forrás kiválasztása

            var racs = new KeresztrejtvenyRacs(forras);

            Console.WriteLine();


            Console.WriteLine("5. feladat: A keresztrejtvény mérete");
            Console.WriteLine($"\tSorok száma: {racs.SorokDb}");
            Console.WriteLine($"\tOszlopok száma: {racs.OszlopokDb}");

            Console.WriteLine("6. feladat: A beolvasott keresztrejtvény");
            racs.KiirRacs();

            Console.WriteLine($"7. feladat: A leghosszabb függ.: {racs.LegFugSzo()} karakter");

            Console.WriteLine("8. feladat: Vízszintes szavak statisztikája");
            List<VizszintStatisztika> stat = racs.VSZStat();
            foreach (VizszintStatisztika adat in stat) Console.WriteLine($"\t{adat.Hossz} betűs: {adat.Darab} darab");

            Console.WriteLine("9. feladat: A keresztrejtvény számokkal");
            racs.MegSzamoz();


            Console.WriteLine();
        }
    }
}
