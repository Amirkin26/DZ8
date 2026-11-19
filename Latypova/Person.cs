/// <summary>
/// Класс сотрудника команды.
/// </summary>
class Person
{
    private string _name;
    private List<Task> _tasks;

    /// <summary>
    /// Создает сотрудника с указанным именем.
    /// </summary>
    public Person(string name)
    {
        _name = name;
        _tasks = new List<Task>();
    }

    /// <summary>
    /// Возвращает имя сотрудника.
    /// </summary>
    public string GetName()
    {
        return _name;
    }

    /// <summary>
    /// Добавляет задачу сотруднику.
    /// </summary>
    public void AddTask(Task task)
    {
        _tasks.Add(task);
    }

    /// <summary>
    /// Удаляет задачу из списка сотрудника.
    /// </summary>
    public void RemoveTask(Task task)
    {
        _tasks.Remove(task);
    }

    /// <summary>
    /// Выводит задачи сотрудника.
    /// </summary>
    public void PrintTasks()
    {
        Console.WriteLine("Сотрудник: " + _name);

        if (_tasks.Count == 0)
        {
            Console.WriteLine("Нет назначенных задач.");
        }

        foreach (Task task in _tasks)
        {
            Console.WriteLine("- " + task.GetDescription());
        }
    }
}