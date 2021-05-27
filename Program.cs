/* Lab 3
 * 
 * Diana Guerrero
 * Professor Aydin
 * BCS 426 
 * 2/28/21
 * 
 * Partner(s): Patrick Adams
 * Resource(s): 
 * 1. https://www.rapidtables.com/convert/number/how-number-to-roman-numerals.html
 * 2. Module 3 Slides
 */

using System;

namespace BCS426Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int i = 99;
            string s = i.toRoman();
            Console.WriteLine(s);

            // XCIX is 99 in Roman Numerals
            /*
             * Console.WriteLine("Enter a Number Ranging from 1 - 3999: ");
             * romanRepresentation roman = new romanRepresentation(Convert.ToInt32(Console.ReadLine()));
             * Console.WriteLine(Extension.toRoman(Convert.ToInt32(roman))); 
            */

            Console.WriteLine("Question 2");

            // Create 2 Book Objects
            Book b1 = new Book("C# 8.0 in a Nutshell", Convert.ToDecimal(59.99), "978 - 1492051138", "Jack Smith");
            Book b2 = new Book("C#: Advanced Features and Programming Techniques", Convert.ToDecimal(2.99), "100-1492051000", "Jill Smith");

            // Display Data
            Console.WriteLine(b1.ToString());
            Console.WriteLine(b2.ToString());

            // Total Cost for Books
            int bookCount1;
            int bookCount2;

            Console.Write("How many of Book 1 would you like to purchase? ");
            bookCount1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("How many of Book 2 would you like to purchase? ");
            bookCount2 = Convert.ToInt32(Console.ReadLine());

            // Using sell to calculate total cost
            Console.WriteLine("\nTotal Cost is: $" + (b1.sell(bookCount1) + b2.sell(bookCount2)));

            // Create Software Object
            Software s1 = new Software("Microsoft 365 Personal", Convert.ToDecimal(69.99), "16.0.10827");

            // Total Cost for Software
            int softwareCount1;

            Console.Write("How many Microsoft 365 packages would you like to purchase? ");
            softwareCount1 = Convert.ToInt32(Console.ReadLine());

            // Using sell to calculate total cost
            Console.WriteLine("\n Total Cost is: $" + (s1.sell(softwareCount1)));
        }
    }

    public class romanRepresentation
    {
        private int roman;

        public int romanNum
        {
            get { return roman; }
        }

        public romanRepresentation(int roman)
        {
            this.roman = roman;
        }
    }

    public static class Extension
    {
        // The Largest Roman Numeral is 3999 according to Google so I will set a range up from 1 to 3999
        public static string toRoman(this int decimalNum)
        {
            // Declare a Variable to Hold the Roman Numeral Equivalent of the Integer Inputted by the User
            string romanVersion = "";

            // If out of range create an error
            if ((decimalNum < 0) || (decimalNum > 3999))
                Console.WriteLine("The Number is out of range for Extension Method");

            // Temporary Variable called standinNum (because it stands in place of the number) and Assigns the Number to it
            // Variable will Change Inside the While Loop
            int standinNum = decimalNum;

            // While Loop will Repeat as long as currentNumber is > 0
            while (standinNum > 0)
            {
                // Checks if standinNum is >= 1000 & Appends "M" (M = 1000)
                // For all of the if statements below we will be subtracting the number by itself because you want the roman numeral to take its place. The string concatinates with the next letter until there's no more numbers left.
                if (standinNum >= 1000)
                {
                    romanVersion = romanVersion + "M";
                    standinNum = standinNum - 1000;
                }
                // Checks if standinNum is >= 900 & Appends "CM" (CM = 900)
                else if (standinNum >= 900)
                {
                    romanVersion = romanVersion + "CM";
                    standinNum = standinNum - 900;
                }
                // Checks if standinNum is >= 500 & Appends "D" (D = 500)
                else if (standinNum >= 500)
                {
                    romanVersion = romanVersion + "D";
                    standinNum = standinNum - 500;
                }
                // Checks if standinNum is >= 400 & Appends "CD" (CD = 400)
                else if (standinNum >= 400)
                {
                    romanVersion = romanVersion + "CD";
                    standinNum = standinNum - 400;
                }
                // Checks if standinNum is >= 100 & Appends "C" (C = 100)
                else if (standinNum >= 100)
                {
                    romanVersion = romanVersion + "C";
                    standinNum = standinNum - 100;
                }
                // Checks if standinNum is >= 90 & Appends "XC" (XC = 90)
                else if (standinNum >= 90)
                {
                    romanVersion = romanVersion + "XC";
                    standinNum = standinNum - 90;
                }
                // Checks if standinNum is >= 50 & Appends "L" (L = 50)
                else if (standinNum >= 50)
                {
                    romanVersion = romanVersion + "L";
                    standinNum = standinNum - 50;
                }
                // Checks if standinNum is >= 40 & Appends "XL" (XL = 40)
                else if (standinNum >= 40)
                {
                    romanVersion = romanVersion + "XL";
                    standinNum = standinNum - 40;
                }
                // Checks if standinNum is >= 10 & Appends "X" (X = 10)
                else if (standinNum >= 10)
                {
                    romanVersion = romanVersion + "X";
                    standinNum = standinNum - 10;
                }
                // Checks if standinNum is >= 9 & Appends "IX" (IX = 9)
                else if (standinNum >= 9)
                {
                    romanVersion = romanVersion + "IX";
                    standinNum = standinNum - 9;
                }
                // Checks if standinNum is >= 5 & Appends "V" (V = 5)
                else if (standinNum >= 5)
                {
                    romanVersion = romanVersion + "V";
                    standinNum = standinNum - 5;
                }
                // Checks if standinNum is >= 4 & Appends "IV" (IV = 4)
                else if (standinNum >= 4)
                {
                    romanVersion = romanVersion + "IV";
                    standinNum = standinNum - 4;
                }
                // Checks if standinNum is >= 1 & Appends "I" (I = 1). Append "I" to the Results from Above
                else
                {
                    romanVersion = romanVersion + "I";
                    standinNum = standinNum - 1;
                }
            }

            // Return the Roman Numeral Version
            return romanVersion;
        }
    }

    // Question 2a
    public abstract class Product
    {
        public abstract void PropertiesPrice(decimal num);
        public abstract void Code(string code);
        public abstract void Description(string description);
    }

    // Question 2b
    public interface ISellable
    {
        public decimal sell(int count);
    }

    // Question 2c
    // Inherits CLass Product & Implements ISellable
    public class Book : Product, ISellable
    {

        decimal num;
        string code;
        string description;

        // Product Inheritance Implementation
        public override void PropertiesPrice(decimal num) => this.num = num;
        public override void Description(string description) => this.description = description;
        public override void Code(string code) => this.code = code;

        // ISellable Implementation
        public decimal sell(int count)
        {
            return count * num;
        }

        // Property Author (string)
        string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        // Constructor
        public Book(string description, decimal num, string code, string author)
        {
            this.num = num;
            this.code = code;
            _author = author;
            this.description = description;
        }

        // toString Method to Display All the Data from Class Book
        public override string ToString()
        {
            return "Description: " + description + "\n Price: $" + num + "\n ISBN: " + code + "\n Author: " + _author;
        }
    }

    // Question 2d
    // Inherits CLass Product & Implements ISellable
    public class Software : Product, ISellable
    {

        decimal num;
        string code;
        string description;

        // Product Inheritance Implementation
        public override void PropertiesPrice(decimal num) => this.num = num;
        public override void Description(string description) => this.description = description;

        // ISellable Implementation
        public decimal sell(int count)
        {
            return count * num;
        }

        // Property Version (string)
        string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        // Constructor
        public Software(string description, decimal num, string version)
        {
            this.num = num;
            _version = version;
            this.description = description;
        }

        // toString Method to Display All the Data from Class Software
        public override string ToString()
        {
            return "Description: " + description + "\n Price: $" + num + "\n Version: " + _version;
        }

        public override void Code(string code) => this.code = code;
        
    }
}