using System;

namespace FractionNamespace
{
    public class Fraction
    {
        
        private int _numerator;
        private int _denominator;

        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _numerator = numerator;
            _denominator = denominator;
        }

        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }

        public int Denominator
        {
            get { return _denominator; }
            set 
            { 
                if (value == 0)
                {
                    throw new ArgumentException("Denominator cannot be zero.");
                }
                _denominator = value; 
            }
        }

        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public double GetDecimalValue()
        {
            return (double)_numerator / _denominator;
        }
    }
}