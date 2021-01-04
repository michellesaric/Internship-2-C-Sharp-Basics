using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Find
    {
        public static void ANameByAnOrderNumber()
        {
            var orderNumber = Decision.CheckingIfTheUserEnteredANumber();

            if (DataStore.PlayList.ContainsKey(orderNumber))
            {
                Console.WriteLine(DataStore.PlayList[orderNumber]);
                return;
            }
            else
            {
                Console.WriteLine("Broj koji ste upisali ne postoji");
                return;
            }
        }
        public static void AnOrderNumberByAName()
        {
            Console.WriteLine("Unesite ime pjesme:");
            var song = Console.ReadLine();

            foreach (KeyValuePair<int, string> kvp in DataStore.PlayList)
            {
                if (kvp.Value.ToLower() == song.ToLower())
                {
                    Console.WriteLine(kvp.Key + ".");
                    return;
                }
            }
            Console.WriteLine("Ime pjesme koje ste upisali se ne nalazi u listi");
            return;
        }
    }
}
