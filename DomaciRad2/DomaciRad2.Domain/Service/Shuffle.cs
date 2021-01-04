using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class Shuffle
    {
        public static void Songs()
        {
            Random rnd = new Random();
            var List = new List<string>();

            foreach (KeyValuePair<int, string> kvp in DataStore.PlayList)
                List.Add(kvp.Value);

            var numberOfSongs = List.Count;

            while(numberOfSongs > 1)
            {
                numberOfSongs--;
                var randomNumber = rnd.Next(numberOfSongs + 1);
                var value = List[randomNumber];
                List[randomNumber] = List[numberOfSongs];
                List[numberOfSongs] = value;
            }
        }
    }
}
