using System;

  namespace FractionNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Fraction fraction1 = new Fraction(); // 1/1
            Fraction fraction2 = new Fraction(6); // 6/1
            Fraction fraction3 = new Fraction(6, 7); // 6/7

            Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
            Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");
            Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");

            fraction1.Numerator = 3;
            fraction1.Denominator = 4; 
            Console.WriteLine($"Modified Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");

            
            fraction2.Numerator = 1;
            fraction2.Denominator = 3; 
            Console.WriteLine($"Modified Fraction 2: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");
        }
    }
} 
