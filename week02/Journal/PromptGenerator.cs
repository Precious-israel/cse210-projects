using System;

public class PromptGenerator
{
    private string[] prompts = 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What inspired me today?",
        "What is something I am grateful for?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Length)];
    }
}
