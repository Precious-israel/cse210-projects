public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"Title: {_title}";
    }

    public override string GetSummary()
    {
        return $"{GetStudentName()} - {GetTopic()}\nTitle: {_title}";
    }
}
