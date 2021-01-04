using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Remove
    {
        public static void ASongByOrderNumber()
        {
            var willTheUserGoAgain = false;
            var orderNumber = 0;
            do
            {
                orderNumber = Decision.CheckingIfTheUserEnteredANumber();
                willTheUserGoAgain = Decision.WillTheUserGoAgain();
            } while (willTheUserGoAgain);

            if (!DataStore.PlayList.ContainsKey(orderNumber))
            {
                Console.WriteLine("Broj koji ste unijeli ne postoji.");
                return;
            }
            else
            {
                for (var i = orderNumber; i <= DataStore.PlayList.Count - 1; i++)
                {
                    DataStore.PlayList[i] = DataStore.PlayList[i + 1];
                }
                DataStore.PlayList.Remove(DataStore.PlayList.Count);
            }
        }

        public static void ASongByName()
        {
            var willTheUserGoAgain = false;
            var song = "";
            do
            {
                Console.WriteLine("Unesite ime pjesme:");
                song = Console.ReadLine();
                willTheUserGoAgain = Decision.WillTheUserGoAgain();
            } while (willTheUserGoAgain);

            if (!DataStore.PlayList.ContainsValue(song))
            {
                Console.WriteLine("Pjesma koju ste unijeli se ne nalazi u listi postojećih pjesama. Vraćate se na glavni izbornik.");
                return;
            }
            else
            {
                foreach (KeyValuePair<int, string> kvp in DataStore.PlayList)
                {
                    if (kvp.Value.ToLower() == song.ToLower())
                    {
                        for (var i = kvp.Key; i <= DataStore.PlayList.Count - 1; i++)
                        {
                            DataStore.PlayList[i] = DataStore.PlayList[i + 1];
                        }
                        DataStore.PlayList.Remove(DataStore.PlayList.Count);
                        return;
                    }
                }
            }
        }
    }
}
