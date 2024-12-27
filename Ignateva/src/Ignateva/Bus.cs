using System;
using System.Collections.Generic;
using System.Text;

namespace Ignateva
{
    public class Bus
    {
        public int routeNumber { get; set; } //номер маршрута - число
        public string finalStop1 { get; set; } //конечная остановка №1 - строка
        public string finalStop2 { get; set; } //конечная остановка №2 - строка
        public int numberOfStops { get; set; } //число остановок - число
    }
}
