using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Ignateva
{
    public class BusRegister
    {
        public Bus[] buses;
        public BusRegister (int size)
        {
            buses = new Bus[size];
        }

        //метод сортировки по убыванию  «число остановок» и «номер маршрута»
        public void sort()
        {
            try
            {
                buses = buses.OrderByDescending(x => x.numberOfStops)
                    .ThenByDescending(x => x.routeNumber)
                    .ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка сортировки: {e.Message}!");

            }
        }

        //метод сохранения массива в файл

        public void saveToFile(string filename)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filename))
                {
                    foreach (Bus bus in buses)
                    {
                        streamWriter.WriteLine($"Номер маршрута: {bus.routeNumber}, конечная остановка №1: {bus.finalStop1}, конечная остановка №2: {bus.finalStop2}, число остановок: {bus.numberOfStops}");
                    }
                }
                Console.WriteLine("Данные успешно сохранен в файл!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка сохранения в файл: {e.Message}");
            }

        }
    }
}
