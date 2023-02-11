// Найти произведение двух матриц


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

int[,] MuxMatrix(int[,] mA, int[,] mB) //C[i,j] = сумма произведений элементов Ai1*B1j,...,Ain*Bnj
{
    int[,] c = new int[mA.GetLength(0), mB.GetLength(1)];
    for (int i = 0; i < mA.GetLength(0); i++)
    {
        for (int j = 0; j < mB.GetLength(1); j++)
        {
            for (int k = 0; k < mB.GetLength(0); k++)
            {
                c[i,j] += mA[i,k] * mB[k,j];
            }
        }
    }
    return c;
}

int m = ReadInt("Введите количество строк первой матрицы: ");
int n = ReadInt("Введите количество столбцов первой матрицы, оно же число строк второй матрицы: ");
int k = ReadInt("Введите число столбцов второй матрицы: ");
int minimum = ReadInt("Введите значение минимального элемента: ");
int maximum = ReadInt("Введите значение максимального элемента: ");

int[,] matrixA = new int[m,n];
int[,] matrixB = new int[n,k];

FillMatrix(matrixA);
FillMatrix(matrixB);

Console.WriteLine("Матрица А: ");
PrintMatrix(matrixA);

Console.WriteLine("Матрица B: ");
PrintMatrix(matrixB);

Console.WriteLine("Произведение двух матриц: ");

PrintMatrix(MuxMatrix(matrixA, matrixB));

