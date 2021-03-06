﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_s_tour
{
    public class Knight
    {
        /// <summary>
        /// Список ходов коня
        /// </summary>
        readonly List<KnightPoint> Directions = new List<KnightPoint>() {
                    new KnightPoint(1, 2),
                    new KnightPoint(2, 1),
                    new KnightPoint(2,-1),
                    new KnightPoint(1, -2),
                    new KnightPoint(-1,-2),
                    new KnightPoint(-2,-1),
                    new KnightPoint(-2,1),
                    new KnightPoint(-1,2)
                };
        readonly List<KnightPoint> Directions90 = new List<KnightPoint>() {
                            new KnightPoint(2,-1),
                            new KnightPoint(1, -2),
                            new KnightPoint(-1,-2),
                            new KnightPoint(-2,-1),
                            new KnightPoint(-2,1),
                            new KnightPoint(-1,2),
                            new KnightPoint(1, 2),
                            new KnightPoint(2, 1)
                        };
        readonly List<KnightPoint> DirectionsN = new List<KnightPoint>() {
                    new KnightPoint(1, -2),
                    new KnightPoint(2,-1),
                    new KnightPoint(2, 1),
                    new KnightPoint(1, 2),
                    new KnightPoint(-1,2),
                    new KnightPoint(-2,1),
                    new KnightPoint(-2,-1),
                    new KnightPoint(-1,-2)
                };
        readonly List<KnightPoint> DirectionsN90 = new List<KnightPoint>() {
                    new KnightPoint(-2,-1),
                    new KnightPoint(-1,-2),
                    new KnightPoint(1, -2),
                    new KnightPoint(2,-1),
                    new KnightPoint(2, 1),
                    new KnightPoint(1, 2),
                    new KnightPoint(-1,2),
                    new KnightPoint(-2,1)
                };

        /// <summary>
        /// Позиция коня
        /// </summary>
        public KnightPoint Position;

        /// <summary>
        /// Координаты конечной позиции
        /// </summary>
        KnightPoint Finish;

        /// <summary>
        /// Доска
        /// </summary>
        Board Board;

        /// <summary>
        /// Список пройденных клеток
        /// </summary>
        public List<KnightPoint> Rought = new List<KnightPoint>();

        /// <summary>
        /// Создание коня
        /// </summary>
        /// <param name="startPosition">Начальная позиция</param>
        /// <param name="endPosition">Конечная позиция</param>
        /// <param name="board">Доска</param>
        public Knight(KnightPoint startPosition, KnightPoint endPosition, Board board)
        {
            Position = startPosition;
            Finish = endPosition;
            Rought.Add(startPosition);

            Board = board;
            Board.SetCellVisited(startPosition);
            Board.SetCellVisited(endPosition);
        }

        /// <summary>
        /// Передвижение коня
        /// </summary>
        public bool MoveNext()
        {
            List<KnightPoint> knightDirections = Directions;
            if (Position.X >= Board.Width / 2 && Position.Y < Board.Height)
                knightDirections = Directions90;
            if (Position.X < Board.Width / 2 && Position.Y < Board.Height)
                knightDirections = DirectionsN;
            if (Position.X >= Board.Width / 2 && Position.Y >= Board.Height)
                knightDirections = DirectionsN90;


            List<BoardCell> neighbors = Board.FindNotVisitedNeighbors(Position, knightDirections);
            KnightPoint targetPoint = new KnightPoint();

            int min = knightDirections.Count;

            if(Rought.Count > Board.Width * Board.Height - 1)
                Board.SetCellUnvisited(Finish);

            foreach (var n in neighbors)
            {
                int notVisitedCount = Board.FindNotVisitedNeighbors(n.Position, knightDirections).Count;
                if (notVisitedCount <= min)
                {
                    min = notVisitedCount;
                    targetPoint = new KnightPoint(n.Position.X, n.Position.Y);
                }
            }

            if (targetPoint.X != -1 && targetPoint.Y != -1)
            {
                Position = targetPoint;
                Rought.Add(targetPoint);
                Board.SetCellVisited(targetPoint);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Поиск пути бэктрекингом
        /// </summary>
        /// <param name="point">Позиция коня</param>
        /// <returns>Найден ли путь</returns>
        public bool MoveNextBacktrackingRecursive(KnightPoint point)
        {
            var nextPoint = new KnightPoint();

            if (Rought.Count >= Board.Width * Board.Height)
            {
                Position = point;
                Rought.Remove(nextPoint);
                Board.SetCellUnvisited(nextPoint);
                return true;
            }

            for (int k = 0; k < 8; k++)
            {
                nextPoint.X = point.X + Directions[k].X;
                nextPoint.Y = point.Y + Directions[k].Y;
                if (Rought.Count == (Board.Width * Board.Height - 1) && IsValid(nextPoint))
                {
                    Rought.Add(nextPoint);
                    Board.SetCellVisited(nextPoint);
                    Position = nextPoint;
                    if (MoveNextBacktrackingRecursive(nextPoint))
                        return true;
                    else
                    {
                        Position = point;
                        Rought.Remove(nextPoint);
                        Board.SetCellUnvisited(nextPoint);
                    }
                }
                else if (IsValid(nextPoint) && (nextPoint.X != Finish.X || nextPoint.Y != Finish.Y))
                {
                    Rought.Add(nextPoint);
                    Board.SetCellVisited(nextPoint);
                    Position = nextPoint;
                    if (MoveNextBacktrackingRecursive(nextPoint))
                        return true;
                    else
                    {
                        Position = point;
                        Rought.Remove(nextPoint);
                        Board.SetCellUnvisited(nextPoint);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка, находится ли точка в приделах стола
        /// </summary>
        /// <param name="point">Проверяемая точка</param>
        /// <returns>Принадлежность</returns>
        bool IsValid(KnightPoint point)
        {
            return (point.X >= 0 && point.X < Board.Width && point.Y >= 0
                && point.Y < Board.Height && !Board.GetCell(point).Visited);
        }
    }
}
