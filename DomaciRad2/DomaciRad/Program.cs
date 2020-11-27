using System;
using System.Collections.Generic;
using System.Linq;

namespace PrvaVjezba
{
    class Program
    {
        static void Main(string[] args)
        {
            var PlayList = new Dictionary<int, string>()
            {
                {1, "Iron Maiden - The Wicker Man"},
                {2, "Iron Maiden - Dance of the Dead"},
                {3, "AC/DC - TNT"},
                {4, "Billy Idol - Rebel Yell"},
                {5, "Billy Idol - White Wedding"},
                {6, "AC/DC - Thunderstruck"},
                {7, "Iron Maiden - The Trooper" },
                {8, "Iron Maiden - Aces High" },
                {9, "Whitesnake - Here I go again" },
                {10, "Aerosmith - Dream On" },
                {11, "Aerosmith - Janie's got a gun" }
            };

            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis cijele liste");
            Console.WriteLine("2 - Ipis imena pjesme unosom pripadajuceg rednog broja");
            Console.WriteLine("3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
            Console.WriteLine("4 - Unos nove pjesme");
            Console.WriteLine("5 - Brisanje pjesme po rednom broju");
            Console.WriteLine("6 - Brisanje pjesme po imenu");
            Console.WriteLine("7 - Brisanje cijele liste");
            Console.WriteLine("8 - Uređivanje imena pjesme");
            Console.WriteLine("9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi");
            Console.WriteLine("0 - Izlaz iz apliacije");

            int x = int.Parse(Console.ReadLine());
            int a = 1, z = 0;
            int brojac = 0;
            Random rnd = new Random();

            switch (x)
            {
                case 1:
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
                    break;
                case 2:
                    Console.WriteLine("Unesite redni broj:");
                    int y = int.Parse(Console.ReadLine());
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Key == y)
                        {
                            Console.WriteLine("{1}", kvp.Value);
                            brojac++;
                        }
                    }
                    if(brojac == 0)
                    {
                        Console.WriteLine("Broj koji ste unijeli ne postoji");
                        break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Unesite ime pjesme:");
                    string song = Console.ReadLine();
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Value == song)
                        {
                            Console.WriteLine("{0}.", kvp.Key);
                            brojac++;
                        }
                    }
                    if(brojac == 0)
                    {
                        Console.WriteLine("Ime pjesme koje ste upisali se ne nalazi u listi");
                        break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Unesite novu pjesmu:");
                    song = Console.ReadLine();

                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Value == song)
                            brojac++;
                    }
                    if (brojac == 1)
                    {
                        Console.WriteLine("Ova pjesma vec postoji");
                        break;
                    }
                    else
                        PlayList.Add(PlayList.Count + 1, song);

                    break;
                case 5:
                    Console.WriteLine("Unesite redni broj:");
                    y = int.Parse(Console.ReadLine());
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Key == y)
                        {
                            PlayList.Remove(kvp.Key);
                            brojac++;
                        }
                    }
                    if(brojac == 0)
                    {
                        Console.WriteLine("Redni broj koji ste unijeli ne postoji u listi");
                        break;
                    }
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
                    break;
                case 6:
                    Console.WriteLine("Unesite ime pjesme:");
                    song = Console.ReadLine();
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Value == song)
                        {
                            PlayList.Remove(kvp.Key);
                            brojac++;
                        }
                    }
                    if (brojac == 0)
                    {
                        Console.WriteLine("Ime pjesme koju ste unijeli ne postoji u listi");
                        break;
                    }
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
                    break;
                case 7:
                    PlayList.Clear();
                    break;
                case 8:
                    Console.WriteLine("Unesite redni broj pjesme koje zelite editirati:");
                    y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite edit:");
                    string ssong = Console.ReadLine();
                    PlayList[y] = ssong;
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
                    break;

                case 9:
                    Console.WriteLine("Unesite pjesmu koju zelite zamijeniti");
                    song = Console.ReadLine();
                    Console.WriteLine("Unesite na koji redni broj je zelite stavit");
                    y = int.Parse(Console.ReadLine());
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                    {
                        if (kvp.Value == song)
                        {
                            brojac++;
                            if (kvp.Key > y)
                                a = 0;
                            z = kvp.Key;
                        }
                        if (kvp.Key == y)
                            brojac++;
                    }
                    if(brojac == 0)
                    {
                        Console.WriteLine("Pjesma ili redni broj koji ste unijeli nisu u playlisti");
                        break;
                    }
                    if (a == 0)
                    {
                        while (z >= y + 1)
                        {
                            PlayList[z] = PlayList[z - 1];
                            z--;
                        }
                        PlayList[y] = song;
                    }
                    else
                    {
                        while (z <= y - 1)
                        {
                            PlayList[z] = PlayList[z + 1];
                            z++;
                        }
                        PlayList[y] = song;
                    }
                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                case 10:
                    PlayList = PlayList.OrderBy(x => rnd.Next())
                        .ToDictionary(item => item.Key, item => item.Value);

                    foreach (KeyValuePair<int, string> kvp in PlayList)
                        Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);

                    break;

                default:
                    Console.WriteLine("Niste upisali dobar broj");
                    break;
            }
        }

    }
}
