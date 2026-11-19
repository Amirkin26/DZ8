/// <summary>
/// Класс банковского счета.
/// Хранит номер счета, баланс, тип счета и историю операций.
/// </summary>
class BankAccount
{
    private static int _lastAccountNumber = 0;

    private int _accountNumber;
    private decimal _balance;
    private AccountType _type;

    private System.Collections.Queue _transactions =
        new System.Collections.Queue();

    /// <summary>
    /// Создает банковский счет со стандартными значениями.
    /// </summary>
    public BankAccount()
    {
        _lastAccountNumber++;
        _accountNumber = _lastAccountNumber;
        _balance = 0;
        _type = AccountType.Текущий;
    }

    /// <summary>
    /// Создает банковский счет с указанным балансом.
    /// </summary>
    public BankAccount(decimal balance) : this()
    {
        _balance = balance >= 0 ? balance : 0;
    }

    /// <summary>
    /// Создает банковский счет с указанным типом.
    /// </summary>
    public BankAccount(AccountType type) : this()
    {
        _type = type;
    }

    /// <summary>
    /// Создает банковский счет с указанными балансом и типом.
    /// </summary>
    public BankAccount(decimal balance, AccountType type) : this()
    {
        _balance = balance >= 0 ? balance : 0;
        _type = type;
    }

    /// <summary>
    /// Возвращает номер банковского счета.
    /// </summary>
    public int GetAccountNumber()
    {
        return _accountNumber;
    }

    /// <summary>
    /// Возвращает баланс банковского счета.
    /// </summary>
    public decimal GetBalance()
    {
        return _balance;
    }

    /// <summary>
    /// Возвращает тип банковского счета.
    /// </summary>
    public AccountType GetAccountType()
    {
        return _type;
    }

    /// <summary>
    /// Пополняет банковский счет и сохраняет операцию.
    /// </summary>
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            _transactions.Enqueue(new BankTransaction(amount));

            Console.WriteLine("Деньги внесены.");
        }
        else
        {
            Console.WriteLine("Сумма должна быть положительной.");
        }
    }

    /// <summary>
    /// Снимает деньги со счета и сохраняет операцию.
    /// </summary>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной.");
        }
        else if (amount <= _balance)
        {
            _balance -= amount;
            _transactions.Enqueue(new BankTransaction(-amount));

            Console.WriteLine("Деньги сняты.");
        }
        else
        {
            Console.WriteLine("Недостаточно средств.");
        }
    }

    /// <summary>
    /// Выводит информацию о банковском счете.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine("Номер счета: " + _accountNumber);
        Console.WriteLine("Баланс: " + _balance);
        Console.WriteLine("Тип счета: " + _type);
    }

    /// <summary>
    /// Записывает историю банковских операций в файл.
    /// </summary>
    public void Dispose()
    {
        using (StreamWriter writer = new StreamWriter("transactions.txt", true))
        {
            foreach (BankTransaction transaction in _transactions)
            {
                writer.WriteLine("Банковская операция:");
                writer.WriteLine("Дата и время: " + transaction.GetDate());
                writer.WriteLine("Сумма: " + transaction.GetAmount());
                writer.WriteLine();
            }
        }

        _transactions.Clear();

        GC.SuppressFinalize(this);
    }
}