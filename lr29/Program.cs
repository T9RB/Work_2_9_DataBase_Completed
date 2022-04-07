using System.Runtime.CompilerServices;
using lr29;
using Microsoft.EntityFrameworkCore;
using Task = lr29.Task;


localdbContext db = new();

//User user_1 = new()
//{
//    FName = "Вдовкин",
//    SName = "Арсений",
//    LName = "Антонович",
//    Login = "vdow123",
//    Password = "12345",
//    NumberPhone = 88005553535
//};
//db.Users.Add(user_1);
//db.SaveChanges();
//User user_2 = new()
//{
//    FName = "Рыбалкин",
//    SName = "Никита",
//    LName = "Артемович",
//    Login = "ryb123",
//    Password = "22d22",
//    NumberPhone = 89132003232
//};
//db.Users.Add(user_2);
//db.SaveChanges();
//User user_3 = new()
//{
//    FName = "Петров",
//    SName = "Петр",
//    LName = "Петрович",
//    Login = "petr123",
//    Password = "ye312",
//    NumberPhone = 86567765645
//};
//db.Users.Add(user_3);
//db.SaveChanges();
//User user_4 = new()
//{
//    FName = "Сидоров",
//    SName = "Александр",
//    LName = "Антонович",
//    Login = "sidar123",
//    Password = "arr312",
//    NumberPhone = 84566767645
//};
//db.Users.Add(user_4);
//db.SaveChanges();
//User user_5 = new()
//{
//    FName = "Лашков",
//    SName = "Сергей",
//    LName = "Семенович",
//    Login = "ser123434",
//    Password = "ser556",
//    NumberPhone = 88887373456
//};
//db.Users.Add(user_5);
//db.SaveChanges();
//Status status1 = new()
//{
//    NameStatus = "Не готов",
//};
//db.Statuses.Add(status1);
//db.SaveChanges();
//Status status2 = new()
//{
//    NameStatus = "Выполняется",
//};
//db.Statuses.Add(status2);
//db.SaveChanges();
//Status status3 = new()
//{
//    NameStatus = "Готов",
//};
//db.Statuses.Add(status3);
//db.SaveChanges();

//lr29.Task task1 = new()
//{
//    NameTask = "Решите уравнение",
//    DescriptionTask = "Нужно решить квадратное уравнение",
//    DatePub = new DateTime(2020, 01, 10),
//    CreatorId = 2,
//    AcceptorId = 1,
//    Statusid = 2
//};
//db.Tasks.Add(task1);
//db.SaveChanges();

//lr29.Task task2 = new()
//{
//    NameTask = "Решите задачку",
//    DescriptionTask = "Найдите сумму чисел",
//    DatePub = new DateTime(2021, 10, 20),
//    CreatorId = 1,
//    AcceptorId = 2,
//    Statusid = 2
//};
//db.Tasks.Add(task2);
//db.SaveChanges();
//lr29.Task task3 = new()
//{
//    NameTask = "Решите задачу на c++",
//    DescriptionTask = "Нужно выполнить 10 задач по по строкам",
//    DatePub = new DateTime(2021, 03, 12),
//    CreatorId = 2,
//    AcceptorId = 3,
//    Statusid = 3
//};
//db.Tasks.Add(task3);
//db.SaveChanges();
//lr29.Task task4 = new()
//{
//    NameTask = "Решите уравнение",
//    DescriptionTask = "Нужно решить кубическое уравнение",
//    DatePub = new DateTime(2022, 06, 19),
//    CreatorId = 3,
//    AcceptorId = 2,
//    Statusid = 3
//};
//db.Tasks.Add(task4);
//db.SaveChanges();
//lr29.Task task5 = new()
//{
//    NameTask = "Решите неравенство",
//    DescriptionTask = "Нужно решить неравенство",
//    DatePub = new DateTime(2022, 11, 10),
//    CreatorId = 4,
//    AcceptorId = 5,
//    Statusid = 2
//};
//db.Tasks.Add(task5);
//db.SaveChanges();

User selUser = new User();
List<User> UserList = new(db.Users);
List<User> UsersList = new(db.Users);
List<lr29.Task> TaskList = new(db.Tasks.Include<lr29.Task, Status>((lr29.Task x) => x.Status));
string check_log;
string check_pass;
int check_us;
string s_name;
string f_name;
string l_name;
string log;
string pass;
long num;
string ch;

void Register()
{
    Console.WriteLine("Введите Фамилию: ");
    s_name = Console.ReadLine();
    Console.WriteLine("Введите Имя: ");
    f_name = Console.ReadLine();
    Console.WriteLine("Введите Отчество");
    l_name = Console.ReadLine();
    Console.WriteLine("Введите Логин: ");
    log = Console.ReadLine();
    Console.WriteLine("Введите Пароль: ");
    pass = Console.ReadLine();
    Console.WriteLine("Введите Номер телефона: ");
    num = long.Parse(Console.ReadLine());
    User user = new User()
    {
        SName = s_name,
        FName = f_name,
        LName = l_name,
        Login = log,
        Password = pass,
        NumberPhone = num
    };
    db.Users.Add(user);
    db.SaveChanges();

    Console.WriteLine("Войти в систему?");
    ch = Console.ReadLine();
    if (ch == "Да")
    {
        Console.WriteLine("Введите логин: ");
        check_log = Console.ReadLine();

        Console.WriteLine("Введите пароль: ");
        check_pass = Console.ReadLine();
        User selUser = db.Users.FirstOrDefault(x => x.Login == check_log && x.Password == check_pass);
        if (selUser == null)
        {
            return;
        }

        if (selUser != null)
        {
            Console.WriteLine("Вы вошли");
        }
    }
}
void Auth()
{
    Console.WriteLine("Введите логин: ");
    check_log = Console.ReadLine();
    Console.WriteLine("Введите пароль: ");
    check_pass = Console.ReadLine();
    selUser = db.Users.FirstOrDefault(x => x.Login == check_log && x.Password == check_pass);
    if (selUser == null)
    {
        return;
    }

    if (selUser != null)
    {
        Console.WriteLine("Вы вошли");
    }
}

int Menu()
{
    Console.WriteLine("Выберите: ");
    Console.WriteLine("1. Посмотреть свой профиль,");
    Console.WriteLine("2. Посмотреть список пользователей(их логины),");
    Console.WriteLine("3. Посмотреть список доступных задач,");
    Console.WriteLine("4. Откликнуться на задачу,");
    Console.WriteLine("5. История задач,");
    Console.WriteLine("6. Изменить статус задачи,");
    Console.WriteLine("7. Фильтрация задач по дате,");
    Console.WriteLine("8. Найти задачу по логину");
    Console.WriteLine("9. Выход");
    var check = int.Parse(Console.ReadLine());
    return check;
}
Console.WriteLine("Выберите: 1. Регистрация, 2. Авторизация");
check_us = int.Parse(Console.ReadLine());
if (check_us == 1)
{
    Register();
}
else if (check_us == 2)
{
    Auth();
}

if (selUser != null)
{
    while (true)
    {
        switch (Menu())
        {
            case 1:
                Console.WriteLine($"Фамилия : {selUser.FName}, Имя: {selUser.SName}, Отчество: {selUser.LName}, Номер: {selUser.NumberPhone}");
                break;
            case 2:
                foreach (var UsersLogins in UserList)
                {
                    Console.WriteLine($"Логины пользователей: {UsersLogins.Login}");
                }
                break;
            case 3:
                TaskList.Where(x => x.Status.NameStatus == "Не готов");
                foreach (var task in TaskList) 
                    Console.WriteLine($"Доступные задачи: {task.Taskid} {task.NameTask} {task.DescriptionTask} {task.Status.NameStatus} {task.DatePub}");
                break;
                case 4:
                    Console.WriteLine("Введите номер задания: ");
                    var num1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Откликнуться? ?(Да или Нет)");
                    var ch3 = Console.ReadLine();
                    if (ch3 == "Да")
                    {
                    lr29.Task seltask = TaskList.FirstOrDefault<lr29.Task>((lr29.Task x) => x.Taskid == num1);
                        seltask.AcceptorId = selUser.Userid;
                        seltask.Statusid = 2;
                        db.SaveChanges();
                        Console.WriteLine($"Ваша задача : {seltask.Taskid} {seltask.NameTask} {seltask.DescriptionTask} {seltask.Status.NameStatus} {seltask.DatePub}");
                        Console.WriteLine($"Логин откликнувшегося: {seltask.Acceptor.Login}");
                    
                    }
                    else
                    {
                        Console.WriteLine("До свидания!");
                    }

                    break;
            case 5:
                var selTask = TaskList.Where(x => x.Statusid == 3 && x.AcceptorId == selUser.Userid);
                foreach (var task in selTask)
                {
                    Console.WriteLine($"Выполненные задачи: {task.Taskid} {task.NameTask} {task.DescriptionTask} {task.Status.NameStatus} {task.DatePub}");
                    Console.WriteLine($"Логин откликнувшегося: {task.Acceptor.Login}");
                }
                break;
            case 6:
                var usertask = TaskList.Where(x => x.CreatorId == selUser.Userid);
                foreach (var task in usertask)
                {
                    Console.WriteLine($"Ваши задачи: {task.Taskid} {task.NameTask} {task.DescriptionTask} {task.Status.NameStatus} {task.DatePub}");
                }
                Console.WriteLine("Выберите номер задачи, у которой хотите изменить статус");
                int num3 = Int32.Parse(Console.ReadLine());
                Task userTask = TaskList.FirstOrDefault(x => x.Taskid == num3);
                userTask.Statusid = 3;
                db.SaveChanges();
                Console.WriteLine($"Ваша задача : {userTask.Taskid} {userTask.NameTask} {userTask.DescriptionTask} {userTask.Status.NameStatus} {userTask.DatePub}");
                Console.WriteLine($"Логин откликнувшегося: {userTask.Creator.Login}");
                break;
            case 7:
                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                Console.WriteLine("С какой даты хотите начать искать?(Год.месяц.день)");
                dt1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("По какую дату хотите искать?(Год.месяц.день)");
                dt2 = DateTime.Parse(Console.ReadLine());
                var taskfilt = TaskList.Where(x => x.DatePub > dt1 && x.DatePub < dt2);
                foreach (var task in taskfilt)
                {
                    Console.WriteLine("Фильтр задач по дате публикации:");
                    Console.WriteLine($"{task.Taskid} {task.NameTask} {task.DescriptionTask} {task.Status.NameStatus} {task.DatePub}");
                }
                break;
            case 8:
                string checkLogUs;
                Console.WriteLine("Введите логин пользователя");
                checkLogUs = Console.ReadLine();
                var findUsers = UsersList.FirstOrDefault(x => x.Login == checkLogUs);
                var findTask = TaskList.Where(x => x.CreatorId == findUsers.Userid);
                if (findUsers != null && findTask != null)
                {
                    Console.WriteLine($"Задачи, логин создателя которой {findUsers.Login}, найдена");
                    foreach (var task in findTask)
                    {
                        Console.WriteLine($"{task.Taskid} {task.NameTask} {task.DescriptionTask} {task.Status.NameStatus} {task.DatePub}");
                    }
                }
                else if (findUsers == null && findTask == null)
                {
                    Console.WriteLine("Пользователь и задача не найдены");
                }
                break;
            case 9:
                Environment.Exit(1);
                break;




        }

    }
}





