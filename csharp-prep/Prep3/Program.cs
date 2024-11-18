using System;

class Program
{
    static void Main(string[] args)
    {
      Console.WriteLine("Hello Prep3 World!");
      Random randomGenerator = new Random();
      int magicNumber = randomGenerator.Next (1, 101);
    
    int guess = -1;

    while (guess != magicNumber)
    {
        Console.Write("Guess a number between 1 and 100: ");
        guess = int.Parse(Console.ReadLine());

        if (magicNumber > guess)
        {
            Console.WriteLine("Higher");

        }
        else if (magicNumber < guess)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("That's it. Congrats!");
        }
    }
  }
}