using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("Enter magic number:");
        //int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        
        int userguess = -1;

        while (userguess != magicNumber)
        {
            Console.Write("Guess the magic number:");
            userguess = int.Parse(Console.ReadLine());

            if (userguess < magicNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (userguess > magicNumber)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine("Look at ya, you got it!");
            }
        }
    }
}