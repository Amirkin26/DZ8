/// <summary>
/// Главный класс программы.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    static void Main()
    {
        // Создание команды из 10 человек

        Person[] people = new Person[10];

        people[0] = new Person("Амир");
        people[1] = new Person("Алина");
        people[2] = new Person("Иван");
        people[3] = new Person("Мария");
        people[4] = new Person("Дмитрий");
        people[5] = new Person("Екатерина");
        people[6] = new Person("Артем");
        people[7] = new Person("Полина");
        people[8] = new Person("Максим");
        people[9] = new Person("Александр");

        // Назначение заказчика и тимлида

        Person initiator = people[0];
        Person teamLead = people[0];

        // Создание проекта

        Project project = new Project("Разработка корпоративного сайта", DateTime.Now, DateTime.Now.AddDays(30), initiator, teamLead);

        Console.WriteLine("ПРОЕКТ СОЗДАН");
        Console.WriteLine();

        // Создание 10 задач

        for (int i = 0; i < 10; i++)
        {
            project.CreateTask(teamLead, "Задача №" + (i + 1), DateTime.Now.AddDays(15), initiator, people[i]);
        }

        Console.WriteLine();

        // Запуск проекта

        project.StartProject();

        Console.WriteLine();

        // Работа с задачами

        for (int i = 0; i < 10; i++)
        {
            Task task = project.GetTask(i);

            // Принятие задачи

            task.Accept(people[i]);

            // Создание отчета

            task.CreateReport(people[i], "Выполнена работа по задаче №" + (i + 1));

            // Проверка отчета

            if (i == 0)
            {
                // Возврат первого отчета на доработку

                task.ReviewReport(initiator, false);

                // Исправление отчета

                task.EditReport(people[i], "Исправленный отчет по задаче №1");
            }

            // Утверждение отчета

            task.ReviewReport(initiator, true);

            Console.WriteLine();
        }

        // Проверка возможности закрытия проекта

        project.CheckProject();

        Console.WriteLine();

        // Вывод информации о проекте

        project.PrintInfo();

        Console.WriteLine();

        // Вывод задач каждого сотрудника

        Console.WriteLine("ЗАДАЧИ СОТРУДНИКОВ");
        Console.WriteLine();

        foreach (Person person in people)
        {
            person.PrintTasks();
            Console.WriteLine();
        }

        Console.WriteLine("Работа программы завершена.");
    }
}