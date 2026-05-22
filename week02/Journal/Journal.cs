using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries available.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string fileName)
    {
        using (StreamWriter output = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                output.WriteLine(entry.ToFileString());
            }
        }
    }
    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                AddEntry(entry);
            }
        }
    }
}