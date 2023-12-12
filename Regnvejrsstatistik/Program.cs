namespace Regnvejrsstatistik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] ugentligNedbør = new double[7];
            InitializeArray(ugentligNedbør);

            int valg;
            do
            {
                Console.WriteLine("\nVejr App Menu:");
                Console.WriteLine("1. Indtast Nedbørsdata for Ugen");
                Console.WriteLine("2. Beregn Statistik for en Bestemt Dag");
                Console.WriteLine("3. Beregn Statistik for Hele Ugen");
                Console.WriteLine("4. Afslut");
                Console.Write("Indtast dit valg (1-4): ");

                if (int.TryParse(Console.ReadLine(), out valg))
                {
                    switch (valg)
                    {
                        case 1:
                            IndtastUgentligNedbør(ugentligNedbør);
                            break;
                        case 2:
                            BeregnDagligStatistik(ugentligNedbør);
                            break;
                        case 3:
                            BeregnUgeStatistik(ugentligNedbør);
                            break;
                        case 4:
                            Console.WriteLine("Afslutter Vejr App. Farvel!");
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg. Indtast venligst et nummer mellem 1 og 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldig indtastning. Indtast venligst et gyldigt nummer.");
                }

            } while (valg != 4);
        }

        static void InitializeArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        static void IndtastUgentligNedbør(double[] ugentligNedbør)
        {
            string[] ugedage = { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };

            for (int dag = 0; dag < ugentligNedbør.Length; dag++)
            {
                Console.Write($"Indtast nedbør for {ugedage[dag]} (mm): ");
                double nedbør;
                while (!double.TryParse(Console.ReadLine(), out nedbør))
                {
                    Console.WriteLine("Ugyldig indtastning. Indtast venligst et gyldigt nummer.");
                    Console.Write($"Indtast nedbør for {ugedage[dag]} (mm): ");
                }

                ugentligNedbør[dag] = nedbør;
            }

            Console.WriteLine("\nUgentlig nedbørsdata indtastet succesfuldt!");
        }

        static void BeregnDagligStatistik(double[] ugentligNedbør)
        {
            string[] ugedage = { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };

            Console.Write("Indtast dagen, hvor du vil beregne statistik: ");
            string valgtDag = Console.ReadLine();

            int dagIndex = Array.IndexOf(ugedage, valgtDag);
            if (dagIndex != -1)
            {
                Console.WriteLine($"\nStatistik for {valgtDag}:");
                Console.WriteLine($"Nedbør: {ugentligNedbør[dagIndex]} mm");
            }
            else
            {
                Console.WriteLine("Ugyldig dag. Indtast venligst en gyldig ugedag.");
            }
        }

        static void BeregnUgeStatistik(double[] ugentligNedbør)
        {
            double samletNedbør = 0;
            double maksNedbør = double.MinValue;
            double minNedbør = double.MaxValue;

            for (int dag = 0; dag < ugentligNedbør.Length; dag++)
            {
                double nedbør = ugentligNedbør[dag];
                samletNedbør += nedbør;

                if (nedbør > maksNedbør)
                {
                    maksNedbør = nedbør;
                }

                if (nedbør < minNedbør)
                {
                    minNedbør = nedbør;
                }
            }

            double gennemsnitligNedbør = samletNedbør / ugentligNedbør.Length;

            Console.WriteLine("\nUgestatistik:");
            Console.WriteLine($"Gennemsnitlig Nedbør: {gennemsnitligNedbør:F2} mm");
            Console.WriteLine($"Maksimal Nedbør på en Dag: {maksNedbør} mm");
            Console.WriteLine($"Minimal Nedbør på en Dag: {minNedbør} mm");
        }
    }
}
