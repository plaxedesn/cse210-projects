using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    //scripture reference 
    public class Reference
    {
        public string ReferenceStr { get; private set; } 

        // Constructor for initialising the reference
        public Reference(string referenceStr)
        {
            ReferenceStr = referenceStr;
        }

        public override string ToString()
        {
            return ReferenceStr;
        }
    }

    // Class to represent each word in the scripture
    public class Word
    {
        public string Text { get; private set; } 
        public bool IsHidden { get; private set; } 

        // Constructor for initialising the word
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

        // Constructor forinitialising the scripture with reference and text
        public Scripture(string reference, string text)
        {
            ScriptureReference = new Reference(reference);
            
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        // Method for hiding random word
        public void HideRandomWord()
        {
            
            var availableWords = Words.Where(word => !word.IsHidden).ToList();
            if (availableWords.Count > 0) // Check if there are words available to hide
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

        // Method for running memorization process
        public void Run()
        {
            while (true) // Loop until the user decides to quit
            {
                Console.Clear(); 
                Console.WriteLine(_scripture.Display()); 
                Console.Write("Press Enter to hide a word or type 'quit' to exit: ");
                var userInput = Console.ReadLine(); 
                if (userInput?.ToLower() == "quit") 
                {
                    break; // Exit the loop
                }
                _scripture.HideRandomWord(); // Hide a random word
            }
            // Final display of the scripture with all words hidden
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
            string scriptureReference = "John 3:16";

            
            var scripture = new Scripture(scriptureReference, scriptureText);
            
            var memorizer = new Memorizer(scripture);
            s
            memorizer.Run();
        }
    }
}