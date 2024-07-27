namespace SolidPrinciple.SingleResponsibility;

class Journal
{
    private readonly List<string> entries = new();
    private static int count = 0;

    public int AddEntry(string text)
    {
        entries.Add($"{++count}: {text}");
        return count;
    }

    public void RemoverEntry(int idx)
    {
        entries.RemoveAt(idx);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine,entries);
    }
}

static class Persistence
{
    public static void SaveToFile(Journal j, string filePath)
    {
        if(!File.Exists(filePath))
        {
            File.WriteAllText(filePath, j.ToString());
        }
    }
}