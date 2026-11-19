/// <summary>
/// Класс банковской операции.
/// Хранит дату, время и сумму операции.
/// </summary>
class BankTransaction
{
    private readonly DateTime _date;
    private readonly decimal _amount;

    /// <summary>
    /// Создает банковскую операцию с указанной суммой.
    /// </summary>
    public BankTransaction(decimal amount)
    {
        _date = DateTime.Now;
        _amount = amount;
    }

    /// <summary>
    /// Возвращает дату и время операции.
    /// </summary>
    public DateTime GetDate()
    {
        return _date;
    }

    /// <summary>
    /// Возвращает сумму операции.
    /// </summary>
    public decimal GetAmount()
    {
        return _amount;
    }
}