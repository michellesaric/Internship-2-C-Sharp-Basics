using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Edit
    {
        public static void ASongName()
        {
            var willTheUserGoAgain = false;
            var orderNumber = 0;
            var edit = "";
            do
            {
                orderNumber = Decision.CheckingIfTheUserEnteredANumber();

                if (!DataStore.PlayList.ContainsKey(orderNumber))
                {
                    Console.WriteLine("Redni broj koji ste unijeli ne postoji.");
                    return;
                }
                Console.WriteLine("Unesite edit:");
                edit = Console.ReadLine();
                willTheUserGoAgain = Decision.WillTheUserGoAgain();

            } while (willTheUserGoAgain);

            if (DataStore.PlayList.ContainsValue(edit))
            {
                Console.WriteLine("Ova pjesma već postoji u listi.");
                return;
            }
            else
            {
                DataStore.PlayList[orderNumber] = edit;
                return;
            }
        }
    }
}
