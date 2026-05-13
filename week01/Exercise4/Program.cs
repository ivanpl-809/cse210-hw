using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input = -1;
        while (input != 0){
            Console.Write("Enter a number:");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                list.Add(input);
            }
        }
        int sum = 0;
        foreach (int number in list){
            sum += number;
        }
         Console.WriteLine($"Sum: {sum}");

        float average = (float)sum / list.Count;
        Console.WriteLine($"Average: {average}");

        int max = list[0];
        foreach (int number in list){
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"Max: {max}");

    }
}