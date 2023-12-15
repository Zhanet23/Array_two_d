
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices;

void PrintArray(int[,] table) // метод печает массив
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

void FillArray(int[,] tabl) //метод заполняет массив рандомными целыми числами от 1 до 9
{
  for (int i = 0; i < tabl.GetLength(0); i++)
  {
    for (int j = 0; j < tabl.GetLength(1); j++)
    {
        tabl[i,j] = new Random().Next(1,10);
    }
  }
}

void Find_Element (int [,] A) //метод ищет элемент с заданным индексом и выводит его значение
{
   Console.WriteLine("Задайте позицию элемента.");
   Console.WriteLine("номер строки: ");
   int str = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("номер столбца: ");
   int stlb = Convert.ToInt32(Console.ReadLine());

   if (str >= A.GetLength(0) || stlb >= A.GetLength(1) || (str < 0) || (stlb < 0))
    Console.WriteLine("Элемента с введенным индексом нет в таблице.");
   else Console.WriteLine("Значение элемента с индексами [" + str + ", " + stlb + "]: " + A[str,stlb]);
}

void Replase_Lines (int[,] Arra) //метод принимает на вход массив и первую и последнюю строки местами
{
    int buf = 0;
    for (int j = 0; j < Arra.GetLength(1); j++)
    {
        buf =Arra[0,j]; //копируем в буфер первую строку (индекс 0)
        Arra[0,j] = Arra[Arra.GetLength(0)-1,j]; //в первую строку копируем последнюю
        Arra[Arra.GetLength(0)-1,j] = buf;       //в последнюю пишем первую
    }
  Console.WriteLine();// Задача 2
 PrintArray(Arra);    // Задача 2
}


void Find_Index (int [,] Mass) //метод ищет индекс строки с наименьшей суммой элементов
{
  int res_ind = 0;
  int sum = 0;
  int min = 0;
  for (int i = 0; i < Mass.GetLength(0); i++) //идем по строкам
  {
       for (int j = 0; j < Mass.GetLength(1); j++) // идем по столбцам
       {
           sum += Mass[i,j]; 
       }
       //посчитали сумму строки  
       Console.WriteLine("сумма " + i + "-ой строки: " + sum);
       if (sum < min) 
           {
            min = sum;
            res_ind = i;
           }
       sum = 0;
  }
    
  Console.WriteLine("Индекс строки с наименьшей суммой элементов: " + res_ind);
}


void Find_Index1 (int [,] Mass) //метод ищет индекс ВСЕ индексы строк с наименьшей суммой элементов
// если их в таблице получается несколько
{
  int [] mas_sum = new int [Mass.GetLength(0)];
  //int res_ind = 0;
  int sum = 0;
  for (int i = 0; i < Mass.GetLength(0); i++) //идем по строкам
  {
       for (int j = 0; j < Mass.GetLength(1); j++) // идем по столбцам
       {
           sum += Mass[i,j]; 
       }
       //посчитали сумму строки  
       Console.WriteLine("сумма " + i + "-ой строки: " + sum);
       mas_sum[i] = sum;
       sum = 0;
  }
   Console.WriteLine(String.Join(" ",mas_sum)); //получили массив сумм строк
   string count = ""; //сюда будем записывать индексы минимальных значений
   int min = mas_sum[0];

   for (int h = 1; h < mas_sum.Length; h++)
   {
     if ((mas_sum[h] < min)) min = mas_sum[h]; 
   }
  Console.WriteLine("минимальное значение: " + min);
  for (int h = 0; h < mas_sum.Length; h++)
   {
     if ((mas_sum[h] == min)) count = count + h + " "; 
   }
   Console.WriteLine("Индекс(ы) строк(и) с наименьшей суммой элементов: " + count);
}


//---------------Основное тело программы -----------------
int[,] Sim  = new int [new Random().Next(2,6),new Random().Next(2,6)]; 
//кол-во строк и столбцов задается рандомно от 2 до 5 

FillArray(Sim);
PrintArray(Sim);
//Find_Element(Sim); // задача 1

//Replase_Lines(Sim); // задача 2


//Find_Index(Sim); // задача 3
//Find_Index1(Sim);  //Задача 3.1





//______________________________________________________________________________
// метод ищет минимальный элемент массива, его индексы
// и убирает столбец с индексом минимального элемента, формируя новый массив
void Find_Min (int[,] array) 
{
  int min = array[0,0];
  int ind_i = 0;
  int ind_j = 0;
  // найдем минимальный элемент массива и сохраним его индексы
  // если элементов с минимальным значением несколько, программа сохраняет индексы первого из них.
  for (int i = 0; i < array.GetLength(0); i++) //идем по строкам
  {
       for (int j = 0; j < array.GetLength(1); j++) // идем по столбцам
       {
           if (array[i,j] < min) 
           {
           min = array[i,j];
           ind_i = i;
           ind_j = j;
           }
       }
  }
  Console.WriteLine();
  Console.WriteLine(min + " " + ind_i + " " + ind_j);

  
  //заполняем новый массив 
 
  int [,] D_Sim = new int [array.GetLength(0),array.GetLength(1)-1]; //создали новый массив результата
  
  for (int i = 0; i < array.GetLength(0); i++) //идем по строкам первоначального массива
  {
             // в каждой строке первоначального массива идем по столбцам до удаляемого столбца
             if (ind_j != 0) //если удаляемый столбец не с индексом 0, тк там по-другому цикл будет
             {
                 for(int j=0; j < ind_j; j++)
                 {
                   D_Sim[i,j] = array[i,j];
              
                 }
                 
                 //с удаляемого столбца игнорируем для записи в новый массив удаляемый столбец;
                 //и с этого момента индекс столбцов в новом массиве будет на 1 меньше.
                 for (int j = ind_j; j < array.GetLength(1)-1; j++ )
                 {
                     D_Sim[i,j] = array[i,j+1];

                 }
              } //конец условия if (ind_j != 0)
              else if (ind_j == 0) //если удаляемый столбец нулевой
              {
                 for(int j=ind_j; j < array.GetLength(0); j++)
                 {
                   D_Sim[i,j] = array[i,j+1];
              
                 }
               }
 
   }//закончили работу со столбцов в i-той строкой в цикле по строкам


Console.WriteLine("новый массив"); //выводим новый массив D_Sim
for (int i = 0; i < D_Sim.GetLength(0); i++)
  {
    for (int j = 0; j < D_Sim.GetLength(1); j++)
    {
        Console.Write(D_Sim[i,j] + " ");
    }
    Console.WriteLine();
  }

} //конец метода, формирующего новый массив с удаленным столбцом




Find_Min(Sim); // 4 задача*









