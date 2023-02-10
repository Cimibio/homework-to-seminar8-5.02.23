// Составить частотный словарь элементов двумерного массива

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

void FillMatrix(int[,] arg)
{
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        for (int j = 0; j < arg.GetLength(1); j++)
        {
            arg[i,j] = new Random().Next(1,10);
        }
    }
}

void CalcFreqNum(int[,] matrix, int[,] array)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int currentElement = matrix[i,j];
            for (int k = 0; k < matrix.Length; k++)     //цикл нужен для сравнения всех элементов массива с текущим элементом
            {
                int val = matrix[k / matrix.GetLength(1), k % matrix.GetLength(1)]; //это для пробегания по всему элементу массива - k/...(0) индекс строки, k%...(1) индекс столбца
                if (currentElement == val)
                {
                    array[k,0] = array[k,0] + 1;        //увеличиваем количество появления элемента при его появлении каждый раз, значение присваиваем в первый столбец массива частот
                    array[k,1] = matrix[i,j];           //тут(во втором столбце) находится сам элемент частоту появления которого мы определили
                }
            }
        }
    }
}

void PrintFreq(int[,] arg, int ammount)
{
    for (int i = 0; i < arg.GetLength(0); i++)
    {
        Console.WriteLine($"Число {arg[i,1]} встречается с частотой {(((double)arg[i,0] / ammount) * 100).ToString("0.##")}%");
    }
}

int m = ReadInt("Введите количество строк матрицы: ");
int n = ReadInt("Введите количество столбцов матрицы: ");
int minimum = ReadInt("Введите значение минимального элемента: ");
int maximum = ReadInt("Введите значение максимального элемента: ");

int[,] matrix = new int[m,n];

int[,] freq = new int[matrix.Length, 2];        //создаем двумерный массив, в котором два столбца и количество строк равное matrix.length - количество элементов массива matrix

FillMatrix(matrix);

PrintMatrix(matrix);

Console.WriteLine();
CalcFreqNum(matrix, freq);



Console.WriteLine();

PrintMatrix(freq);
Console.WriteLine();

PrintFreq(freq, m*n);