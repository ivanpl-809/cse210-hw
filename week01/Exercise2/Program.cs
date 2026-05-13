using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade (0 to 100 only)");
        string grade = Console.ReadLine();
        int igrade = int.Parse(grade);
        string letterGrade = "";

        if (igrade >= 90)
        {
        letterGrade = "A";
        }
        else if (igrade >= 80)
        {
        letterGrade = "B";
        }
        else if (igrade >= 70)
        {
        letterGrade = "C";
        }
        else if (igrade >= 60)
        {
        letterGrade = "D";
        } 
        else
        {
        letterGrade = "F";
        }

        Console.WriteLine($"Your grade is: {letterGrade}");

        if (igrade >= 70)
        {
            Console.WriteLine("Congrats! You passed the course.");
        }
        else
        {
            Console.WriteLine("Sorry Pal, you failed.");
        }


    }
}