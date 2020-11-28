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
            do
            {
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
                Console.WriteLine("10 - Shuffle pjesama");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                int x = int.Parse(Console.ReadLine());
                Random rnd = new Random();

                switch (x)
                {
                    case 1:
                        PrintingTheEntireList(PlayList);
                        break;
                    case 2:
                        FindingNameByOrderNumber(PlayList);
                        break;
                    case 3:
                        FindingOrderNumberByName(PlayList);
                        break;
                    case 4:
                        EnteringANewSong(PlayList);
                        break;
                    case 5:
                        RemovingSongByOrderNumber(PlayList);
                        break;
                    case 6:
                        RemovingSongByName(PlayList);
                        break;
                    case 7:
                        PlayList.Clear();
                        break;

                    case 8:
                        EditingSongName(PlayList);
                        break;

                    case 9:
                        ChangingOrderNumberForASong(PlayList);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 10:
                        PlayList = PlayList.OrderBy(x => rnd.Next())
                            .ToDictionary(item => item.Key, item => item.Value);
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
        static void PrintingTheEntireList(Dictionary<int, string> Playlist)
        {
            foreach (KeyValuePair<int, string> kvp in Playlist)
                Console.WriteLine(kvp.Key + ". " + kvp.Value);
        }
        static void FindingNameByOrderNumber(Dictionary<int, string> Playlist)
        {
            var counter = 0;

            Console.WriteLine("Unesite redni broj:");
            var orderNumber = int.Parse(Console.ReadLine());

            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Key == orderNumber)
                {
                    Console.WriteLine(kvp.Value);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Broj koji ste unijeli ne postoji");
                return;
            }
            return;
        }
        static void FindingOrderNumberByName(Dictionary<int, string> Playlist)
        {
            var counter = 0;

            Console.WriteLine("Unesite ime pjesme:");
            var song = Console.ReadLine();

            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Value == song)
                {
                    Console.WriteLine(kvp.Key + ".");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Ime pjesme koje ste upisali se ne nalazi u listi");
                return;
            }
            return;
        }
        static void EnteringANewSong(Dictionary<int, string> Playlist)
        {
            var counter = 0;

            Console.WriteLine("Unesite novu pjesmu:");
            var song = Console.ReadLine();

            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Value == song)
                    counter++;
            }
            if (counter == 1)
            {
                Console.WriteLine("Ova pjesma vec postoji");
                return;
            }
            else
                Playlist.Add(Playlist.Count + 1, song);
            return;
        }
        static void RemovingSongByOrderNumber(Dictionary<int, string> Playlist)
        {
            var counter = 0;

            Console.WriteLine("Unesite redni broj:");
            var orderNumber = int.Parse(Console.ReadLine());
            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Key == orderNumber)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Redni broj koji ste unijeli ne postoji u listi");
                return;
            }
            var endOfPlaylist = Playlist.Count;
            while (orderNumber <= endOfPlaylist - 1)
            {
                Playlist[orderNumber] = Playlist[orderNumber + 1];
                orderNumber++;
            }
            Playlist.Remove(Playlist.Count);
            return;
        }
        static void RemovingSongByName(Dictionary<int, string> Playlist)
        {
            var counter = 0;
            var orderNumber = 0;

            Console.WriteLine("Unesite ime pjesme:");
            var song = Console.ReadLine();

            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Value == song)
                {
                    orderNumber = kvp.Key;
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Ime pjesme koju ste unijeli ne postoji u listi");
                return;
            }
            var endOfPlaylist = Playlist.Count;
            while (orderNumber <= endOfPlaylist - 1)
            {
                Playlist[orderNumber] = Playlist[orderNumber + 1];
                orderNumber++;
            }
            Playlist.Remove(Playlist.Count);
            return;

        }
        static void EditingSongName(Dictionary<int, string> Playlist) 
        {
            var counter = 0;

            Console.WriteLine("Unesite redni broj pjesme koje zelite editirati:");
            var orderNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite edit:");
            var song = Console.ReadLine();
            foreach(KeyValuePair<int,string> kvp in Playlist)
            {
                if (kvp.Key == orderNumber)
                    counter++;
            }
            if(counter == 0)
            {
                Console.WriteLine("Redni broj pjesme koji ste unijeli ne postoji");
                return;
            }
            Playlist[orderNumber] = song;
            return;
        }
        static void ChangingOrderNumberForASong(Dictionary<int, string> Playlist)
        {
            var counter = 0;
            var checkingWetherLessOrMore = 0;
            var endingOrderNumber = 0;

            Console.WriteLine("Unesite pjesmu koju zelite zamijeniti");
            var song = Console.ReadLine();

            Console.WriteLine("Unesite na koji redni broj je zelite staviti");
            var orderNumber = int.Parse(Console.ReadLine());
            foreach (KeyValuePair<int, string> kvp in Playlist)
            {
                if (kvp.Value == song)
                {
                    counter++;
                    if (kvp.Key > orderNumber)
                        checkingWetherLessOrMore = 0;
                        endingOrderNumber = kvp.Key;
                }
                if (kvp.Key == orderNumber)
                    counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("Pjesma ili redni broj koji ste unijeli nisu u playlisti");
                return;
            }
            if (checkingWetherLessOrMore == 0)
            {
                while (endingOrderNumber >= orderNumber + 1)
                {
                    Playlist[endingOrderNumber] = Playlist[endingOrderNumber - 1];
                    endingOrderNumber--;
                }
                Playlist[orderNumber] = song;
            }
            else
            {
                while (endingOrderNumber <= orderNumber - 1)
                {
                    Playlist[endingOrderNumber] = Playlist[endingOrderNumber + 1];
                    endingOrderNumber++;
                }
                Playlist[orderNumber] = song;
            }
            return;
        }
    }
}
