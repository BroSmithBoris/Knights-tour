using System;
using System.Collections.Generic;

namespace Knight_s_tour
{
    /// <summary>
    /// Доска и работа с ней
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Клетки доски
        /// </summary>
        BoardCell[,] Cells;

        /// <summary>
        /// Ширина доски
        /// </summary>
        public int Width { get => Cells.GetLength(0); }
        /// <summary>
        /// Высота доски
        /// </summary>
        public int Height { get => Cells.GetLength(1); }

        /// <summary>
        /// Создание доски по ширине и высоте
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        public Board(int width, int height)
        {
            Cells = new BoardCell[width, height];

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    Cells[i, j] = new BoardCell(new KnightPoint(i,j));
                }
        }

        /// <summary>
        /// Получение клетки доски
        /// </summary>
        /// <param name="point">Координата клетки</param>
        /// <returns>Клетка доски или null при её отсутсвии</returns>
        public BoardCell GetCell(KnightPoint point)
        {
            var pointX = point.X;
            var pointY = point.Y;
            if (pointX >= 0 && pointX < Width && pointY >= 0 && pointY < Height)
                return Cells[pointX, pointY];
            else
                return null;
        }

        /// <summary>
        /// Отмечает клетку доски как посещённую конём
        /// </summary>
        /// <param name="point">Координата клетки</param>
        public void SetCellVisited(KnightPoint point)
        {
            var pointX = point.X;
            var pointY = point.Y;
            if (pointX >= 0 && pointX < Width && pointY >= 0 && pointY < Height)
                Cells[pointX, pointY].Visited = true;
        }

        /// <summary>
        /// Отмечает клетку доски как непосещённую конём
        /// </summary>
        /// <param name="point">Координата клетки</param>
        public void SetCellUnvisited(KnightPoint point)
        {
            var pointX = point.X;
            var pointY = point.Y;
            if (pointX >= 0 && pointX < Width && pointY >= 0 && pointY < Height)
                Cells[pointX, pointY].Visited = false;
        }

        /// <summary>
        /// Поиск непосещенных соседних клеток
        /// </summary>
        /// <param name="position">Координата клетки</param>
        /// <param name="directions">Ходы коня</param>
        /// <returns>Список клеток, которые можно посетить</returns>
        public List<BoardCell> FindNotVisitedNeighbors(KnightPoint position, List<KnightPoint> directions)
        {
            var notVisitedNeighbors = new List<BoardCell>();

            foreach (var d in directions)
            {
                var neighbor_cell = GetCell(new KnightPoint(
                    position.X + d.X,
                    position.Y + d.Y));

                if (neighbor_cell != null && !neighbor_cell.Visited)
                    notVisitedNeighbors.Add(neighbor_cell);
            }
            return notVisitedNeighbors;
        }
    } 
}
