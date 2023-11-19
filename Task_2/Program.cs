// Метод для вычисления суммы элементов в заданной строке row матрицы matrix. 
// Метод принимает двумерный массив целых чисел matrix и номер строки row,
//  а возвращает целое число - сумму элементов в данной строке.

// Метод для определения строки с наименьшей суммой элементов. 
// Метод принимает двумерный массив целых чисел matrix и возвращает 
// массив из двух элементов: номер строки с наименьшей суммой (нумерация начинается с 0) и саму сумму.

int ReadInt(string msg) // объявление функции со строковым параметром
{
    Console.WriteLine(msg);// пишет в консоль параметр msg
    int number = Convert.ToInt32(Console.ReadLine());// как результат преобразования строки в число
    return number; // возврат из функции
}

int[,] GenerateArray(int countRows, int countColums) // генерация рандомной матрицы
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

void PrintArray(int[,] array) // вывод на печать 
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        //Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} \t");
        }
        Console.WriteLine();
    }

}
// SumOfRow(int[,] matrix, int row): Метод для вычисления суммы элементов в заданной строке 
// row матрицы matrix. Метод принимает двумерный массив целых чисел matrix и номер строки row, 
// а возвращает целое число - сумму элементов в данной строке.

int SumOfRow(int[,] matrix, int row)
{
    int SumRow = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        SumRow = matrix[row - 1, j] + SumRow;
    }
    return SumRow;
}

//Метод для определения строки с наименьшей суммой элементов. 
// Метод принимает двумерный массив целых чисел matrix и возвращает массив из двух элементов: 
// номер строки с наименьшей суммой (нумерация начинается с 0) и саму сумму.


int[] MinimumSumRow(int[,] matrix)
{
    int[] MinSumElement = new int[2];
    int MinSumRow=0;
    int SumRow = 0;
    int Index = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        MinSumRow += matrix[0, i];
        MinSumElement[0] = i;
        MinSumElement[1] = MinSumRow;
      //Console.WriteLine($"{MinSumRow}");
    }       
    for (int i = 0; i < matrix.GetLength(0); i++)
    {   
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          SumRow += matrix[i,j];
        }
//           Console.Write($"{SumRow}\t");
//           Console.WriteLine();
          if (SumRow < MinSumRow) // проверка если две строки с одинаковой суммой, то выбираем первую вхождение
             { 
                MinSumRow = SumRow;
                Index = i;
                //Console.WriteLine($"{MinSumRow}");
             }       
          MinSumElement[0] = Index;
          MinSumElement[1] = MinSumRow;
         // Console.Write($"{MinSumElement[0]}\t");
         // Console.Write($"{MinSumElement[1]}\t");
        //  Console.WriteLine();
      
          
      SumRow =0; 
    }
return MinSumElement;
 }

int countRows = ReadInt("Введите количество строк массива: ");
int countColums = ReadInt("Введите количество столбцов массива: ");
int numberRow = ReadInt("Введите строку массива: ");
int[,] matrix = GenerateArray(countRows, countColums);
PrintArray(matrix);
int SumRow = SumOfRow(matrix, numberRow);
Console.WriteLine($"Сумма элементов в строке {numberRow}: {SumRow}");
int[] MinRow = MinimumSumRow(matrix);
Console.WriteLine($"Сумма наименьшей строки (строка {MinRow[0]}): {MinRow[1]} ");
