using System;
using System.Collections.Generic;
using System.IO;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("\nPress Enter...");
        Console.ReadLine();
    }
    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose type: ");
        int type = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());
        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));
                break;
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine("Goals:");
        ListGoalNames();
        Console.Write("Select goal: ");
        int choice = int.Parse(Console.ReadLine());
        int earned = _goals[choice - 1].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");
        Console.WriteLine($"Total score: {_score}");
        Console.WriteLine("\nPress Enter...");
        Console.ReadLine();
    }
    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved!");
        Console.ReadLine();
    }
    public void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.ReadLine();
            return;
        }
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            if (type == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[5]),
                        int.Parse(parts[4]),
                        int.Parse(parts[6])));
            }
        }
        Console.WriteLine("Loaded!");
        Console.ReadLine();
    }
}