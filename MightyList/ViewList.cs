using System;
using System.Collections.Generic;
using System.Linq;

namespace MightyList
{
    public class ViewList
    {
        private const string SectionDivider = "===============================================================================";

        public ViewList() { }

        private static void Header(string listType)
        {
            Console.WriteLine();
            Console.WriteLine(SectionDivider);
            Console.WriteLine("\t\t\tViewing " + listType + " List - " + DateTime.Now.ToString("MM.dd.yyyy"));
            Console.WriteLine(SectionDivider);
        }

        private static void Footer()
        {
            Console.WriteLine(SectionDivider);
            Console.Write("\nPress any key to return to Home Page: ");

            // Wait until any key is pressed to return
            Console.ReadKey();
        }

        public static void DisplayList(string listType, List<string> list)
        {
            Console.Clear();

            Header(listType);

            if (list.Count == 0)
                Console.WriteLine("Your list is empty! Have a great day!");
            else
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine((i + 1) + ". " + list.ElementAt(i));

            Footer();
        }
    }
}
