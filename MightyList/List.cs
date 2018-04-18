using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MightyList
{
    public class List
    {
        public string ListPath { get; private set; }

        public List<string> ListData { get; private set; }

        public List(string fileName)
        {
            ListPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, fileName);
            ListData = new List<string>();

            /*
             * Check to see if a file exists for the list.
             * If it does not, create a new file.
             * If it does, read the data from the file and store it in ListData for quick manipulation
             */
            try
            {
                if (!File.Exists(ListPath))
                    File.Create(ListPath);
                else
                    foreach (var line in File.ReadLines(ListPath))
                        ListData.Add(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Adds an item to the list and writes to file
        public void AddItem(string item)
        {
            ListData.Add(item);

            File.AppendAllText(ListPath, Environment.NewLine + item);
        }

        // Removes an item from the list and writes to file
        public void RemoveItem(int itemNumber)
        {
            ListData.RemoveAt(itemNumber);

            using (StreamWriter sw = new StreamWriter(ListPath, false))
            {
                for (int i = 0; i < ListData.Count; i++)
                {
                    // Account for newline at end of file
                    if (i == ListData.Count - 1)
                        sw.Write(ListData.ElementAt(i));
                    else
                        sw.WriteLine(ListData.ElementAt(i));
                }
            }               
        }

        // Combine any duplicates found in the list
        public void CombineDuplicates()
        {
            List<string> duplicateFree = ListData.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

            ListData = duplicateFree;

            using (StreamWriter sw = new StreamWriter(ListPath, false))
            {
                for (int i = 0; i < ListData.Count; i++)
                {
                    // Account for newline at end of file
                    if (i == ListData.Count - 1)
                        sw.Write(ListData.ElementAt(i));
                    else
                        sw.WriteLine(ListData.ElementAt(i));
                }
            }
        }
    }
}
