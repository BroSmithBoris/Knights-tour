using System;
using System.Collections.Generic;

namespace Knight_s_tour
{
    public class KnightPoint
    {
        /// <summary>
        /// Положение по оси X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Положение по оси Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Создание точки без входных параметров
        /// </summary>
        public KnightPoint()
        {
            X = -1;
            Y = -1;
        }

        /// <summary>
        /// Создание точки с входными параметрами
        /// </summary>
        /// <param name="x">Значение оси X</param>
        /// <param name="y">Значение оси Y</param>
        public KnightPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
