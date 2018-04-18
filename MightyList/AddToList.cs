using System;
using System.Linq;
using System.Windows.Forms;

namespace MightyList
{
    public class AddToList
    {
        private const string SectionDivider = "===============================================================================";

        public AddToList() { }

        private static void Header(string listType)
        {
            Console.WriteLine();
            Console.WriteLine(SectionDivider);
            Console.WriteLine("\t\t\tAdding to " + listType + " List - " + DateTime.Now.ToString("MM.dd.yyyy"));
            Console.WriteLine(SectionDivider);
        }

        private static string Footer()
        {
            char choice;
            Console.WriteLine(SectionDivider);

            // Check if the user still wants to add an item
            Console.Write("\nWould you like to add an item (Y/N)?: ");

            do
            {
                choice = Console.ReadKey(true).KeyChar;

                if (choice == 'Y' || choice == 'y')
                {
                    Console.Write("\n\nWrite item to add to list: ");
                    return Console.ReadLine();
                }
            } while (choice != 'N' && choice != 'n');

            return null;
        }

        public static void AddItem(string listType, List list)
        {
            bool done = false;

            while(!done)
            {
                Console.Clear();

                Header(listType);

                if (list.ListData.Count == 0)
                    Console.WriteLine("Your list is empty! Have a great day!");
                else
                    for (int i = 0; i < list.ListData.Count; i++)
                        Console.WriteLine((i + 1) + ". " + list.ListData.ElementAt(i));

                string itemToAdd = Footer();

                if (itemToAdd == null)
                    done = true;
                else if (itemToAdd != "")
                    list.AddItem(itemToAdd);
                else
                    MessageBox.Show("You can't add an empty item!");
            }
        }
    }
}
