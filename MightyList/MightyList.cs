using System;
using System.Windows.Forms;

namespace MightyList
{
    public class MightyList
    {
        private const string SectionDivider = "===============================================================================";

        public MightyList() { }

        private static void Header()
        {
            Console.WriteLine();
            Console.WriteLine(SectionDivider);
            Console.WriteLine("\t\t\t    Mighty List - " + DateTime.Now.ToString("MM.dd.yyyy"));
            Console.WriteLine(SectionDivider);
        }

        private static void HomeScreen()
        {
            Console.WriteLine(" 1. View To-Do List");
            Console.WriteLine(" 2. View Completed List");
            Console.WriteLine(" 3. Add Item to To-Do List");
            Console.WriteLine(" 4. Add Item to Completed List");
            Console.WriteLine(" 5. Remove Item from To-Do List");
            Console.WriteLine(" 6. Remove Item from Completed List");
            Console.WriteLine(" 7. Mark To-Do List Items Done");
            Console.WriteLine(" 8. Combine Duplicates");
        }

        private static void Footer()
        {
            Console.WriteLine(SectionDivider);
            Console.Write("\nPress Action Number: ");
        }

        static void Main(string[] args)
        {
            char input = '0';

            List toDoList = new List("ToDoList.txt");
            List completedList = new List("CompletedList.txt");

            while (true) {
                switch (input)
                {
                    case '1': // View To-Do List
                        ViewList.DisplayList("To-Do", toDoList.ListData);
                        input = '0';
                        break;
                    case '2': // View Completed List
                        ViewList.DisplayList("Completed", completedList.ListData);
                        input = '0';
                        break;
                    case '3': // Add Item to To-Do List
                        AddToList.AddItem("To-Do", toDoList);
                        input = '0';
                        break;
                    case '4': // Add Item to Completed List
                        AddToList.AddItem("Completed", completedList);
                        input = '0';
                        break;
                    case '5': // Remove Item from To-Do List
                        RemoveFromList.RemoveItem("To-Do", toDoList);
                        input = '0';
                        break;
                    case '6': // Remove Item from Completed List
                        RemoveFromList.RemoveItem("Completed", completedList);
                        input = '0';
                        break;
                    case '7': // Mark To-Do List Items Done
                        MarkDone.MarkItemDone(toDoList, completedList);
                        input = '0';
                        break;
                    case '8': // Combine duplicates
                        toDoList.CombineDuplicates();
                        completedList.CombineDuplicates();
                        MessageBox.Show("Duplicates successfully combined!");
                        input = '0';
                        break;
                    default: // Home Screen
                        Console.Clear();
                        Header();
                        HomeScreen();
                        Footer();
                        input = Console.ReadKey().KeyChar;
                        break;
                }
            }
        }
    }
}
