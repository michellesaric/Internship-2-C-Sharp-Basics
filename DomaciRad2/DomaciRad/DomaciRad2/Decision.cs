using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Decision
    {
        public static bool WillTheUserGoAgain()
        {
            Console.WriteLine("Jeste li sigurni da želite izvesti promjenu? Upišite 'ne' ako želite probati ponovno, bilo koji drugi input potvrđuje vašu akciju.");
            var decision = Console.ReadLine();
            if (decision.ToLower() == "ne")
            {
                return false;
            }
            else
                return true;
        }

        public static int CheckingIfTheUserEnteredANumber()
        {
            var number = 0;
            var isNumberInput = false;
            Console.WriteLine("Unesite redni broj:");
            do
            {
                isNumberInput = int.TryParse(Console.ReadLine(), out number);
            } while (!isNumberInput);
            return number;
        }
    }
}
