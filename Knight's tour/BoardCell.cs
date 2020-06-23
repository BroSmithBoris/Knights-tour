using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_s_tour
{
    /// <summary>
    /// Клетка доски
    /// </summary>
    public class BoardCell
    {
        /// <summary>
        /// Координата
        /// </summary>
        public KnightPoint Position;

        /// <summary>
        /// Посещённость
        /// </summary>
        public bool Visited;

        /// <summary>
        /// Создание клетки
        /// </summary>
        /// <param name="point">Координата клетки</param>
        /// <param name="visited">Посещённость</param>
        public BoardCell(KnightPoint point, bool visited = false)
        {
            Position = point;
            Visited = visited;
        }
    }
}
