using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Scripture reference class
    public class Reference
    {
        public string ReferenceStr { get; private set; }
        public string StartVerse { get; private set; }
        public string EndVerse { get; private set; }
        public bool IsMultiVerse { get; private set; }

        // Constructor for single-verse reference
        public Reference(string referenceStr)
        {
            ReferenceStr = referenceStr;
            IsMultiVerse = false;
        }

        // Constructor for multi-verse reference
        public Reference(string startVerse, string endVerse)
        {
            StartVerse = startVerse;
            EndVerse = endVerse;
            IsMultiVerse = true;
        }

        public override string ToString()
        {
            return IsMultiVerse
                ? $"{StartVerse} - {EndVerse}"
                : ReferenceStr;
        }
    }

    // Class to represent each word in the scripture
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        // Constructor for initializing the word
        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        // Method for hiding the word
        public void Hide()
        {
            IsHidden = true;
        }

        // Method for displaying the word
        public string Display()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    // Class for representing scripture containing a reference and its words
    public class Scripture
    {
        public Reference ScriptureReference { get; private set; }
        private List<Word> Words { get; set; }

        // Constructor for initializing the scripture with a reference and text
        public Scripture(string reference, string text)
        {
            ScriptureReference = new Reference(reference);
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public Scripture(string startVerse, string endVerse, string text)
        {
            ScriptureReference = new Reference(startVerse, endVerse);
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        // Method for hiding a random word
        public void HideRandomWord()
        {
            var availableWords = Words.Where(word => !word.IsHidden).ToList();
            if (availableWords.Count > 0)
            {
                var random = new Random();
                var wordToHide = availableWords[random.Next(availableWords.Count)];
                wordToHide.Hide();
            }
        }

        // Method for displaying the scripture with its reference and words
        public string Display()
        {
            return $"{ScriptureReference}:\n" + string.Join(" ", Words.Select(word => word.Display()));
        }
    }

    // Class to manage the memorization process
    public class Memorizer
    {
        private Scripture _scripture;

        public Memorizer(Scripture scripture)
        {
            _scripture = scripture;
        }

        // Method for running the memorization process
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(_scripture.Display());
                Console.Write("Press Enter to hide a word or type 'quit' to exit: ");
                var userInput = Console.ReadLine();
                if (userInput?.ToLower() == "quit")
                {
                    break;
                }
                _scripture.HideRandomWord();
            }
            Console.WriteLine("Final scripture:");
            Console.WriteLine(_scripture.Display());
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            string scriptureText = "For God so loved the world that he gave his one and only Son";
            string singleVerse = "John 3:16";
            string multiVerseStart = "John 3:16";
            string multiVerseEnd = "John 3:17";

            var singleVerseScripture = new Scripture(singleVerse, scriptureText);
            var multiVerseScripture = new Scripture(multiVerseStart, multiVerseEnd, scriptureText);

            Console.WriteLine("Single Verse Scripture:");
            var memorizer = new Memorizer(singleVerseScripture);
            memorizer.Run();

            Console.WriteLine("\nMulti-Verse Scripture:");
            var multiVerseMemorizer = new Memorizer(multiVerseScripture);
            multiVerseMemorizer.Run();
        }
    }
}
