using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Add
    {
        public static void NewSong()
        {
            var willTheUserGoAgain = false;
            var song = "";
            do
            {
                Console.WriteLine("Unesite novu pjesmu:");
                song = Console.ReadLine();
                willTheUserGoAgain = Decision.WillTheUserGoAgain();
            } while (willTheUserGoAgain);

            if (DataStore.PlayList.ContainsValue(song))
            {
                Console.WriteLine("Ova pjesma već postoji.");
                return;
            }
            else
            {
                DataStore.PlayList.Add(DataStore.PlayList.Count + 1, song);
                return;
            }
        }
    }
}
