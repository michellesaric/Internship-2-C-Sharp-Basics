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
                Print.Menu();

                var option = int.Parse(Console.ReadLine());
                Random rnd = new Random();

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
                        Shuffle(PlayList);
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
        static void Shuffle(Dictionary<int, string> Playlist)
        {
            var pomocnaLista = new List<int>();
            Random rnd = new Random();


            for (int i = 0; i < Playlist.Count; i++)
                pomocnaLista[i] = i + 1;

            while(pomocnaLista.Count > 0)
            {
                var RandomNumber = rnd.Next(Playlist.Count);
                if(pomocnaLista[RandomNumber] == RandomNumber + 1)
                {
                    var a = pomocnaLista[RandomNumber];
                    Console.WriteLine(Playlist[a]);
                    pomocnaLista.Remove(RandomNumber);
                }
            }
        }
    }
}
