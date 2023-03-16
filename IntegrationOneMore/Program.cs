class Program
{
    static void Main(string[] args)
    {
        Classroom[] classes =
        {
            new() { Students = { "Evgeniy", "Sergey", "Andrew" } },
            new() { Students = { "Anna", "Viktor", "Vladimir" } },
            new() { Students = { "Bulat", "Alex", "Galina" } }
        };

        Console.WriteLine(string.Join("\n", GetAllStudents(classes)));
    }

    static string[] GetAllStudents(Classroom[] classrooms)
    {
        string[] result = new string[classrooms.Sum(x => x.Students.Count)];
        
        // позиция элемента в массиве result
        int position = default;

        foreach (Classroom c in classrooms)
        {
            for (int j = 0, i = position; j < c.Students.Count; i++, j++)
            {
                result.SetValue(c.Students.Skip(j).First(), i);
            }
            position += c.Students.Count;
        }

        // короткая запись
        // var result = classrooms.SelectMany(x => x.Students).OrderBy(student => student).ToArray();

        return result.OrderBy(s => s).ToArray();
    }

    class Classroom
    {
        public List<string> Students { get; set; } = new();
    }
}