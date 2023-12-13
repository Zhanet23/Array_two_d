//Задача 1
void PrintArray(int[,] table)
{
  for (int i = 0; i < table.GetLength(0); i++)
  {
    for (int j = 0; j < table.GetLength(1); j++)
    {
        Console.Write(table[i,j] + " ");
    }
    Console.WriteLine();
  }
}

void FillArray(int[,] tabl)
{
  for (int i = 0; i < tabl.GetLength(0); i++)
  {
    for (int j = 0; j < tabl.GetLength(1); j++)
    {
        tabl[i,j] = new Random().Next(1,10);
    }
  }
}

int[,] Sim  = new int [new Random().Next(2,6),new Random().Next(2,6)]; 
//кол-во строк и столбцов задается рандомно от 2 до 5
//PrintArray(Sim);
//Console.WriteLine();
FillArray(Sim);
PrintArray(Sim);

Console.WriteLine("Задайте позицию элемента.");
Console.WriteLine("номер строки: ");
int str = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("номер столбца: ");
int stlb = Convert.ToInt32(Console.ReadLine());

if (str >= Sim.GetLength(0) || stlb >= Sim.GetLength(1))
    Console.WriteLine("Элемента с введенным индексом нет в таблице.");
else Console.WriteLine(Sim[str,stlb]);


