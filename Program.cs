/*
Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
m = 2, n = 3 -> A(m,n) = 9
m = 3, n = 2 -> A(m,n) = 29
*/

int m = 0, n = 0;

if (!InputControl())
    return;

int result = Func(m, n);

Console.WriteLine($"m = {m}, n = {n} -> A(m,n) = {result}");

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте натуральные числа m и n (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputNumbers = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck = inputNumbers.Length == 2 && int.TryParse(inputNumbers[0], out m) && int.TryParse(inputNumbers[1], out n) && m >= 0 && n >= 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int Func(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else 
    if (n == 0 && m > 0)
    {
        return Func(m - 1, 1);
    }
    else
    {
        return (Func(m - 1, Func(m, n - 1)));
    }
}

#endregion
