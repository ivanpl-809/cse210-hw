using System;
using System.Collections.Generic;
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };
    private Random _random = new Random();
    public ReflectingActivity()
        : base(
              "Reflection Activity",
              "This activity helps you reflect on times when you showed strength and resilience.")
    {
    }
    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
    public string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind press Enter.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions.");
        ShowSpinner(3);
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
        }
        DisplayEndingMessage();
    }
}