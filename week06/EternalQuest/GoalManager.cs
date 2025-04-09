using System;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Option: ");
        string input = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;
        switch (input)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times must it be completed? ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on final completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, count, bonus);
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Goal added!");
    }

    public void RecordEvent()
    {
        ShowGoals();
        Console.Write("Which goal did you complete? (Enter number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            score += earned;
            Console.WriteLine($"You earned {earned} points! Total score: {score}");
        }
    }

    public void ShowGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals set yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"🏅 Your current score: {score}");
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                Goal g = parts[0] switch
                {
                    "Simple" => new SimpleGoal("", "", 0),
                    "Eternal" => new EternalGoal("", "", 0),
                    "Checklist" => new ChecklistGoal("", "", 0, 0, 0),
                    _ => null
                };

                g?.LoadData(lines[i]);
                if (g != null) goals.Add(g);
            }

            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("No save file found.");
        }
    }
}
