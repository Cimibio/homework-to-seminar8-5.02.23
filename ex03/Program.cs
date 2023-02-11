// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.

int ReadInt(string message)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());
    return value;
}

void PrintMatrix(int[,] arg)
{
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            Console.Write($" {arg[i, j]} ");
        }
        Console.WriteLine();
    }
}

void FillMatrix(int[,] arg, int min, int max)
{
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            arg[i,j] = new Random().Next(min,max);
        }
    }
}

int[] FindMin(int[,] arg)
{
    int min = arg[0,0];
    int[] result = new int[2];
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            if (min > arg[i,j]) 
            {
                min = arg[i,j];
                result[0] = i;
                result[1] = j;
                
            }
        }
    }
    Console.Write($"Минимальный элемент находится в строке {result[0]} и столбце {result[1]} и равен {min}");
    Console.WriteLine();
    return result;
}

int[,] DeleteColRow(int[,] matrix, int[] result)
{
    int[,] newmatrix = new int[matrix.GetLength(0)-1, matrix.GetLength(1)-1];
    for (int i = 0, newRow = 0; i < matrix.GetLength(0); i++)
    {
        if (i == result[0]) continue;
        for (int j = 0, newcol = 0; j < matrix.GetLength(1); j++)
        {
            if (j == result[1]) continue;
            newmatrix[newRow, newcol] = matrix[i,j];
            newcol++;
        }
    newRow++;
    }
    return newmatrix;
}

void PrintArray(int[] array)
{
    for (int i=0; i < array.Length; i++)
    {
        Console.Write($"Элемент {i} = {array[i]}");
    }
}

int m = ReadInt("Введите количество строк матрицы: ");
int n = ReadInt("Введите количество столбцов матрицы: ");
int minimum = ReadInt("Введите значение минимального элемента: ");
int maximum = ReadInt("Введите значение максимального элемента: ");

int[,] matrix = new int[m,n];

FillMatrix(matrix, minimum, maximum);
PrintMatrix(matrix);
Console.WriteLine();

//FindMin(matrix);
Console.WriteLine();
Console.WriteLine("Матрица без строки и столбца с наименьшим элементом:");
PrintMatrix(DeleteColRow(matrix, FindMin(matrix)));