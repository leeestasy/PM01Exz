using System;

namespace Ignateva
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            while (size <= 0)
            {
                try
                {
                    Console.Write("Введите размер массива: ");
                    size = int.Parse(Console.ReadLine());
                    if (size == 0)
                    {
                        Console.WriteLine("Размер массива не может быть равен 0. Повторите попытку ввода:");
                    }
                    else if (size < 0)
                    {
                        Console.WriteLine("Размер массива не может быть отрицательным. Повторите попытку ввода:");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка ввода размера массива: {e.Message}! Введите целое число.");
                }
            }
            BusRegister busRegister = new BusRegister(size);
            for (int i = 0; i < size; i++)
            {
                int routeNumber;
                Console.Write($"Введите номер маршрута  для {i + 1}-го автобуса: ");
                while(!int.TryParse(Console.ReadLine(), out routeNumber))
                {
                    try
                    {
                        Console.WriteLine("Ошибка: введите целое число:");
                        Console.Write("Введите номер маршрута: ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка ввода номера маршрута: {e.Message}! Введите целое число.");
                    }
                }

                Console.Write($"Введите конечную остановку №1  для {i + 1}-го автобуса: ");
                string finalStop1 = Console.ReadLine();
                while (string.IsNullOrEmpty(finalStop1))
                {
                    try
                    {
                        Console.WriteLine("Ошибка: введите конечную остановку №1:");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка ввода конечную остановку №1: {e.Message}! Введите название остановки.");
                    }
                }

                Console.Write($"Введите конечную остановку №2 для {i + 1}-го автобуса: ");
                string finalStop2 = Console.ReadLine();
                while (string.IsNullOrEmpty(finalStop2))
                {
                    try
                    {
                        Console.WriteLine("Ошибка: введите конечную остановку №2:");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка ввода конечную остановку №2: {e.Message}! Введите название остановки.");
                    }
                }

                int numberOfStops = 0;
                while (numberOfStops <= 0)
                {
                    try
                    {
                        Console.Write($"Введите число остановок для {i + 1}-го автобуса: ") ;
                        numberOfStops = int.Parse(Console.ReadLine());
                        if (numberOfStops == 0)
                        {
                            Console.WriteLine("Число остановок не может быть равен 0. Повторите попытку ввода:");
                        }
                        else if (numberOfStops < 0)
                        {
                            Console.WriteLine("Число остановок не может быть отрицательным. Повторите попытку ввода:");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка ввода число остановок: {e.Message}! Введите целое число.");
                    }
                }
                busRegister.buses[i] = new Bus { routeNumber = routeNumber, finalStop1 = finalStop1, finalStop2 = finalStop2, numberOfStops = numberOfStops };
            }
            busRegister.sort();
            busRegister.saveToFile("Buses.txt");
        }
    }
}
