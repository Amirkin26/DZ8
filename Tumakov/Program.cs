class Program
{
    static void Main()
    {
        // Упражнение 9.1

        Console.WriteLine("Упражнение 9.1");
        Console.WriteLine();

        // Создание счета с помощью четырех конструкторов

        BankAccount account1 = new BankAccount();

        BankAccount account2 = new BankAccount(5000);

        BankAccount account3 = new BankAccount(AccountType.Сберегательный);

        BankAccount account4 = new BankAccount(10000, AccountType.Текущий);

        // Вывод информации о счетах

        Console.WriteLine("Первый счет:");
        account1.PrintInfo();

        Console.WriteLine();

        Console.WriteLine("Второй счет:");
        account2.PrintInfo();

        Console.WriteLine();

        Console.WriteLine("Третий счет:");
        account3.PrintInfo();

        Console.WriteLine();

        Console.WriteLine("Четвертый счет:");
        account4.PrintInfo();

        // Упражнение 9.2

        Console.WriteLine();
        Console.WriteLine("Упражнение 9.2");
        Console.WriteLine();

        // Пополнение счета

        account2.Deposit(3000);

        // Снятие денег

        account2.Withdraw(1000);

        // Проверка недостатка средств

        account2.Withdraw(10000);

        // Вывод нового баланса

        Console.WriteLine();
        account2.PrintInfo();

        // Упражнение 9.3

        Console.WriteLine();
        Console.WriteLine("Упражнение 9.3");
        Console.WriteLine();

        // Запись истории операций в файл

        account2.Dispose();

        Console.WriteLine("История операций записана в файл.");

        // Домашнее задание 9.1

        Console.WriteLine();
        Console.WriteLine("Домашнее задание 9.1");
        Console.WriteLine();

        // Создание первой песни

        Song song1 = new Song("Звезда по имени Солнце", "Кино");

        // Создание второй песни с указанием предыдущей песни

        Song song2 = new Song("Группа крови", "Кино", song1);

        // Вывод информации о песнях

        Console.WriteLine("Первая песня:");
        song1.Print();

        Console.WriteLine();

        Console.WriteLine("Вторая песня:");
        song2.Print();

        // Проверка метода Title()

        Console.WriteLine();
        Console.WriteLine("Название второй песни: " + song2.Title());

        // Проверка конструктора без параметров

        // Song mySong = new Song();
        // Эта строка вызовет ошибку, так как конструктора
        // без параметров в классе Song нет.
    }
}
