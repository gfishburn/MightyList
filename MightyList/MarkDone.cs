using System;
using System.Linq;
using System.Windows.Forms;

namespace MightyList
{
    public class MarkDone
    {
        private const string SectionDivider = "===============================================================================";

        public MarkDone() { }

        private static void Header()
        {
            Console.WriteLine();
            Console.WriteLine(SectionDivider);
            Console.WriteLine("\t\tMarking To-Do List Items Done - " + DateTime.Now.ToString("MM.dd.yyyy"));
            Console.WriteLine(SectionDivider);
        }

        private static int Footer()
        {
            char choice;
            Console.WriteLine(SectionDivider);

            // Check if the user still wants to add an item
            Console.Write("\nWould you like to mark an item done (Y/N)?: ");

            do
            {
                choice = Console.ReadKey(true).KeyChar;

                if (choice == 'Y' || choice == 'y')
                {
                    Console.Write("\n\nEnter item number to mark done: ");

                    int itemNumber = -1;
                    if (int.TryParse(Console.ReadLine(), out itemNumber))
                        return itemNumber;
                    else
                        return 0;
                }
            } while (choice != 'N' && choice != 'n');

            return -1;
        }

        public static void MarkItemDone(List toDoList, List completedList)
        {
            bool done = false;

            while (!done)
            {
                Console.Clear();

                Header();

                if (toDoList.ListData.Count == 0)
                    Console.WriteLine("Your list is empty! Have a great day!");
                else
                    for (int i = 0; i < toDoList.ListData.Count; i++)
                        Console.WriteLine((i + 1) + ". " + toDoList.ListData.ElementAt(i));

                int itemNumber = Footer();

                if (itemNumber == -1)
                    done = true;
                else if (toDoList.ListData.Count > itemNumber - 1 && itemNumber - 1 >= 0)
                {
                    string itemMarkedDone = toDoList.ListData.ElementAt(itemNumber - 1);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to mark the following item done: \'" + itemMarkedDone + "\'",
                        "Mark Item Done?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        toDoList.RemoveItem(itemNumber - 1);
                        completedList.AddItem(itemMarkedDone);
                    }
                }
                else
                    MessageBox.Show("Invalid Item Number!");
            }
        }
    }
}
