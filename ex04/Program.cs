// Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента

int ReadInt(string message)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());
    return value;
}

void Print3Darray(int[,,] arg)
{
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            for (int k = 0; k < arg.GetLength(2); k++)
            {
                Console.WriteLine($"Строка {i} столбец {j} и глубина {k} элемент равен = {arg[i, j, k]}");
            }

        }
    }
}

void Fill3Darray(int[,,] arg, int min, int max)
{
    List<int> UniqNumbers = new List<int>();
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            for (int k = 0; k < arg.GetLength(2); k++)
            {
                int RandomNumber = new Random().Next(min,max);
                while (UniqNumbers.Contains(RandomNumber))
                {
                    RandomNumber = new Random().Next(min,max);
                }
                arg[i,j,k] = RandomNumber;
                UniqNumbers.Add(arg[i,j,k]);
            }            
        }
    }
}

int m = ReadInt("Введите количество строк трехмерного массива: ");
int n = ReadInt("Введите количество столбцов трехмерного массива: ");
int p = ReadInt("Введите глубину трехмерного массива: ");
int minimum = ReadInt("Введите значение минимального элемента: ");
int maximum = ReadInt("Введите значение максимального элемента: ");

int[,,] array3D = new int[m,n,p];

Fill3Darray(array3D, minimum, maximum);
Print3Darray(array3D);
