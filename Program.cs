using System;
using System.Collections.Generic;

namespace PMRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            var pmRecord = new SortedDictionary<int, String>(); // Using SortedDictionary for sorted records
            pmRecord.Add(1998, "Atal Bihari Vajpayee");
            pmRecord.Add(2014, "Narendra Modi");
            pmRecord.Add(2004, "Manmohan Singh");
            Console.Write("\nShowing the Prime Minister of Year 2004 : ");
            Console.WriteLine(pmRecord[2004]);
            Console.WriteLine("Adding Current PM...");
            pmRecord.Add(2019, "Narendra Modi");
            Console.WriteLine("Current PM added!\n");
            Console.WriteLine("Showing records in sorted year :\n");
            foreach(var i in pmRecord)
            {
                Console.WriteLine(i);
            }
        }
    }
}
