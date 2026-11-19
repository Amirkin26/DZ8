/// <summary>
/// Класс банковского счета.
/// Хранит номер счета, баланс, тип счета и историю операций.
/// </summary>
class BankAccount
{
    private static int lastAccountNumber = 0;

    private int accountNumber;
    private decimal balance;
    private AccountType type;

    private System.Collections.Queue transactions = new System.Collections.Queue();

    /// <summary>
    /// Создает банковский счет со стандартными значениями.
    /// </summary>
    public BankAccount()
    {
        lastAccountNumber++;
        accountNumber = lastAccountNumber;
        balance = 0;
        type = AccountType.Текущий;
    }

    /// <summary>
    /// Создает банковский счет с указанным балансом.
    /// </summary>
    public BankAccount(decimal balance) : this()
    {
        this.balance = balance >= 0 ? balance : 0;
    }

    /// <summary>
    /// Создает банковский счет с указанным типом.
    /// </summary>
    public BankAccount(AccountType type) : this()
    {
        this.type = type;
    }

    /// <summary>
    /// Создает банковский счет с указанными балансом и типом.
    /// </summary>
    public BankAccount(decimal balance, AccountType type) : this()
    {
        this.balance = balance >= 0 ? balance : 0;
        this.type = type;
    }

    /// <summary>
    /// Возвращает номер банковского счета.
    /// </summary>
    public int GetAccountNumber()
    {
        return accountNumber;
    }

    /// <summary>
    /// Возвращает баланс банковского счета.
    /// </summary>
    public decimal GetBalance()
    {
        return balance;
    }

    /// <summary>
    /// Возвращает тип банковского счета.
    /// </summary>
    public AccountType GetAccountType()
    {
        return type;
    }

    /// <summary>
    /// Пополняет банковский счет и сохраняет операцию.
    /// </summary>
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            transactions.Enqueue(new BankTransaction(amount));

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
        else if (amount <= balance)
        {
            balance -= amount;
            transactions.Enqueue(new BankTransaction(-amount));

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
        Console.WriteLine("Номер счета: " + accountNumber);
        Console.WriteLine("Баланс: " + balance);
        Console.WriteLine("Тип счета: " + type);
    }

    /// <summary>
    /// Записывает историю банковских операций в файл.
    /// </summary>
    public void Dispose()
    {
        using (StreamWriter writer = new StreamWriter("transactions.txt", true))
        {
            foreach (BankTransaction transaction in transactions)
            {
                writer.WriteLine("Банковская операция:");
                writer.WriteLine("Дата и время: " + transaction.GetDate());
                writer.WriteLine("Сумма: " + transaction.GetAmount());
                writer.WriteLine();
            }
        }

        transactions.Clear();

        GC.SuppressFinalize(this);
    }
}
