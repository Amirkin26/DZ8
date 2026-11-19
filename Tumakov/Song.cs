/// <summary>
/// Класс песни, содержащий название, автора
/// и ссылку на предыдущую песню.
/// </summary>
class Song
{
    private string _name;
    private string _author;
    private Song _prev;

    /// <summary>
    /// Создает песню без параметров.
    /// </summary>
    public Song()
    {
        _name = "";
        _author = "";
        _prev = null;
    }

    /// <summary>
    /// Создает песню с названием и автором.
    /// Ссылка на предыдущую песню устанавливается в null.
    /// </summary>
    public Song(string name, string author)
    {
        _name = name;
        _author = author;
        _prev = null;
    }

    /// <summary>
    /// Создает песню с названием, автором и предыдущей песней.
    /// </summary>
    public Song(string name, string author, Song prev)
    {
        _name = name;
        _author = author;
        _prev = prev;
    }

    /// <summary>
    /// Устанавливает название песни.
    /// </summary>
    public void SetName(string name)
    {
        _name = name;
    }

    /// <summary>
    /// Устанавливает автора песни.
    /// </summary>
    public void SetAuthor(string author)
    {
        _author = author;
    }

    /// <summary>
    /// Устанавливает ссылку на предыдущую песню.
    /// </summary>
    public void SetPrev(Song prev)
    {
        _prev = prev;
    }

    /// <summary>
    /// Выводит название и исполнителя песни.
    /// </summary>
    public void Print()
    {
        Console.WriteLine("Название: " + _name);
        Console.WriteLine("Исполнитель: " + _author);
    }

    /// <summary>
    /// Возвращает название песни и исполнителя.
    /// </summary>
    public string Title()
    {
        return _name + " - " + _author;
    }

    /// <summary>
    /// Сравнивает две песни по названию и исполнителю.
    /// </summary>
    public override bool Equals(object d)
    {
        if (d is Song)
        {
            Song song = d as Song;

            return _name == song._name && _author == song._author;
        }

        return false;
    }
}