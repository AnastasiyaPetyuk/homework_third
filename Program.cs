using System;

// Написать программу, реализующую алгоритм сложения
// в столбик двух положительных чисел.
// Программа должна прочитать из консоли 2 положительных числа
// (порядки чисел могут отличаться), разложить прочитанные
// числа на цифры и положить в массивы, сложить
// массивы используя алгоритм сложения столбиком, полученный
// результат перевести из результирующего массива
// обратно в число и вывести это число на экран.


namespace homework_third
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Введите первое число: ");
            int firstNumber = Number();

            Console.WriteLine("Введите второе число: ");
            int secondNumber = Number();
           
            int x = ReturnLegthNumm(firstNumber);
            int y = ReturnLegthNumm(secondNumber);
          
            int[] arr1 = new int[x];
            int[] arr2 = new int[y];


            arr1 = СonvertToArr(firstNumber, x);
            arr2 = СonvertToArr(secondNumber, y);

            Console.WriteLine("Результат сложения: ");
            Console.WriteLine(SumArrs(arr1, arr2));
        }

        static int Number()
        {
            string number = Console.ReadLine();

            int parsedNumber;
            bool success = int.TryParse(number, out parsedNumber);
            if (success)
            {   
                int positiveNumber = parsedNumber;
                    if (positiveNumber >= 0)
                    {

                        return positiveNumber;
                    }
                    else
                    {
                        Console.WriteLine("Допустимо вводить только положительные числа");
                        return Number();
                    }
            }
            else
            {
                Console.WriteLine("Допустимо вводить только положительные числа");
                return Number(); 
            }
        }

        static int ReturnLegthNumm(int number)
        {
            int length = 1;
            while (number > 9)
            {
                number = number / 10;
                length++;
            }

            return length;
        }

        static int[] СonvertToArr(int numb, int len)
        {
            int[] arr = new int[len];
            int i = 0;


            while (numb > 0)
            {
                arr[i] = numb % 10;
                numb = numb / 10;
                i++;
            }
            // временно создадим новый массив для ревверса
            int[] arrrev = new int[len];
            int xx = 0;
            for (int j = arr.Length-1; j >= 0; j--) 
            {
                arrrev[xx] = arr[j];
                xx++;
            }
            
            return arrrev;
        }

        static int SumArrs(int[] arr1, int[] arr2)
        { 
            int result = 0;
            if (arr1.Length >= arr2.Length)
            {
             
                int[] resultArray = new int[arr1.Length + 1];
                for (int i = 1; i <= arr1.Length; i++)
                {
                    if (i <= arr2.Length)
                    {
                        int x = arr1[arr1.Length - i] + arr2[arr2.Length - i] + resultArray[arr1.Length - i + 1];
                        if (x > 9)
                        {
                            resultArray[arr1.Length - i + 1] = x % 10;
                            resultArray[arr1.Length - i] += 1;
                        }
                        else 
                        {
                            resultArray[arr1.Length - i + 1] = x;
                        }
                    }
                    else
                    {
                        int y = arr1[arr1.Length - i] + resultArray[arr1.Length-i ];  
                        
                        if (y > 9)
                        {
                            resultArray[arr1.Length - i + 1] += y%10;
                            resultArray[arr1.Length - i] += 1; 
                        }
                        else
                        {
                            resultArray[arr1.Length - i + 1] += y;
                        }
                    }
                }

                if (resultArray[0] == 0)
                {
                    for (int i = 1; i < resultArray.Length; i++)
                    {
                        result = result * 10 + resultArray[i];
                    }
                }
                else
                {
                    for(int i = 0; i < resultArray.Length; i++) 
                    {
                        result = result * 10 + resultArray[i];
                    }
                }
            }
            else
            {
                int[] resultArray = new int[arr2.Length + 1];
                for (int i = 1; i <= arr2.Length; i++)
                {
                    if (i <= arr1.Length)
                    {
                        int x = arr2[arr2.Length - i] + arr1[arr1.Length - i] + resultArray[arr2.Length - i + 1];
                        if (x > 9)
                        {
                            resultArray[arr2.Length - i + 1] = x % 10;
                            resultArray[arr2.Length - i] += 1;
                        }
                        else
                        {
                            resultArray[arr2.Length - i + 1] = x;
                        }
                    }
                    else
                    {
                        int y = arr2[arr2.Length - i] + resultArray[arr2.Length - i];

                        if (y > 9)
                        {
                            resultArray[arr2.Length - i + 1] += y % 10;
                            resultArray[arr2.Length - i] += 1;
                        }
                        else
                        {
                            resultArray[arr2.Length - i + 1] += y;
                        }
                    }
                }

                if (resultArray[0] == 0)
                {
                    for (int i = 1; i < resultArray.Length; i++)
                    {
                        result = result * 10 + resultArray[i];
                    }
                }
                else
                {
                    for (int i = 0; i < resultArray.Length; i++)
                    {
                        result = result * 10 + resultArray[i];
                    }
                }
            }
            return result;
        }
    }
}
