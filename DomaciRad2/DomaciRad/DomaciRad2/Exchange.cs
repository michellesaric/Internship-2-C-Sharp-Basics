using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Change
    {
        public static void Positions()
        {
            var willTheUserGoAgain = false;
            var song = "";
            var orderNumber = 0;
            do
            {
                Console.WriteLine("Unesite pjesmu koju zelite zamijeniti");
                song = Console.ReadLine();

                if (!DataStore.PlayList.ContainsValue(song))
                {
                    Console.WriteLine("Pjesma koju ste unijeli se ne nalazi u listi postojećih pjesama. Vraćate se na glavni izbornik.");
                    return;
                }

                orderNumber = Decision.CheckingIfTheUserEnteredANumber();

                if (!DataStore.PlayList.ContainsKey(orderNumber))
                {
                    Console.WriteLine("Redni koji ste unijeli se ne nalazi u listi postojećih pjesama. Vraćate se na glavni izbornik.");
                    return;
                }
                willTheUserGoAgain = Decision.WillTheUserGoAgain();
            } while (willTheUserGoAgain);

            foreach (KeyValuePair<int, string> kvp in DataStore.PlayList)
            {
                if (kvp.Value.ToLower() == song.ToLower())
                {
                    if (kvp.Key > orderNumber)
                    {
                        for (var i = kvp.Key; i >= orderNumber + 1; i--)
                        {
                            DataStore.PlayList[i] = DataStore.PlayList[i - 1];
                            i--;
                        }
                        DataStore.PlayList[orderNumber] = song;
                        return;
                    }
                    else if (kvp.Key < orderNumber)
                    {
                        for (var i = kvp.Key; i <= orderNumber - 1; i++)
                        {
                            DataStore.PlayList[i] = DataStore.PlayList[i];
                            i++;
                        }
                        DataStore.PlayList[orderNumber] = song;
                        return;
                    }
                    else
                        return;
                }
            }
        }
    }
}
