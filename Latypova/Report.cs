/// <summary>
/// Класс отчета о выполненной работе.
/// </summary>
class Report
{
    private string _text;
    private DateTime _completionDate;
    private Person _executor;

    /// <summary>
    /// Создает отчет с текстом и исполнителем.
    /// </summary>
    public Report(string text, Person executor)
    {
        _text = text;
        _executor = executor;
        _completionDate = DateTime.Now;
    }

    /// <summary>
    /// Возвращает текст отчета.
    /// </summary>
    public string GetText()
    {
        return _text;
    }

    /// <summary>
    /// Возвращает дату выполнения.
    /// </summary>
    public DateTime GetCompletionDate()
    {
        return _completionDate;
    }

    /// <summary>
    /// Возвращает исполнителя отчета.
    /// </summary>
    public Person GetExecutor()
    {
        return _executor;
    }

    /// <summary>
    /// Изменяет текст отчета при доработке.
    /// </summary>
    public void Edit(string text)
    {
        _text = text;
        _completionDate = DateTime.Now;
    }

    /// <summary>
    /// Выводит информацию об отчете.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine("Текст отчета: " + _text);
        Console.WriteLine("Дата выполнения: " + _completionDate);
        Console.WriteLine("Исполнитель: " + _executor.GetName());
    }
}