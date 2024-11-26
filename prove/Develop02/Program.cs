using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static Journal journal;
    private static string[] prompts = 
    {
        "What is the first thing I did in the morning?",
        "What assignment did I DO?",
        "How did I see the hand of the Lord in my life today?",
        "How many times did I YELL?",
        "What was the major highlight of the day?"
    };

    static void Main(string[] args)
    {
        // Initialize the journal
        journal = new Journal();
        Console.WriteLine("Welcome to Plax Journal!");
        ShowMenu(); // Display the menu for user interaction
    }

    public static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nJournal App Menu:");
            Console.WriteLine("1. Write latest entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("Exiting.");
                    return;
                default:
                    Console.WriteLine("Invalid: Try again.");
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        var entry = new JournalEntry(prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Your entry has been added.");
    }

    private static void DisplayJournal()
    {
        journal.DisplayJournal();
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveJournal(filename);
    }

    private static void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadJournal(filename);
    }

    public class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public JournalEntry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }

    public class Journal
    {
        public List<JournalEntry> Entries { get; private set; }

        public Journal()
        {
            Entries = new List<JournalEntry>();
        }

        public void AddEntry(JournalEntry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayJournal()
        {
            if (Entries.Count == 0)
            {
                Console.WriteLine("No entries to display.");
                return;
            }

            foreach (var entry in Entries)
            {
                Console.WriteLine(entry);
                Console.WriteLine(new string('-', 40));
            }
        }

        public void SaveJournal(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var entry in Entries)
                    {
                        writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                    }
                }
                Console.WriteLine($"Journal saved to {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        public void LoadJournal(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found!");
                return;
            }

            try
            {
                Entries.Clear();
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            var entry = new JournalEntry(parts[1], parts[2])
                            {
                                Date = parts[0]
                            };
                            Entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }
    }
}
