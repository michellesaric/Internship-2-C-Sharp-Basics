using DomaciRad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrvaVjezba
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Print.Menu();

                var option = Decision.CheckingIfTheUserEnteredANumber();

                switch (option)
                {
                    case 1:
                        Print.List();
                        break;
                    case 2:
                        Find.ANameByAnOrderNumber();
                        break;
                    case 3:
                        Find.AnOrderNumberByAName();
                        break;
                    case 4:
                        Add.NewSong();
                        break;
                    case 5:
                        Remove.ASongByOrderNumber();
                        break;
                    case 6:
                        Remove.ASongByName();
                        break;
                    case 7:
                        DataStore.PlayList.Clear();
                        break;
                    case 8:
                        Edit.ASongName();
                        break;
                    case 9:
                        Exchange.Positions();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 10:
                        Shuffle.Songs();
                        break;
                    default:
                        Console.WriteLine("Niste upisali dobar broj");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            while (true);
        }
    }
}
