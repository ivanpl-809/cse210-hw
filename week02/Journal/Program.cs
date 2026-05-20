using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int option = 0;

        while (option != 5)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt:");
                Console.WriteLine(prompt);
                Console.Write("> ");
                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = Console.ReadLine();
                journal.AddEntry(entry);
                Console.WriteLine("Entry added.");
            }
            else if (option == 2)
            {
                Console.WriteLine("\nJournal Entries:");
                journal.DisplayAll();
            }
            else if (option == 3)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
                Console.WriteLine("Journal saved.");
            }
            else if (option == 4)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
                Console.WriteLine("Journal loaded.");
            }
            else if (option == 5)
            {
                Console.WriteLine("Goodbye.");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}