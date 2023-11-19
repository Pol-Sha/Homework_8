// Метод для сортировки строк матрицы по убыванию. 
// Он принимает на вход двумерный массив целых чисел matrix и 
// сортирует каждую строку матрицы так, 
// чтобы элементы в каждой строке шли по убыванию.
// Исходная матрица:
// 9   1   7   
// 1   2   3   
// 4   5   6   

// Матрица с упорядоченными по убыванию строками:
// 9   7   1   
// 3   2   1   
// 6   5   4
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
        //Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} \t");
        }
    Console.WriteLine();
    }
    
}
int[,] SortMatrixLow(int[,] array)
{  
   for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1)-1; k++)
            {
                
                    if (array[i, k] < array[i, k+1])
                    {
                        int temp = array[i, k+1];
                        array[i, k+1] = array[i, k];
                        array[i, k] = temp;
                    }
                    
            }
        }
    }
    return array;
}

int countRows = ReadInt("Введите количество строк массива: ");
int countColums = ReadInt("Введите количество столбцов массива: ");
int[,] matrix = GenerateArray(countRows, countColums);
PrintArray(matrix);
int[,] newMatrix = SortMatrixLow(matrix);
PrintArray(newMatrix);