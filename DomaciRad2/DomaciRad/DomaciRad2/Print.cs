using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Print
    {
        public static void List()
        {
            foreach (KeyValuePair<int, string> kvp in DataStore.PlayList)
                Console.WriteLine(kvp.Key + ". " + kvp.Value);
        }
        public static void Menu()
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
        }
    }
}
