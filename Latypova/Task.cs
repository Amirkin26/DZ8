/// <summary>
/// Класс задачи проекта.
/// </summary>
class Task
{
    private string _description;
    private DateTime _deadline;
    private Person _initiator;
    private Person _executor;
    private TaskStatus _status;
    private Report _report;

    /// <summary>
    /// Создает задачу с указанными параметрами.
    /// </summary>
    public Task(string description, DateTime deadline, Person initiator, Person executor)
    {
        _description = description;
        _deadline = deadline;
        _initiator = initiator;
        _executor = executor;
        _status = TaskStatus.Назначена;
        _report = null;

        executor.AddTask(this);
    }

    /// <summary>
    /// Возвращает описание задачи.
    /// </summary>
    public string GetDescription()
    {
        return _description;
    }

    /// <summary>
    /// Возвращает исполнителя задачи.
    /// </summary>
    public Person GetExecutor()
    {
        return _executor;
    }

    /// <summary>
    /// Возвращает статус задачи.
    /// </summary>
    public TaskStatus GetStatus()
    {
        return _status;
    }

    /// <summary>
    /// Принимает задачу в работу.
    /// </summary>
    public void Accept(Person person)
    {
        if (person == _executor && _status == TaskStatus.Назначена)
        {
            _status = TaskStatus.ВРаботе;
            Console.WriteLine("Задача принята в работу.");
        }
        else
        {
            Console.WriteLine("Невозможно принять задачу.");
        }
    }

    /// <summary>
    /// Делегирует задачу другому сотруднику.
    /// </summary>
    public void Delegate(Person person, Person newExecutor)
    {
        if (newExecutor == null)
        {
            Console.WriteLine("Необходимо указать нового исполнителя.");
            return;
        }

        if (person == newExecutor)
        {
            Console.WriteLine("Нельзя делегировать задачу самому себе.");
            return;
        }

        if (person == _executor && _status == TaskStatus.Назначена)
        {
            _executor.RemoveTask(this);

            _executor = newExecutor;
            newExecutor.AddTask(this);

            _status = TaskStatus.Назначена;

            Console.WriteLine("Задача делегирована.");
        }
        else
        {
            Console.WriteLine("Невозможно делегировать задачу.");
        }
    }

    /// <summary>
    /// Отклоняет задачу.
    /// </summary>
    public void Reject(Person person)
    {
        if (person == _executor && _status == TaskStatus.Назначена)
        {
            _executor.RemoveTask(this);
            _executor = null;

            Console.WriteLine("Задача отклонена.");
        }
        else
        {
            Console.WriteLine("Невозможно отклонить задачу.");
        }
    }

    /// <summary>
    /// Повторно назначает отклоненную задачу.
    /// </summary>
    internal void Reassign(Person newExecutor)
    {
        if (newExecutor == null)
        {
            Console.WriteLine("Необходимо указать нового исполнителя.");
            return;
        }

        if (_executor == null && _status == TaskStatus.Назначена)
        {
            _executor = newExecutor;
            newExecutor.AddTask(this);

            Console.WriteLine("Задача назначена другому сотруднику.");
        }
        else
        {
            Console.WriteLine("Невозможно переназначить задачу.");
        }
    }

    /// <summary>
    /// Создает отчет по задаче.
    /// </summary>
    public void CreateReport(Person person, string text)
    {
        if (person == _executor && _status == TaskStatus.ВРаботе && _report == null)
        {
            _report = new Report(text, _executor);
            _status = TaskStatus.НаПроверке;

            Console.WriteLine("Отчет отправлен на проверку.");
        }
        else
        {
            Console.WriteLine("Невозможно создать отчет.");
        }
    }

    /// <summary>
    /// Возвращает отчет на доработку.
    /// </summary>
    public void EditReport(Person person, string text)
    {
        if (person == _executor && _status == TaskStatus.ВРаботе && _report != null)
        {
            _report.Edit(text);
            _status = TaskStatus.НаПроверке;

            Console.WriteLine("Отчет повторно отправлен на проверку.");
        }
        else
        {
            Console.WriteLine("Невозможно изменить отчет.");
        }
    }

    /// <summary>
    /// Проверяет отчет инициатором задачи.
    /// </summary>
    public void ReviewReport(Person person, bool approved)
    {
        if (person != _initiator || _status != TaskStatus.НаПроверке)
        {
            Console.WriteLine("Невозможно проверить отчет.");
            return;
        }

        if (approved)
        {
            _status = TaskStatus.Выполнена;
            Console.WriteLine("Отчет утвержден. Задача выполнена.");
        }
        else
        {
            _status = TaskStatus.ВРаботе;
            Console.WriteLine("Отчет возвращен на доработку.");
        }
    }

    /// <summary>
    /// Выводит информацию о задаче.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine("Задача: " + _description);
        Console.WriteLine("Срок: " + _deadline);
        Console.WriteLine("Инициатор: " + _initiator.GetName());

        if (_executor == null)
        {
            Console.WriteLine("Исполнитель: не назначен");
        }
        else
        {
            Console.WriteLine("Исполнитель: " + _executor.GetName());
        }

        Console.WriteLine("Статус: " + _status);

        if (_report != null)
        {
            Console.WriteLine("Отчет:");
            _report.PrintInfo();
        }
    }
}