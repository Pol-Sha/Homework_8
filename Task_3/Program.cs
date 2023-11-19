
int ReadInt(string msg) // объявление функции со строковым параметром
{
    Console.WriteLine(msg);// пишет в консоль параметр msg
    string numb = Console.ReadLine();// функция считывания строки из терминала
    int number = Convert.ToInt32(numb);// как результат преобразования строки в число
    return number; // возврат из функции
}

int[,] GenerateArray(int countRows, int countColums)
{
    int[,] array = new int[countRows, countColums];
    Random random = new Random();
    for (int i = 0; i < countRows; i++)
    {
        for (int j = 0; j < countColums; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} \t");
        }

    }
    Console.WriteLine();
}

// MultiplyIfPossible(int[,] matrixA, int[,] matrixB): Метод для проверки, возможно ли 
// умножения двух матриц matrixA и matrixB. 
// Если число столбцов в матрице matrixA не равно числу строк в матрице matrixB, 
// то выводится сообщение "It is impossible to multiply." 
// В противном случае, вызывается метод MatrixMultiplication для умножения матриц, 
// и результат выводится с помощью метода PrintMatrix.

void MultiplyIfPossible(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
        {
          Console.WriteLine("It is impossible to multiply.");
          return;
        }
       else
        {
         int [,] result = MatrixMultiplication (matrixA, matrixB);
        PrintArray(result);
        return;
        }
}

// MatrixMultiplication(int[,] matrixA, int[,] matrixB): Метод для умножения двух матриц matrixA и matrixB. 
// Метод возвращает новую матрицу, которая представляет собой результат умножения матрицы matrixA 
// на матрицу matrixB.

int [,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
 int[,] MatrixMulti = new int [matrixA.GetLength(0), matrixB.GetLength(1)];
        for (int i = 0; i < matrixA.GetLength(0); i++)
         {
            for (int j = 0; j < matrixB.GetLength(1); j++)
              {
                MatrixMulti[i, j]= 0;
                for (int k = 0; k < matrixA.GetLength(1); k++)
                  {                  
            MatrixMulti[i, j] += (matrixA[i, k] * matrixB[k, j]);            
                  }
              //Console.WriteLine();
              }
         }
        return MatrixMulti;
}


int countRowsA = ReadInt("Введите количество строк массива А: ");
int countColumsA = ReadInt("Введите количество столбцов массива А: ");
int countRowsB = ReadInt("Введите количество строк массива В: ");
int countColumsB = ReadInt("Введите количество столбцов массива В: ");
int[,] matrixA = GenerateArray(countRowsA, countColumsA);
int[,] matrixB = GenerateArray(countRowsB, countColumsB);
PrintArray(matrixA);
PrintArray(matrixB);
MultiplyIfPossible(matrixA,matrixB);
