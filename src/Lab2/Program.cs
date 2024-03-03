using Lab2;

Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Work Email: romankoshchei@gmail.com");

string? choise = "";
while (choise != null)
{
    Console.WriteLine();
    Console.WriteLine("Enter your choise:");
    Console.WriteLine("[1] Task 1");
    Console.WriteLine("[2] Task 2");
    Console.WriteLine("[3] Task 3");
    Console.WriteLine("[4] Task 4");
    Console.WriteLine("[5] Task 5");
    Console.WriteLine("[6] Task 6");
    Console.WriteLine("[7] Task 7");
    Console.WriteLine("[8] Task 8");
    Console.WriteLine("[9] Task 9");
    choise = Console.ReadLine()?.Trim();

    switch (choise)
    {
        case "1":
            Task1.Run();
            break;

        case "2":
            Task2.Run();
            break;

        case "3":
            Task3.Run();
            break;

        case "4":
            Task4.Run();
            break;

        case "5":
            Task5.Run();
            break;

        case "6":
            Task6.Run();
            break;

        case "7":
            Task7.Run();
            break;

        case "8":
            Task8.Run();
            break;

        case "9":
            Task9.Run();
            break;

        default:
            choise = null;

            break;
    }
}

Console.WriteLine("Goodbye!");