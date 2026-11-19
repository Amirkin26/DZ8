/// <summary>
/// Класс проекта.
/// </summary>
class Project
{
    private string _description;
    private DateTime _startDate;
    private DateTime _deadline;
    private Person _initiator;
    private Person _teamLead;
    private List<Task> _tasks;
    private ProjectStatus _status;

    /// <summary>
    /// Создает проект с указанными параметрами.
    /// </summary>
    public Project(string description, DateTime startDate, DateTime deadline, Person initiator, Person teamLead)
    {
        _description = description;
        _startDate = startDate;
        _deadline = deadline;
        _initiator = initiator;
        _teamLead = teamLead;

        _tasks = new List<Task>();
        _status = ProjectStatus.Проект;
    }

    /// <summary>
    /// Создает новую задачу. Вызывать метод может только тимлид.
    /// </summary>
    public void CreateTask(Person creator, string description, DateTime deadline, Person taskInitiator, Person executor)
    {
        if (creator != _teamLead)
        {
            Console.WriteLine("Только тимлид может создавать задачи.");
            return;
        }

        if (_status != ProjectStatus.Проект)
        {
            Console.WriteLine("Задачи можно создавать только в статусе Проект.");
            return;
        }

        if (executor == null)
        {
            Console.WriteLine("Необходимо указать исполнителя.");
            return;
        }

        Task task = new Task(description, deadline, taskInitiator, executor);
        _tasks.Add(task);

        Console.WriteLine("Задача создана: " + description);
    }

    /// <summary>
    /// Повторно назначает отклоненную задачу.
    /// </summary>
    public void ReassignTask(Person creator, Task task, Person executor)
    {
        if (creator != _teamLead || !_tasks.Contains(task))
        {
            Console.WriteLine("Невозможно переназначить задачу.");
            return;
        }

        if (executor == null)
        {
            Console.WriteLine("Необходимо указать исполнителя.");
            return;
        }

        task.Reassign(executor);
    }

    /// <summary>
    /// Удаляет отклоненную задачу.
    /// </summary>
    public void DeleteTask(Person creator, Task task)
    {
        if (creator != _teamLead || !_tasks.Contains(task))
        {
            Console.WriteLine("Невозможно удалить задачу.");
            return;
        }

        if (task.GetExecutor() != null || task.GetStatus() != TaskStatus.Назначена)
        {
            Console.WriteLine("Можно удалить только отклоненную задачу.");
            return;
        }

        _tasks.Remove(task);

        Console.WriteLine("Задача удалена.");
    }

    /// <summary>
    /// Переводит проект в статус исполнения.
    /// </summary>
    public void StartProject()
    {
        if (_status == ProjectStatus.Проект && _tasks.Count > 0)
        {
            _status = ProjectStatus.Исполнение;
            Console.WriteLine("Проект запущен.");
        }
        else
        {
            Console.WriteLine("Невозможно запустить проект.");
        }
    }

    /// <summary>
    /// Проверяет выполнение всех задач и закрывает проект.
    /// </summary>
    public void CheckProject()
    {
        if (_status != ProjectStatus.Исполнение)
        {
            return;
        }

        foreach (Task task in _tasks)
        {
            if (task.GetStatus() != TaskStatus.Выполнена)
            {
                return;
            }
        }

        _status = ProjectStatus.Закрыт;
        Console.WriteLine("Все задачи выполнены. Проект закрыт.");
    }

    /// <summary>
    /// Получает задачу по номеру.
    /// </summary>
    public Task GetTask(int number)
    {
        if (number >= 0 && number < _tasks.Count)
        {
            return _tasks[number];
        }

        Console.WriteLine("Задача не найдена.");
        return null;
    }

    /// <summary>
    /// Выводит информацию о проекте и его задачах.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine("Проект: " + _description);
        Console.WriteLine("Дата начала: " + _startDate);
        Console.WriteLine("Срок окончания: " + _deadline);
        Console.WriteLine("Заказчик: " + _initiator.GetName());
        Console.WriteLine("Тимлид: " + _teamLead.GetName());
        Console.WriteLine("Статус проекта: " + _status);

        Console.WriteLine();
        Console.WriteLine("Список задач:");

        foreach (Task task in _tasks)
        {
            task.PrintInfo();
            Console.WriteLine();
        }
    }
}