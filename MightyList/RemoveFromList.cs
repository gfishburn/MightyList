using System;
using System.Linq;
using System.Windows.Forms;

namespace MightyList
{
    public class RemoveFromList
    {
        private const string SectionDivider = "===============================================================================";

        public RemoveFromList() { }

        private static void Header(string listType)
        {
            Console.WriteLine();
            Console.WriteLine(SectionDivider);
            Console.WriteLine("\t\t\tRemoving from " + listType + " List - " + DateTime.Now.ToString("MM.dd.yyyy"));
            Console.WriteLine(SectionDivider);
        }

        private static int Footer()
        {
            char choice;
            Console.WriteLine(SectionDivider);

            // Check if the user still wants to add an item
            Console.Write("\nWould you like to remove an item (Y/N)?: ");

            do
            {
                choice = Console.ReadKey(true).KeyChar;

                if (choice == 'Y' || choice == 'y')
                {
                    Console.Write("\n\nEnter item number to remove: ");

                    int itemNumber = -1;
                    if (int.TryParse(Console.ReadLine(), out itemNumber))
                        return itemNumber;
                    else
                        return 0;
                }
            } while (choice != 'N' && choice != 'n');

            return -1;
        }

        public static void RemoveItem(string listType, List list)
        {
            bool done = false;

            while (!done)
            {
                Console.Clear();

                Header(listType);

                if (list.ListData.Count == 0)
                    Console.WriteLine("Your list is empty! Have a great day!");
                else
                    for (int i = 0; i < list.ListData.Count; i++)
                        Console.WriteLine((i + 1) + ". " + list.ListData.ElementAt(i));

                int itemNumber = Footer();

                if (itemNumber == -1)
                    done = true;
                else if (list.ListData.Count > itemNumber - 1 && itemNumber - 1 >= 0)
                {
                    string removedItem = list.ListData.ElementAt(itemNumber - 1);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the following item: \'" + removedItem + "\'",
                        "Remove Item?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        list.RemoveItem(itemNumber - 1);
                    }
                }
                else
                    MessageBox.Show("Invalid Item Number!");
            }
        }
    }
}
