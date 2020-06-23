using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Resources;

namespace Knight_s_tour
{
    public partial class MainForm : Form
    {   
        /// <summary>
        /// Размер клетки доски в пикселях
        /// </summary>
        const int pixelSize = 40;

        /// <summary>
        /// Картинка доски (визуальное отображение) 
        /// </summary>
        public Bitmap BoardBitmap;

        /// <summary>
        /// Начальная позиция коня
        /// </summary>
        KnightPoint startPosition;

        /// <summary>
        /// Конечная позиция коня
        /// </summary>
        KnightPoint endPosition;

        /// <summary>
        /// Доска
        /// </summary>
        Board GameBoard;

        /// <summary>
        /// Конь
        /// </summary>
        Knight Knight;

        /// <summary>
        /// Запуск формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Меню: создание новой доски
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргументы события</param>
        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureGraphics.Image = null;
            pictureGraphics.Enabled = false;
            startPosition = endPosition = null;
            GameBoard = null;
            Knight = null;

            StartForm start = new StartForm();
            start.Show(this);
        }

        /// <summary>
        /// Отрисовка доски
        /// </summary>
        /// <param name="width">Ширина доски</param>
        /// <param name="height">Высота доски</param>
        public void DrawBoard(int width, int height)
        {
            //Создаем изображение
            BoardBitmap = new Bitmap(width * pixelSize, height * pixelSize);
            //Рисуем на созданом изображении
            Graphics gdi = Graphics.FromImage(BoardBitmap);
            //Заливаем изображение цветом по умолчанию (белый)
            gdi.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, BoardBitmap.Width, BoardBitmap.Height);

            //Рисуем черные клетки
            for(int i = 0; i < BoardBitmap.Width; i++)
                for(int j = 0; j < BoardBitmap.Height; j++)
                {
                    if (i % 2 == 0 ^ j % 2 == 0)
                        gdi.FillRectangle(new SolidBrush(Color.Brown), i * pixelSize, j * pixelSize, pixelSize, pixelSize);
                }

            pictureGraphics.Enabled = true;
            pictureGraphics.Image = new Bitmap(BoardBitmap);
            lblStatus.Text = "Выберите начальную позицию на доске";
            lblStatus.ForeColor = Color.Green;
            //Отключение режима рисования
            gdi.Dispose();
        }

        /// <summary>
        /// Обработка нажатия ЛКМ на изображении доски
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргументы события</param>
        private void pictureGraphics_MouseClick(object sender, MouseEventArgs e)
        {
            //Перевод координаты мыши в координаты клеток доски
            var mouse_point = new Point(e.X/pixelSize, e.Y/pixelSize);

            //Включаем режим рисования
            var gdi = Graphics.FromImage(BoardBitmap);

            if (startPosition == null)
            {
                startPosition = new KnightPoint(mouse_point.X, mouse_point.Y);
                //Отмечаем начальную клетку зелёным цветом
                gdi.FillRectangle(new SolidBrush(Color.Green), mouse_point.X * pixelSize, mouse_point.Y * pixelSize,
                    pixelSize, pixelSize);

                lblStatus.Text = "Укажите конечную позицию на доске";
                lblStatus.ForeColor = Color.Red;
            }
            else if (endPosition == null)
            {
                endPosition = new KnightPoint(mouse_point.X, mouse_point.Y);
                //Отмечаем конечную клетку красным цветом
                gdi.FillRectangle(new SolidBrush(Color.Red), mouse_point.X * pixelSize, mouse_point.Y * pixelSize,
                    pixelSize, pixelSize);

                lblStatus.Text = "Ход конем!";
                lblStatus.ForeColor = Color.Blue;
                //Запуск передвижения коня
                KnightTour();
            }
            pictureGraphics.Image = new Bitmap(BoardBitmap);
            //Отключение режима рисования
            gdi.Dispose();
        }

        /// <summary>
        /// Передвижение коня
        /// </summary>
        void KnightTour()
        {
            var boardWidth = BoardBitmap.Width / pixelSize;
            var boardHeight = BoardBitmap.Height / pixelSize;
            GameBoard = new Board(boardWidth, boardHeight);
            Knight = new Knight(startPosition, endPosition, GameBoard);
            //Включаем режим рисования
            var gdi = Graphics.FromImage(BoardBitmap);

            var firstWhite = (startPosition.X + startPosition.Y) % 2 == 0;
            var secondWhite = (endPosition.X + endPosition.Y) % 2 == 0;
            var boardEven = (GameBoard.Width * GameBoard.Height) % 2 == 0;

            if ((boardEven && (firstWhite ^ secondWhite)) || !boardEven && (firstWhite == secondWhite))
            {

                //Обход всей доски
                for (int i = 0; i < (boardWidth * boardHeight - 25); i++)
                {
                    var canMove = Knight.MoveNext();
                    if (!canMove)
                        break;
                }


                GameBoard.SetCellUnvisited(endPosition);
                Knight.MoveNextBacktrackingRecursive(Knight.Position);
            }

            if(Knight.Rought.Count == boardWidth * boardHeight)
            {
                for(int d = 0; d < Knight.Rought.Count; d++)
                {
                    //Рисуем очерёдность позиции коня
                    gdi.DrawString(d.ToString(), Font, new SolidBrush(ForeColor),
                        Knight.Rought[d].X * pixelSize, Knight.Rought[d].Y * pixelSize);
                    pictureGraphics.Image = new Bitmap(BoardBitmap);
                    pictureGraphics.Refresh();
                }
                lblStatus.Text = "Завершено!";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Нет возможного пути! Создайте новую доску";
                lblStatus.ForeColor = Color.Red;
            }

            //Отключение режима рисования
            gdi.Dispose();
        }

        /// <summary>
        /// Информация разработчиков)
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргументы события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.MnemonicPoem, "Мнемоническое стихотворение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
